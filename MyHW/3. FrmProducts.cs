using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();

            productsTableAdapter1.Fill(nwDataSet1.Products);
            bindingSource1.DataSource = nwDataSet1.Products;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }

        private void btnLastone_Click(object sender, EventArgs e)
        {
            bindingSource1.Position -= 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bindingSource1.Position += 1;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = bindingSource1.Count - 1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            lblPosition.Text =$"{bindingSource1.Position + 1,-2}/{bindingSource1.Count}";
            lblResult.Text= "結果 "+bindingSource1.Count+"筆";
        }

        private void btBetween_Click(object sender, EventArgs e)
        {
            bool MinisNum = int.TryParse(txtMin.Text, out int min);
            bool MaxisNum = int.TryParse(txtMax.Text, out int Max);
            if (MaxisNum && MinisNum)
            {
            productsTableAdapter1.FillByBetween(nwDataSet1.Products,min,Max);
            bindingSource1.DataSource = nwDataSet1.Products;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            }
            else
            {
                MessageBox.Show("請輸入整數值!");
            }
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            productsTableAdapter1.FillByLike(nwDataSet1.Products,txtLike.Text);
            bindingSource1.DataSource = nwDataSet1.Products;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }
    }
}
