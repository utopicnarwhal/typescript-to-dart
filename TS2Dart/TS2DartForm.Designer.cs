namespace TS2Dart
{
    partial class TS2DartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TS2DartForm));
            this.tsFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.dartFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tsFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.tsFolderButton = new System.Windows.Forms.Button();
            this.dartFolderButton = new System.Windows.Forms.Button();
            this.dartFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.convertTypeTabs = new System.Windows.Forms.TabControl();
            this.folders = new System.Windows.Forms.TabPage();
            this.text = new System.Windows.Forms.TabPage();
            this.convertTextButton = new System.Windows.Forms.Button();
            this.DartTextbox = new System.Windows.Forms.TextBox();
            this.TStextbox = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.convertTypeTabs.SuspendLayout();
            this.folders.SuspendLayout();
            this.text.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsFolderPathTextBox
            // 
            resources.ApplyResources(this.tsFolderPathTextBox, "tsFolderPathTextBox");
            this.tsFolderPathTextBox.Name = "tsFolderPathTextBox";
            // 
            // tsFolderButton
            // 
            resources.ApplyResources(this.tsFolderButton, "tsFolderButton");
            this.tsFolderButton.Name = "tsFolderButton";
            this.tsFolderButton.UseVisualStyleBackColor = true;
            this.tsFolderButton.Click += new System.EventHandler(this.tsFolderButton_Click);
            // 
            // dartFolderButton
            // 
            resources.ApplyResources(this.dartFolderButton, "dartFolderButton");
            this.dartFolderButton.Name = "dartFolderButton";
            this.dartFolderButton.UseVisualStyleBackColor = true;
            this.dartFolderButton.Click += new System.EventHandler(this.dartFolderButton_Click);
            // 
            // dartFolderPathTextBox
            // 
            resources.ApplyResources(this.dartFolderPathTextBox, "dartFolderPathTextBox");
            this.dartFolderPathTextBox.Name = "dartFolderPathTextBox";
            // 
            // convertButton
            // 
            resources.ApplyResources(this.convertButton, "convertButton");
            this.convertButton.Name = "convertButton";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // convertTypeTabs
            // 
            resources.ApplyResources(this.convertTypeTabs, "convertTypeTabs");
            this.convertTypeTabs.Controls.Add(this.folders);
            this.convertTypeTabs.Controls.Add(this.text);
            this.convertTypeTabs.Name = "convertTypeTabs";
            this.convertTypeTabs.SelectedIndex = 0;
            // 
            // folders
            // 
            this.folders.Controls.Add(this.dartFolderPathTextBox);
            this.folders.Controls.Add(this.convertButton);
            this.folders.Controls.Add(this.tsFolderPathTextBox);
            this.folders.Controls.Add(this.tsFolderButton);
            this.folders.Controls.Add(this.dartFolderButton);
            resources.ApplyResources(this.folders, "folders");
            this.folders.Name = "folders";
            this.folders.UseVisualStyleBackColor = true;
            // 
            // text
            // 
            this.text.Controls.Add(this.convertTextButton);
            this.text.Controls.Add(this.DartTextbox);
            this.text.Controls.Add(this.TStextbox);
            resources.ApplyResources(this.text, "text");
            this.text.Name = "text";
            this.text.UseVisualStyleBackColor = true;
            // 
            // convertTextButton
            // 
            resources.ApplyResources(this.convertTextButton, "convertTextButton");
            this.convertTextButton.Name = "convertTextButton";
            this.convertTextButton.UseVisualStyleBackColor = true;
            this.convertTextButton.Click += new System.EventHandler(this.convertTextButton_Click);
            // 
            // DartTextbox
            // 
            resources.ApplyResources(this.DartTextbox, "DartTextbox");
            this.DartTextbox.Name = "DartTextbox";
            // 
            // TStextbox
            // 
            resources.ApplyResources(this.TStextbox, "TStextbox");
            this.TStextbox.Name = "TStextbox";
            // 
            // TS2DartForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.convertTypeTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TS2DartForm";
            this.Load += new System.EventHandler(this.TS2DartForm_Load);
            this.convertTypeTabs.ResumeLayout(false);
            this.folders.ResumeLayout(false);
            this.folders.PerformLayout();
            this.text.ResumeLayout(false);
            this.text.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog tsFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog dartFolderBrowserDialog;
        private System.Windows.Forms.TextBox tsFolderPathTextBox;
        private System.Windows.Forms.Button tsFolderButton;
        private System.Windows.Forms.Button dartFolderButton;
        private System.Windows.Forms.TextBox dartFolderPathTextBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl convertTypeTabs;
        private System.Windows.Forms.TabPage folders;
        private System.Windows.Forms.TabPage text;
        private System.Windows.Forms.Button convertTextButton;
        private System.Windows.Forms.TextBox DartTextbox;
        private System.Windows.Forms.TextBox TStextbox;
    }
}

