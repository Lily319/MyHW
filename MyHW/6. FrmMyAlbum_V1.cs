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

            myAlbumTableAdapter.FillByCity(myAlbumDataSet.MyAlbum);

            for (int i = 0; i < myAlbumDataSet.MyAlbum.Rows.Count; i++)
            {
                LinkLabel l = new LinkLabel();
                l.Text = myAlbumDataSet.MyAlbum[i].City;
                l.Top = i * 40;
                this.panel1.Controls.Add(l);
                l.Click += L_Click;
            }
        }

        private void L_Click(object sender, EventArgs e)
        {
            myAlbumTableAdapter.FillByCityImage(myAlbumDataSet.MyAlbum,((LinkLabel)sender).Text);
            myAlbumBindingSource.DataSource = myAlbumDataSet.MyAlbum;
            myAlbumDataGridView.DataSource = myAlbumBindingSource;
            myAlbumBindingNavigator.BindingSource = myAlbumBindingSource;
        }

        private void myAlbumBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.myAlbumBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myAlbumDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                imagePictureBox.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void FrmMyAlbum_V1_Load(object sender, EventArgs e)
        {
            this.myAlbumTableAdapter.Fill(this.myAlbumDataSet.MyAlbum);
        }
    }
}
