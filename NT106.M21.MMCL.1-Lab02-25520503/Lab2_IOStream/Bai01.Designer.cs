namespace Lab2_IOStream
{
    partial class Bai01
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDocFile = new Button();
            btnGhiFile = new Button();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // btnDocFile
            // 
            btnDocFile.Location = new Point(56, 74);
            btnDocFile.Name = "btnDocFile";
            btnDocFile.Size = new Size(94, 29);
            btnDocFile.TabIndex = 0;
            btnDocFile.Text = "ĐỌC FILE";
            btnDocFile.UseVisualStyleBackColor = true;
            btnDocFile.Click += btnDocFile_Click;
            // 
            // btnGhiFile
            // 
            btnGhiFile.Location = new Point(56, 186);
            btnGhiFile.Name = "btnGhiFile";
            btnGhiFile.Size = new Size(94, 29);
            btnGhiFile.TabIndex = 1;
            btnGhiFile.Text = "GHI FILE";
            btnGhiFile.UseVisualStyleBackColor = true;
            btnGhiFile.Click += btnGhiFile_Click;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(192, 74);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(292, 364);
            rtbContent.TabIndex = 2;
            rtbContent.Text = "";
            // 
            // Bai01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbContent);
            Controls.Add(btnGhiFile);
            Controls.Add(btnDocFile);
            Name = "Bai01";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDocFile;
        private Button btnGhiFile;
        private RichTextBox rtbContent;
    }
}
