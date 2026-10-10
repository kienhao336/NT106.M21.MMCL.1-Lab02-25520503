namespace Lab2_IOStream
{
    partial class Bai06
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
            listView1 = new ListView();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(330, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(360, 12);
            button1.Name = "button1";
            button1.Size = new Size(420, 40);
            button1.TabIndex = 1;
            button1.Text = "Hôm nay ăn gì? (Random)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(360, 392);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 2;
            label1.Text = "Món ăn: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 417);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 3;
            label2.Text = "Người đóng góp: ";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(360, 66);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(420, 315);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Bai06
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "Bai06";
            Text = "Bai06 - Hôm nay ăn gì?";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
