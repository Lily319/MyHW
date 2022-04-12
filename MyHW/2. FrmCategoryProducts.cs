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

namespace MyHomeWork
{
    public partial class FrmCategoryProducts : Form
    {
        public FrmCategoryProducts()
        {
            InitializeComponent();

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                conn.Open();
                SqlCommand comm = new SqlCommand("select CategoryName from Categories", conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["CategoryName"]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                conn.Open();
                SqlCommand comm = new SqlCommand("select ProductName,UnitPrice from products p join Categories c on p.CategoryID=c.CategoryID  where CategoryName='" + comboBox1.Text + "'", conn);
                SqlDataReader reader = comm.ExecuteReader();
                this.listBox1.Items.Clear();
                while (reader.Read())
                {
                    string s = $"{reader["ProductName"],-30} - {reader["unitprice"]:c2}";
                    this.listBox1.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
