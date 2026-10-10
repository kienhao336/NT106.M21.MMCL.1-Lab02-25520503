using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_IOStream
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            new Bai01().Show();
        }
        private void btnBai2_Click_1(object sender, EventArgs e)
        {
            new Bai02().Show();
        }
        private void btnBai3_Click_1(object sender, EventArgs e)
        {
            new Bai03().Show();
        }

        private void btnBai4_Click_1(object sender, EventArgs e)
        {
            new Bai04().Show();
        }

        private void btnBai5_Click_1(object sender, EventArgs e)
        {
            new Bai05().Show();
        }

        private void btnBai6_Click_1(object sender, EventArgs e)
        {
            new Bai06().Show();
        }

        private void btnBai7_Click_1(object sender, EventArgs e)
        {
            new Bai07().Show();
        }
    }
}
