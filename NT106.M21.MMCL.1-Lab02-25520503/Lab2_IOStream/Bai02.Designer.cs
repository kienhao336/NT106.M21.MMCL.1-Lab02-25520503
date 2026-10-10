namespace Lab2_IOStream
{
    partial class Bai02
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
            btnReadFile = new Button();
            a = new Label();
            g = new Label();
            e = new Label();
            d = new Label();
            c = new Label();
            b = new Label();
            Charactercount = new TextBox();
            Wordscount = new TextBox();
            Linecount = new TextBox();
            URL = new TextBox();
            Size = new TextBox();
            btnExit = new Button();
            Filename = new TextBox();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // btnReadFile
            // 
            btnReadFile.Location = new Point(12, 12);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(240, 29);
            btnReadFile.TabIndex = 0;
            btnReadFile.Text = "Read from File";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // a
            // 
            a.AutoSize = true;
            a.Location = new Point(12, 55);
            a.Name = "a";
            a.Size = new Size(73, 20);
            a.TabIndex = 3;
            a.Text = "File name";
            // 
            // g
            // 
            g.AutoSize = true;
            g.Location = new Point(12, 354);
            g.Name = "g";
            g.Size = new Size(113, 20);
            g.TabIndex = 4;
            g.Text = "Character count";
            // 
            // e
            // 
            e.AutoSize = true;
            e.Location = new Point(12, 299);
            e.Name = "e";
            e.Size = new Size(92, 20);
            e.TabIndex = 5;
            e.Text = "Words count";
            // 
            // d
            // 
            d.AutoSize = true;
            d.Location = new Point(12, 243);
            d.Name = "d";
            d.Size = new Size(77, 20);
            d.TabIndex = 6;
            d.Text = "Line count";
            // 
            // c
            // 
            c.AutoSize = true;
            c.Location = new Point(12, 180);
            c.Name = "c";
            c.Size = new Size(35, 20);
            c.TabIndex = 7;
            c.Text = "URL";
            // 
            // b
            // 
            b.AutoSize = true;
            b.Location = new Point(12, 124);
            b.Name = "b";
            b.Size = new Size(36, 20);
            b.TabIndex = 8;
            b.Text = "Size";
            // 
            // Charactercount
            // 
            Charactercount.Location = new Point(129, 347);
            Charactercount.Name = "Charactercount";
            Charactercount.Size = new Size(206, 27);
            Charactercount.TabIndex = 10;
            // 
            // Wordscount
            // 
            Wordscount.Location = new Point(129, 296);
            Wordscount.Name = "Wordscount";
            Wordscount.Size = new Size(206, 27);
            Wordscount.TabIndex = 11;
            // 
            // Linecount
            // 
            Linecount.Location = new Point(129, 243);
            Linecount.Name = "Linecount";
            Linecount.Size = new Size(206, 27);
            Linecount.TabIndex = 12;
            // 
            // URL
            // 
            URL.Location = new Point(129, 177);
            URL.Name = "URL";
            URL.Size = new Size(206, 27);
            URL.TabIndex = 13;
            // 
            // Size
            // 
            Size.Location = new Point(131, 121);
            Size.Name = "Size";
            Size.Size = new Size(206, 27);
            Size.TabIndex = 14;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 391);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(325, 47);
            btnExit.TabIndex = 15;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Filename
            // 
            Filename.Location = new Point(129, 55);
            Filename.Name = "Filename";
            Filename.Size = new Size(206, 27);
            Filename.TabIndex = 16;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(360, 12);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(428, 420);
            rtbContent.TabIndex = 17;
            rtbContent.Text = "";
            // 
            // Bai02
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(Size);
            Controls.Add(URL);
            Controls.Add(Linecount);
            Controls.Add(Wordscount);
            Controls.Add(Charactercount);
            Controls.Add(b);
            Controls.Add(c);
            Controls.Add(d);
            Controls.Add(e);
            Controls.Add(g);
            Controls.Add(a);
            Controls.Add(rtbContent);
            Controls.Add(Filename);
            Controls.Add(btnReadFile);
            Name = "Bai02";
            Text = "Bai02";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReadFile;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Label a;
        private Label g;
        private Label e;
        private Label d;
        private Label c;
        private Label b;
        private TextBox Charactercount;
        private TextBox Wordscount;
        private TextBox Linecount;
        private TextBox URL;
        private TextBox Size;
        private Button btnExit;
        private TextBox Filename;
        private RichTextBox rtbContent;
    }
}