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
    public partial class FrmCategoryProducts3 : Form
    {
        public FrmCategoryProducts3()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter ada = new SqlDataAdapter("SELECT CategoryName FROM dbo.Categories", conn);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            for(int i = 0;i < ds.Tables[0].Rows.Count;i++)
            {
            comboBox1.Items.Add(ds.Tables[0].Rows[i]["CategoryName"]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter ada = new SqlDataAdapter("SELECT ProductID, ProductName, SupplierID, p.CategoryID," 
                +" QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued " 
                +"FROM dbo.Products as p join dbo.Categories as c on p.CategoryID=c.CategoryID " 
                +"where CategoryName ='"+ comboBox1.Text+"'", conn);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
