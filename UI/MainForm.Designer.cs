
namespace UI
{
    partial class MainForm
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
            this.Button_ReadCSV = new System.Windows.Forms.Button();
            this.Button_OpenImportFolder = new System.Windows.Forms.Button();
            this.Button_OpenExportFolder = new System.Windows.Forms.Button();
            this.richTextBox_Output = new System.Windows.Forms.RichTextBox();
            this.Button_About = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_ReadCSV
            // 
            this.Button_ReadCSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_ReadCSV.Location = new System.Drawing.Point(0, 0);
            this.Button_ReadCSV.Name = "Button_ReadCSV";
            this.Button_ReadCSV.Size = new System.Drawing.Size(974, 23);
            this.Button_ReadCSV.TabIndex = 0;
            this.Button_ReadCSV.Text = "Read the CSV file";
            this.Button_ReadCSV.UseVisualStyleBackColor = true;
            this.Button_ReadCSV.Click += new System.EventHandler(this.Button_ReadCSV_Click);
            // 
            // Button_OpenImportFolder
            // 
            this.Button_OpenImportFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_OpenImportFolder.Location = new System.Drawing.Point(0, 23);
            this.Button_OpenImportFolder.Name = "Button_OpenImportFolder";
            this.Button_OpenImportFolder.Size = new System.Drawing.Size(974, 23);
            this.Button_OpenImportFolder.TabIndex = 3;
            this.Button_OpenImportFolder.Text = "Open the import folder (the folder where the import file is stored)";
            this.Button_OpenImportFolder.UseVisualStyleBackColor = true;
            this.Button_OpenImportFolder.Click += new System.EventHandler(this.Button_OpenImportFolder_Click);
            // 
            // Button_OpenExportFolder
            // 
            this.Button_OpenExportFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_OpenExportFolder.Location = new System.Drawing.Point(0, 46);
            this.Button_OpenExportFolder.Name = "Button_OpenExportFolder";
            this.Button_OpenExportFolder.Size = new System.Drawing.Size(974, 23);
            this.Button_OpenExportFolder.TabIndex = 4;
            this.Button_OpenExportFolder.Text = "Open the export folder (the folder where the exported file is stored)";
            this.Button_OpenExportFolder.UseVisualStyleBackColor = true;
            this.Button_OpenExportFolder.Click += new System.EventHandler(this.Button_OpenExportFolder_Click);
            // 
            // richTextBox_Output
            // 
            this.richTextBox_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Output.Location = new System.Drawing.Point(0, 69);
            this.richTextBox_Output.Margin = new System.Windows.Forms.Padding(20);
            this.richTextBox_Output.Name = "richTextBox_Output";
            this.richTextBox_Output.Size = new System.Drawing.Size(974, 486);
            this.richTextBox_Output.TabIndex = 5;
            this.richTextBox_Output.Text = "";
            // 
            // Button_About
            // 
            this.Button_About.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_About.Location = new System.Drawing.Point(0, 532);
            this.Button_About.Name = "Button_About";
            this.Button_About.Size = new System.Drawing.Size(974, 23);
            this.Button_About.TabIndex = 6;
            this.Button_About.Text = "About";
            this.Button_About.UseVisualStyleBackColor = true;
            this.Button_About.Click += new System.EventHandler(this.Button_About_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 555);
            this.Controls.Add(this.Button_About);
            this.Controls.Add(this.richTextBox_Output);
            this.Controls.Add(this.Button_OpenExportFolder);
            this.Controls.Add(this.Button_OpenImportFolder);
            this.Controls.Add(this.Button_ReadCSV);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_ReadCSV;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Button_OpenImportFolder;
        private System.Windows.Forms.Button button_ExportF;
        private System.Windows.Forms.Button Button_OpenExportFolder;
        private System.Windows.Forms.RichTextBox richTextBox_Output;
        private System.Windows.Forms.Button Button_About;
    }
}