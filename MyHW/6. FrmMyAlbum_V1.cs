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
    public partial class FrmMyAlbum_V1 : Form
    {
        public FrmMyAlbum_V1()
        {
            InitializeComponent();

            cityTableAdapter1.Fill(myAlbumDataSet1.City);

            for (int i = 0; i < myAlbumDataSet1.City.Rows.Count; i++)
            {
                LinkLabel l = new LinkLabel();
                l.Text = myAlbumDataSet1.City[i].CityName;//myAlbumDataSet.MyAlbum[i].City;
                l.Top = i * 40;
                l.Left = 0;
                this.panel1.Controls.Add(l);
                l.Click += L_Click;
            }
        }

        private void L_Click(object sender, EventArgs e)
        {
            myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum, ((LinkLabel)sender).Text);
            bindingSource1.DataSource = myAlbumDataSet1.MyAlbum;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            cityNameTextBox.DataBindings.Clear();
            cityNameTextBox.DataBindings.Add("Text", bindingSource1, "CityName");
            idTextBox.DataBindings.Clear();
            idTextBox.DataBindings.Add("Text",bindingSource1,"Id");
            descriptionTextBox.DataBindings.Clear();
            descriptionTextBox.DataBindings.Add("Text",bindingSource1, "Description");
            imagePictureBox.DataBindings.Clear();
            imagePictureBox.DataBindings.Add("Image",bindingSource1,"Image",true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                imagePictureBox.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bindingSource1.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myAlbumDataSet1);
        }
    }
}
