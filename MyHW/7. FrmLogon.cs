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
using MyHW;

namespace MyHomeWork
{
    public partial class FrmLogon : Form
    {
        public FrmLogon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyMemberConnectionString))
                {
                    SqlCommand comm = new SqlCommand(); 
                    comm.CommandText = $"insert into mymember(username,password) values (@username,@password)";
                    comm.Connection = conn;
                    comm.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                    comm.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
                    conn.Open();
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Insert Member Successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyMemberConnectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = $"select Username,password from Mymember where username=@username and password=@password";
                    comm.Connection = conn;
                    comm.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                    comm.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("登入成功");
                        FrmMain frmMain = new FrmMain();
                        this.Hide();
                        frmMain.ShowDialog();
                        Application.ExitThread();
                    }
                    else
                    {
                        MessageBox.Show("登入失敗");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
