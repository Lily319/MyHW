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
    public partial class FrmTreeView : Form
    {
        public FrmTreeView()
        {
            InitializeComponent();

            LoadCountryToTreeView();
        }

        private void LoadCountryToTreeView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand("select distinct Country,City,'count'=count(*) from Customers group by Country,City order by Country", conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    string country = "";
                    TreeNode node = null;
                    int count = 0;
                    while (reader.Read())
                    {
                        if (country!= reader["Country"].ToString())
                        {
                            node = this.treeView1.Nodes.Add($"{reader["Country"]}");
                            country = reader["Country"].ToString();
                            count = 0;
                        }
                        node.Nodes.Add(reader["City"].ToString());
                        count += (int)reader["count"];
                        node.Text = $"{country}({count})";
                    }
                    //SqlCommand comm = new SqlCommand("select Country,'count'=count(*) from customers group by Country", conn);
                    //SqlDataReader reader = comm.ExecuteReader();
                    //while (reader.Read())
                    //{
                    //    TreeNode node = this.treeView1.Nodes.Add($"{reader["Country"]}({reader["count"]})");
                    //    string country = reader["Country"].ToString();
                    //    using (SqlConnection conn1 = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    //    {
                    //        conn1.Open();
                    //        SqlCommand comm1 = new SqlCommand($"select distinct City from customers where country = '{country}'", conn1);
                    //        SqlDataReader reader1 = comm1.ExecuteReader();
                    //        while (reader1.Read())
                    //        {
                    //            node.Nodes.Add(reader1["City"].ToString());
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            customersTableAdapter1.FillByCity(nwDataSet1.Customers, ((TreeView)sender).SelectedNode.Text);
            dataGridView1.DataSource = (nwDataSet1.Customers);
            if(nwDataSet1.Customers.Rows.Count != 0)
            {
                label1.Text = $"共{nwDataSet1.Customers.Rows.Count}個 '{nwDataSet1.Customers[0].Country}' Customers";
            }
        }
    }
}
