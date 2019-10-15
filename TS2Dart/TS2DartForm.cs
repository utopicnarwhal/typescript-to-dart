using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TS2Dart
{
    public partial class TS2DartForm : Form
    {
        public TS2DartForm()
        {
            InitializeComponent();
        }

        private void TS2DartForm_Load(object sender, EventArgs e)
        {
            tsFolderPathTextBox.Text = Properties.Settings.Default.storedTSPath;
            dartFolderPathTextBox.Text = Properties.Settings.Default.storedDartPath;
        }

        private void tsFolderButton_Click(object sender, EventArgs e)
        {
            if (tsFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tsFolderPathTextBox.Text = tsFolderBrowserDialog.SelectedPath;
                Properties.Settings.Default.storedTSPath = tsFolderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void dartFolderButton_Click(object sender, EventArgs e)
        {
            if (dartFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                dartFolderPathTextBox.Text = dartFolderBrowserDialog.SelectedPath;
                Properties.Settings.Default.storedDartPath = dartFolderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void convertTextButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] tsFileLines = TStextbox.Text.Split('\n');
                DartTextbox.Text = string.Empty;

                var stream = new MemoryStream();
                var dartStreamWriter = new StreamWriter(stream);
                var dartStreamReader = new StreamReader(stream);
                Convert(tsFileLines, dartStreamWriter);
                dartStreamWriter.Flush();
                stream.Position = 0;
                DartTextbox.Text = dartStreamReader.ReadToEnd();
                MessageBox.Show("Конвертация успешно завершена");
            }
            catch (Exception error)
            {
                MessageBox.Show("При конвертации произошла ошибка: " + error.ToString());
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles(tsFolderPathTextBox.Text, "*.ts");

                foreach (var tsFile in files)
                {
                    var fileName = Path.GetFileName(tsFile).Replace(".ts", "");
                    string[] tsFileLines = File.ReadAllLines(tsFile);

                    using (var dartFileStream = new FileStream(Path.Combine(dartFolderPathTextBox.Text + '/' + fileName + ".dart"), FileMode.Create))
                    {
                        using (var dartStreamWriter = new StreamWriter(dartFileStream))
                        {
                            Convert(tsFileLines, dartStreamWriter);
                        }
                    }
                }
                MessageBox.Show("Конвертация успешно завершена");
            } catch (Exception error)
            {
                MessageBox.Show("При конвертации произошла ошибка: " + error.ToString());
            }
        }

        private void Convert(string[] tsFileLines, StreamWriter dartStreamWriter)
        {
            var className = "";
            var dartClassName = "";
            var isMetadataMode = false;
            var containsStaticMetadata = false;
            var classExtendsName = "";
            var metadata = new MetadataClass();
            var currentMetadataField = new MetadataField();
            var classProperties = new List<ClassProperty>();
            dartStreamWriter.WriteLine("// This file is generated automatically");
            dartStreamWriter.WriteLine("// Don't modify by hand!");
            foreach (var origLine in tsFileLines)
            {
                var line = origLine;
                line = line.Replace("\r", "");

                if (line.StartsWith("//"))
                {
                    continue;
                }

                if (Regex.Match(line, @"readonly.*metadata.*=.*{").Success)
                {
                    isMetadataMode = true;
                    containsStaticMetadata = true;
                    continue;
                }
                if (isMetadataMode)
                {
                    if (line.Contains("};"))
                    {
                        isMetadataMode = false;
                    }
                    if (Regex.Match(line, @".*:.*{").Success)
                    {
                        if (currentMetadataField != null && currentMetadataField.name != null)
                        {
                            metadata.metadataFields.Add(currentMetadataField);
                        }
                        var fieldOriginalName = line.Split(' ').Where(s => s.Length > 0).First().Replace(":", "").Replace("?", "");
                        currentMetadataField = new MetadataField
                        {
                            originalName = fieldOriginalName,
                            name = ToLowerCamelCase(fieldOriginalName),
                        };
                        continue;
                    }
                    if (Regex.Match(line, @".*:.*\d.*").Success)
                    {
                        var optionOriginalName = line.Split(' ').Where(s => s.Length > 0).First().Replace(":", "").Replace("?", "");
                        currentMetadataField.metadataOptions.Add(
                            new MetadataOption()
                            {
                                originalName = optionOriginalName,
                                name = ToLowerCamelCase(MetadataClass.TransleetToEN(optionOriginalName)),
                                value = line.Split(' ').Where(s => s.Length > 0).Last().Replace(",", ""),
                            }
                        );
                    }
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    dartStreamWriter.WriteLine("");
                    continue;
                }

                if (line.Contains("import") && line.Contains("Base"))
                {
                    dartStreamWriter.WriteLine("import 'package:dompro/models/base.dart';");
                }
                if (line.Contains("import") && line.Contains("EntityProxyBase"))
                {
                    dartStreamWriter.WriteLine("import 'package:dompro/models/entity_proxy_base.dart';");
                }
                if (line.Contains("class"))
                {
                    var splittedLine = line.Split(' ');
                    var classLine = "";
                    for (int i = 0; i < splittedLine.Length; ++i)
                    {
                        if (className.Length > 0 && splittedLine.ElementAt(i).Contains(className))
                        {
                            continue;
                        }
                        if (splittedLine.ElementAt(i).Contains("export"))
                        {
                            continue;
                        }
                        if (splittedLine.ElementAt(i).Contains("extends"))
                        {
                            classLine += splittedLine.ElementAt(i) + ' ';
                            classExtendsName = splittedLine.ElementAt(i + 1);
                            continue;
                        }
                        if (splittedLine.ElementAt(i).Contains("class"))
                        {
                            classLine += splittedLine.ElementAt(i) + ' ';
                            className = splittedLine.ElementAt(i + 1);
                            dartClassName = ToLowerCamelCase(className.Substring(0, 1).ToUpper() + className.Remove(0, 1));
                            classLine += dartClassName + ' ';
                            continue;
                        }
                        classLine += splittedLine.ElementAt(i) + ' ';
                    }
                    dartStreamWriter.WriteLine("import 'package:json_annotation/json_annotation.dart';");
                    dartStreamWriter.WriteLine("");
                    dartStreamWriter.WriteLine($"part '{className.Substring(0, 1).ToLower() + className.Remove(0, 1)}.g.dart';");
                    dartStreamWriter.WriteLine("");
                    dartStreamWriter.WriteLine("@JsonSerializable(");
                    dartStreamWriter.WriteLine("  explicitToJson: true,");
                    dartStreamWriter.WriteLine(")");
                    dartStreamWriter.WriteLine(classLine);
                }
                if (Regex.Match(line, @"(.[^\(\)])*:.*;").Success)
                {
                    var classProperty = new ClassProperty();
                    var splittedLine = line.Split(' ');
                    for (int i = 0; i < splittedLine.Length; ++i)
                    {
                        switch (splittedLine.ElementAt(i))
                        {
                            case "private":
                                classProperty.isPrivate = true;
                                break;
                            case "public":
                                classProperty.isPrivate = false;
                                break;
                            case "readonly":
                                classProperty.readOnly = true;
                                break;
                            case "=":
                                classProperty.isInitialized = true;
                                break;
                            case "string":
                            case "Base.LookupItem":
                            case "Base.LookupItem[]":
                            case "Base.PicklistItem":
                            case "Base.PicklistItem[]":
                            case "Base.Date":
                            case "boolean":
                            case "number":
                                classProperty.type = splittedLine.ElementAt(i);
                                break;
                            default:
                                var match = Regex.Match(splittedLine.ElementAt(i), @".*:");
                                if (match.Success)
                                {
                                    classProperty.name = splittedLine.ElementAt(i).Replace(":", "").Replace("?", "");
                                    if (classProperty.name.First() == '_')
                                    {
                                        classProperty.name = classProperty.name.Remove(0, 1);
                                    }
                                    classProperty.jsonName = classProperty.name;
                                    classProperty.dartName = ToLowerCamelCase(classProperty.name);
                                }
                                match = Regex.Match(splittedLine.ElementAt(i), @".*;");
                                if (match.Success)
                                {
                                    if (classProperty.isInitialized)
                                    {
                                        classProperty.initValue = splittedLine.ElementAt(i).Replace(";", "");
                                    }
                                    else
                                    {
                                        classProperty.type = splittedLine.ElementAt(i).Replace(";", "");
                                    }
                                }
                                break;
                        }
                    }
                    dartStreamWriter.WriteLine(classProperty.ToDart());
                    classProperties.Add(classProperty);
                }
                if (line == "}")
                {
                    dartStreamWriter.WriteLine("  " + dartClassName + "({");
                    foreach (var property in classProperties)
                    {
                        if (property.readOnly && property.isInitialized)
                        {
                            continue;
                        }
                        dartStreamWriter.WriteLine($"    this.{property.dartName},");
                    }
                    if (classExtendsName == "EntityProxyBase")
                    {
                        dartStreamWriter.WriteLine("  }) : super(props: [");
                        foreach (var property in classProperties)
                        {
                            if (property.readOnly && property.isInitialized)
                            {
                                continue;
                            }
                            dartStreamWriter.WriteLine($"    {property.dartName},");
                        }
                        dartStreamWriter.WriteLine("  ]);");
                    } else
                    {
                        dartStreamWriter.WriteLine("  });");
                    }
                }
            }
            if (containsStaticMetadata)
            {
                dartStreamWriter.WriteLine("");
                dartStreamWriter.WriteLine("  static _Metadata metadata = _Metadata();");
            }
            dartStreamWriter.WriteLine("");
            dartStreamWriter.WriteLine($"  factory {dartClassName}.from{dartClassName}({dartClassName} source) => {dartClassName}.fromJson(source.toJson());");
            dartStreamWriter.WriteLine("");
            dartStreamWriter.WriteLine($"  factory {dartClassName}.fromJson(Map<String, dynamic> json) => _${dartClassName}FromJson(json);");
            dartStreamWriter.WriteLine($"  Map<String, dynamic> toJson() => _${dartClassName}ToJson(this);");
            dartStreamWriter.WriteLine("}");
            dartStreamWriter.WriteLine("");
            if (containsStaticMetadata)
            {
                dartStreamWriter.WriteLine("class _Metadata {");
                foreach (var metadataField in metadata.metadataFields)
                {
                    var metadataFieldClassName = '_' + metadataField.name.Substring(0, 1).ToUpper() + metadataField.name.Remove(0, 1);
                    dartStreamWriter.WriteLine($"  final {metadataFieldClassName} {metadataField.name} = {metadataFieldClassName}();");
                }
                dartStreamWriter.WriteLine("}");
                dartStreamWriter.WriteLine("");
                foreach (var metadataField in metadata.metadataFields)
                {
                    var metadataFieldClassName = '_' + metadataField.name.Substring(0, 1).ToUpper() + metadataField.name.Remove(0, 1);
                    dartStreamWriter.WriteLine($"/// `{metadataField.originalName}`");
                    dartStreamWriter.WriteLine($"class {metadataFieldClassName} {{");
                    foreach (var metadataOption in metadataField.metadataOptions)
                    {
                        dartStreamWriter.WriteLine($"  /// `{metadataOption.originalName}` = {metadataOption.value}");
                        dartStreamWriter.WriteLine($"  final {metadataOption.name} = {metadataOption.value};");
                    }
                    dartStreamWriter.WriteLine("}\n");
                }
            }
        }

        private string ToLowerCamelCase(string value)
        {
            var result = "";
            var nextIsCapital = false;
            foreach (var c in value)
            {
                if (c == '_')
                {
                    nextIsCapital = true;
                    continue;
                }
                if (nextIsCapital)
                {
                    result += c.ToString().ToUpper();
                    nextIsCapital = false;
                    continue;
                }
                result += c;
            }
            return result;
        }
    }

    class ClassProperty
    {
        public string type;
        public string name;
        public string dartName;
        public string jsonName;
        public bool isPrivate;
        public bool readOnly;
        public bool isInitialized;
        public string initValue;

        public string ToDart()
        {
            var result = "  ";
            if (dartName != jsonName)
            {
                result += $"@JsonKey(name: '{jsonName}')\n  ";
            }
            if (readOnly)
            {
                result += "final ";
            }
            if (type != null)
            {
                switch (type)
                {
                    case "string":
                        result += "String ";
                        break;
                    case "Base.LookupItem":
                        result += "LookupItem ";
                        break;
                    case "Base.LookupItem[]":
                        result += "List<LookupItem> ";
                        break;
                    case "Base.PicklistItem":
                        result += "PicklistItem ";
                        break;
                    case "Base.PicklistItem[]":
                        result += "List<PicklistItem> ";
                        break;
                    case "Base.Date":
                        result += "Date ";
                        break;
                    case "boolean":
                        result += "bool ";
                        break;
                    case "number":
                        result += "num ";
                        break;
                }
            }
            if (dartName != null)
            {
                result += dartName;
            }
            if (isInitialized)
            {
                result += " = " + initValue;
            }
            return result + ";";
        }
    }

    class MetadataOption
    {
        public string originalName;
        public string name;
        public string value;
    }

    class MetadataField
    {
        public string originalName;
        public string name;
        public List<MetadataOption> metadataOptions = new List<MetadataOption>();
    }

    class MetadataClass
    {
        public List<MetadataField> metadataFields = new List<MetadataField>();

        static Dictionary<string, string> words = new Dictionary<string, string>()
        {
            {"а", "a"},
            {"б", "b"},
            {"в", "v"},
            {"г", "g"},
            {"д", "d"},
            {"е", "e"},
            {"ё", "yo"},
            {"ж", "zh"},
            {"з", "z"},
            {"и", "i"},
            {"й", "j"},
            {"к", "k"},
            {"л", "l"},
            {"м", "m"},
            {"н", "n"},
            {"о", "o"},
            {"п", "p"},
            {"р", "r"},
            {"с", "s"},
            {"т", "t"},
            {"у", "u"},
            {"ф", "f"},
            {"х", "h"},
            {"ц", "c"},
            {"ч", "ch"},
            {"ш", "sh"},
            {"щ", "sch"},
            {"ъ", "j"},
            {"ы", "i"},
            {"ь", "j"},
            {"э", "e"},
            {"ю", "yu"},
            {"я", "ya"},
            {"А", "A"},
            {"Б", "B"},
            {"В", "V"},
            {"Г", "G"},
            {"Д", "D"},
            {"Е", "E"},
            {"Ё", "Yo"},
            {"Ж", "Zh"},
            {"З", "Z"},
            {"И", "I"},
            {"Й", "J"},
            {"К", "K"},
            {"Л", "L"},
            {"М", "M"},
            {"Н", "N"},
            {"О", "O"},
            {"П", "P"},
            {"Р", "R"},
            {"С", "S"},
            {"Т", "T"},
            {"У", "U"},
            {"Ф", "F"},
            {"Х", "H"},
            {"Ц", "C"},
            {"Ч", "Ch"},
            {"Ш", "Sh"},
            {"Щ", "Sch"},
            {"Ъ", "J"},
            {"Ы", "I"},
            {"Ь", "J"},
            {"Э", "E"},
            {"Ю", "Yu"},
            {"Я", "Ya"},
        };

        public static string TransleetToEN(string source)
        {
            foreach (KeyValuePair<string, string> pair in words)
            {
                source = source.Replace(pair.Key, pair.Value);
            }
            if (source.First() == '_')
            {
                source = 'z' + source.Remove(0, 1);
            }
            source = source.Substring(0, 1).ToLower() + source.Remove(0, 1);
            return source;
        }
    }
}
