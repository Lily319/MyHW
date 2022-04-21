using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class FrmAdventureWorks : Form
    {
        public FrmAdventureWorks()
        {
            InitializeComponent();

            productPhotoTableAdapter.Fill(ADVWDataSet1.ProductPhoto);
            bindingSource1.DataSource = ADVWDataSet1.ProductPhoto;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            //productPhotoTableAdapter.FillByYear(ADVWDataSet1.ProductPhoto);
            //for (int i = 0; i < ADVWDataSet1.ProductPhoto.Rows.Count; i++)
            //{
            //    comboBox1.Items.Add(ADVWDataSet1.ProductPhoto.Rows[i]["Year"]);
            //}
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks;Integrated Security=True");
            SqlDataAdapter ada = new SqlDataAdapter("SELECT 'Year'=CONVERT(char(4),ModifiedDate,23) FROM Production.ProductPhoto group by CONVERT(char(4),ModifiedDate,23)", conn);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["Year"]);
            }
        }


        private void button13_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bindingSource1.Position -= 1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bindingSource1.Position += 1;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = bindingSource1.Count - 1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            label4.Text = $"{bindingSource1.Position + 1,-3} / {bindingSource1.Count}";
        }

        DateTime min;
        DateTime Max;
        private void button1_Click(object sender, EventArgs e)
        {
            min = dateTimePicker1.Value;
            Max = dateTimePicker2.Value;
            productPhotoTableAdapter.FillByDateTime(ADVWDataSet1.ProductPhoto,min,Max);
            bindingSource1.DataSource = ADVWDataSet1.ProductPhoto;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            min = DateTime.Parse("1/01/" + comboBox1.Text + " 00:00:00 AM");
            Max = DateTime.Parse("12/31/" + comboBox1.Text + " 11:59:59 PM");
            productPhotoTableAdapter.FillByDateTime(ADVWDataSet1.ProductPhoto,min,Max);
            bindingSource1.DataSource = ADVWDataSet1.ProductPhoto;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                productPhotoTableAdapter.FillByOrderby(ADVWDataSet1.ProductPhoto, min, Max);
                bindingSource1.DataSource = ADVWDataSet1.ProductPhoto;
                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
            }
            catch
            {

            }
        }
    }
}
