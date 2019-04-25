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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsFolderPathTextBox
            // 
            this.tsFolderPathTextBox.Enabled = false;
            this.tsFolderPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsFolderPathTextBox.Location = new System.Drawing.Point(148, 13);
            this.tsFolderPathTextBox.Name = "tsFolderPathTextBox";
            this.tsFolderPathTextBox.Size = new System.Drawing.Size(441, 26);
            this.tsFolderPathTextBox.TabIndex = 0;
            // 
            // tsFolderButton
            // 
            this.tsFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsFolderButton.Location = new System.Drawing.Point(13, 13);
            this.tsFolderButton.Name = "tsFolderButton";
            this.tsFolderButton.Size = new System.Drawing.Size(129, 26);
            this.tsFolderButton.TabIndex = 1;
            this.tsFolderButton.Text = "Указать папку с TS";
            this.tsFolderButton.UseVisualStyleBackColor = true;
            this.tsFolderButton.Click += new System.EventHandler(this.tsFolderButton_Click);
            // 
            // dartFolderButton
            // 
            this.dartFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dartFolderButton.Location = new System.Drawing.Point(12, 45);
            this.dartFolderButton.Name = "dartFolderButton";
            this.dartFolderButton.Size = new System.Drawing.Size(129, 26);
            this.dartFolderButton.TabIndex = 2;
            this.dartFolderButton.Text = "Указать папку с Dart";
            this.dartFolderButton.UseVisualStyleBackColor = true;
            this.dartFolderButton.Click += new System.EventHandler(this.dartFolderButton_Click);
            // 
            // dartFolderPathTextBox
            // 
            this.dartFolderPathTextBox.Enabled = false;
            this.dartFolderPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dartFolderPathTextBox.Location = new System.Drawing.Point(148, 44);
            this.dartFolderPathTextBox.Name = "dartFolderPathTextBox";
            this.dartFolderPathTextBox.Size = new System.Drawing.Size(441, 26);
            this.dartFolderPathTextBox.TabIndex = 3;
            // 
            // convertButton
            // 
            this.convertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.convertButton.Location = new System.Drawing.Point(225, 76);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(146, 38);
            this.convertButton.TabIndex = 4;
            this.convertButton.Text = "Конвертировать!";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 120);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(576, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // TS2DartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 155);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.dartFolderPathTextBox);
            this.Controls.Add(this.dartFolderButton);
            this.Controls.Add(this.tsFolderButton);
            this.Controls.Add(this.tsFolderPathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TS2DartForm";
            this.Text = "TS2Dart";
            this.Load += new System.EventHandler(this.TS2DartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog tsFolderBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog dartFolderBrowserDialog;
        private System.Windows.Forms.TextBox tsFolderPathTextBox;
        private System.Windows.Forms.Button tsFolderButton;
        private System.Windows.Forms.Button dartFolderButton;
        private System.Windows.Forms.TextBox dartFolderPathTextBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

