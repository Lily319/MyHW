using MyHomeWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyHW
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmHomeWork f = new FrmHomeWork()  
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2, 
                TopLevel = false, 
            };
            this.splitContainer2.Panel2.Controls.Add(f); 
            f.Show();
            f.BringToFront();
        }

        private void btn2_1_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmCategoryProducts f = new FrmCategoryProducts()
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2,
                TopLevel = false,
            };
            this.splitContainer2.Panel2.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btn2_2_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmCategoryProducts2 f = new FrmCategoryProducts2()
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2,
                TopLevel = false,
            };
            this.splitContainer2.Panel2.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btn2_3_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmCategoryProducts3 f = new FrmCategoryProducts3()
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2,
                TopLevel = false,
            };
            this.splitContainer2.Panel2.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmProducts f = new FrmProducts()
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2,
                TopLevel = false,
            };
            this.splitContainer2.Panel2.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmDataSet_結構 f = new FrmDataSet_結構()
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2,
                TopLevel = false,
            };
            this.splitContainer2.Panel2.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmAdventureWorks f = new FrmAdventureWorks()
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2,
                TopLevel = false,
            };
            this.splitContainer2.Panel2.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            IsMdiContainer = true;
            FrmMyAlbum_V1 f = new FrmMyAlbum_V1()
            {
                MdiParent = this,
                Parent = splitContainer2.Panel2,
                TopLevel = false,
            };
            this.splitContainer2.Panel2.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmLogon f = new FrmLogon();
            f.Show();
        }
    }
}
