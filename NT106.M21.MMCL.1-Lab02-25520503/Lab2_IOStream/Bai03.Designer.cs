namespace Lab2_IOStream
{
    partial class Bai03
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
            btnDocFile = new Button();
            rtbContent = new RichTextBox();
            btnTinhToan = new Button();
            SuspendLayout();
            // 
            // btnDocFile
            // 
            btnDocFile.Location = new Point(51, 33);
            btnDocFile.Name = "btnDocFile";
            btnDocFile.Size = new Size(94, 29);
            btnDocFile.TabIndex = 0;
            btnDocFile.Text = "ĐỌC FILE";
            btnDocFile.UseVisualStyleBackColor = true;
            btnDocFile.Click += button1_Click;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(249, 33);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(467, 361);
            rtbContent.TabIndex = 1;
            rtbContent.Text = "";
            // 
            // btnTinhToan
            // 
            btnTinhToan.Location = new Point(51, 116);
            btnTinhToan.Name = "btnTinhToan";
            btnTinhToan.Size = new Size(94, 29);
            btnTinhToan.TabIndex = 2;
            btnTinhToan.Text = "GHI FILE";
            btnTinhToan.UseVisualStyleBackColor = true;
            btnTinhToan.Click += btnTinhToan_Click;
            // 
            // Bai03
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTinhToan);
            Controls.Add(rtbContent);
            Controls.Add(btnDocFile);
            Name = "Bai03";
            Text = "Bai03";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDocFile;
        private RichTextBox rtbContent;
        private Button btnTinhToan;
    }
}