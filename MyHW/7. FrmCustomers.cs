using MyHW.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();

            listView1.View = View.Details;
            LoadCountryToCombobox();
            CreateListViewColumns();
        }
        string AllCountry = "(All)";
        string WhichCountry;
        private void CreateListViewColumns()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand("select * from customers", conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    DataTable table = reader.GetSchemaTable();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        listView1.Columns.Add(table.Rows[i][0].ToString());
                    }
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCountryToCombobox()
        {
            comboBox1.Items.Add(AllCountry);
            customers1TableAdapter1.FillByAllCountry(nwDataSet1.Customers1);
            for (int i = 0; i <nwDataSet1.Customers1.Rows.Count;i++) 
            {
                comboBox1.Items.Add(nwDataSet1.Customers1.Rows[i][0]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == AllCountry)
            {
                customersTableAdapter1.Fill(nwDataSet1.Customers);
                listView1.Items.Clear();
                for (int i = 0; i < nwDataSet1.Customers.Rows.Count; i++)
                {
                    ListViewItem lsv = listView1.Items.Add(nwDataSet1.Customers.Rows[i][0].ToString());
                    for (int j = 1; j < nwDataSet1.Customers.Columns.Count; j++)
                    {
                        lsv.SubItems.Add(nwDataSet1.Customers.Rows[i][j].ToString());
                    }
                }
            }
            else
            {
                WhichCountry = comboBox1.Text;
                listView1.Items.Clear();
                customersTableAdapter1.FillByCountry(nwDataSet1.Customers, WhichCountry);
                for (int i = 0; i < nwDataSet1.Customers.Rows.Count; i++)
                {
                    ListViewItem lsv = listView1.Items.Add(nwDataSet1.Customers.Rows[i][0].ToString());
                    for (int j = 1; j < nwDataSet1.Customers.Columns.Count; j++)
                    {
                        lsv.SubItems.Add(nwDataSet1.Customers.Rows[i][j].ToString());
                    }
                }
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void customerIDAscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhichCountry = comboBox1.Text;
            if (WhichCountry == AllCountry)
            {
                customersTableAdapter1.FillByOrderByID(nwDataSet1.Customers);
                listView1.Items.Clear();
                for (int i = 0; i < nwDataSet1.Customers.Rows.Count; i++)
                {
                    ListViewItem lsv = listView1.Items.Add(nwDataSet1.Customers.Rows[i][0].ToString());
                    for (int j = 1; j < nwDataSet1.Customers.Columns.Count; j++)
                    {
                        lsv.SubItems.Add(nwDataSet1.Customers.Rows[i][j].ToString());
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                customersTableAdapter1.FillByCOrderbyID(nwDataSet1.Customers, WhichCountry);
                for (int i = 0; i < nwDataSet1.Customers.Rows.Count; i++)
                {
                    ListViewItem lsv = listView1.Items.Add(nwDataSet1.Customers.Rows[i][0].ToString());
                    for (int j = 1; j < nwDataSet1.Customers.Columns.Count; j++)
                    {
                        lsv.SubItems.Add(nwDataSet1.Customers.Rows[i][j].ToString());
                    }
                }
            }
        }

        private void customerIDDescToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WhichCountry == AllCountry)
            {
                customersTableAdapter1.FillByIDDesc(nwDataSet1.Customers);
                listView1.Items.Clear();
                for (int i = 0; i < nwDataSet1.Customers.Rows.Count; i++)
                {
                    ListViewItem lsv = listView1.Items.Add(nwDataSet1.Customers.Rows[i][0].ToString());
                    for (int j = 1; j < nwDataSet1.Customers.Columns.Count; j++)
                    {
                        lsv.SubItems.Add(nwDataSet1.Customers.Rows[i][j].ToString());
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                customersTableAdapter1.FillByCountry_IDDESC(nwDataSet1.Customers, WhichCountry);
                for (int i = 0; i < nwDataSet1.Customers.Rows.Count; i++)
                {
                    ListViewItem lsv = listView1.Items.Add(nwDataSet1.Customers.Rows[i][0].ToString());
                    for (int j = 1; j < nwDataSet1.Customers.Columns.Count; j++)
                    {
                        lsv.SubItems.Add(nwDataSet1.Customers.Rows[i][j].ToString());
                    }
                }
            }
        }
    }
}

        //TODO HW

        //1. All Country
       

        //================================
         //2. ContextMenuStrip2
         //選擇性作業
        //Groups
        //USA (100) 
        //UK (20)

        //this.listview1.visible = false;
        //ListViewItem lvi = this.listView1.Items.Add(dataReader[0].ToString());

        //if (this.listView1.Groups["USA"] == null)
        //{                       {
        //    ListViewGroup group = this.listView1.Groups.Add("USA", "USA"); //Add(string key, string headerText);
        //    group.Tag = 0;
        //    lvi.Group = group; 
        //}
        //else
        //{
        //    ListViewGroup group = this.listView1.Groups["USA"]; 
        //    lvi.Group = group;
        //}

        //this.listView1.Groups["USA"].Tag = 
        //this.listView1.Groups["USA"].Header = 
                                 
