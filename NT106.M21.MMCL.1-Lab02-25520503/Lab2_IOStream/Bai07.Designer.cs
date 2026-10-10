namespace Lab2_IOStream
{
    partial class Bai07
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
            treeView1 = new TreeView();
            groupBox1 = new GroupBox();
            rtbContent = new RichTextBox();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(260, 450);
            treeView1.TabIndex = 0;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(rtbContent);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(266, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(528, 442);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "File Content";
            // 
            // rtbContent
            // 
            rtbContent.BackColor = SystemColors.Window;
            rtbContent.Dock = DockStyle.Fill;
            rtbContent.Location = new Point(3, 23);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new Size(522, 416);
            rtbContent.TabIndex = 1;
            rtbContent.Text = "";
            rtbContent.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(522, 416);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Bai07
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(treeView1);
            Name = "Bai07";
            Text = "Bai07 - Duyệt thư mục";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private GroupBox groupBox1;
        private RichTextBox rtbContent;
        private PictureBox pictureBox1;
    }
}
