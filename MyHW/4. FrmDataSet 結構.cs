using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmDataSet_結構 : Form
    {
        public FrmDataSet_結構()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(nwDataSet1.Products);
            categoriesTableAdapter1.Fill(nwDataSet1.Categories);
            customersTableAdapter1.Fill(nwDataSet1.Customers);
            dataGridView1.DataSource = nwDataSet1.Products;
            dataGridView2.DataSource = nwDataSet1.Categories;
            dataGridView3.DataSource = nwDataSet1.Customers;
            listBox1.Items.Clear();
            for (int i = 0; i <= nwDataSet1.Tables.Count - 1; i++)
            {
                DataTable table = nwDataSet1.Tables[i];
                listBox1.Items.Add(table.TableName);

                //縱向:欄 Column
                string s = "";
                for (int column = 0; column <= table.Columns.Count - 1; column++)
                {
                    s += table.Columns[column].ColumnName + " ";
                }
                listBox1.Items.Add(s);

                //橫向:列 Row
                //listBox2.Items.Add(table.Rows[row][0]);
                for (int row = 0; row <= table.Rows.Count - 1; row++)
                {
                    string r = "";
                    for (int j = 0; j <= table.Columns.Count - 1; j++)
                    {
                        r += table.Rows[row][j] + "  ";
                    }
                    listBox1.Items.Add(r);
                }
                listBox1.Items.Add("==============");
            }
        }
    }
}
