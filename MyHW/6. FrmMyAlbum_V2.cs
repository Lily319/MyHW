using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                comboBox1.Items.Add(myAlbumDataSet1.City[i].CityName);
                LinkLabel lb = new LinkLabel();
                lb.Text = myAlbumDataSet1.City[i].CityName;
                lb.Font = new Font("微軟正黑體", 12,FontStyle.Italic);
                this.flowLayoutPanel2.Controls.Add(lb);
                lb.Click += Lb_Click;
            }
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum, ((LinkLabel)sender).Text);
            this.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < myAlbumDataSet1.MyAlbum.Rows.Count; i++)
            {
                PictureBox pb = new PictureBox();
                byte[] bytes = myAlbumDataSet1.MyAlbum[i].Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pb.Image = Image.FromStream(ms);
                pb.Width = 100;
                pb.Height = 100;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                this.flowLayoutPanel1.Controls.Add(pb);
                pb.Click += Pb_Click;
            }
        }
        FrmShowImage frmShowImage = new FrmShowImage();
        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Image = ((PictureBox)sender).Image;
            pb.Dock = DockStyle.Fill;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            frmShowImage.Controls.Clear();
            frmShowImage.Controls.Add(pb);
            frmShowImage.Show();
            frmShowImage.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "請選擇城市")
            {
                MessageBox.Show("請先選擇城市");
            }
            else
            {
                this.openFileDialog1.Filter = "(*.jpg)|*.jpg|(*.bmp)|*.bmp|Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    cityTableAdapter1.FillByCityName(myAlbumDataSet1.City, comboBox1.Text);
                    Image image = Image.FromFile(this.openFileDialog1.FileName);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.GetBuffer();

                    myAlbumTableAdapter1.Insert(myAlbumDataSet1.City[0].CityId, openFileDialog1.SafeFileName, bytes);
                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromStream(ms);
                    pb.Width = 100;
                    pb.Height = 100;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    this.flowLayoutPanel3.Controls.Add(pb);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum, comboBox1.Text);
            this.flowLayoutPanel3.Controls.Clear();
            for (int i = 0; i < myAlbumDataSet1.MyAlbum.Rows.Count; i++)
            {
                PictureBox pb = new PictureBox();
                byte[] bytes = myAlbumDataSet1.MyAlbum[i].Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pb.Image = Image.FromStream(ms);
                pb.Width = 100;
                pb.Height = 100;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                this.flowLayoutPanel3.Controls.Add(pb);
            }
        }

        private void cityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum,myAlbumDataSet1.City[cityBindingSource.Position].CityName);
                myAlbumBindingSource.DataSource = myAlbumDataSet1.MyAlbum;
                myAlbumDataGridView.DataSource = myAlbumBindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "請選擇城市")
            {
                MessageBox.Show("請先選擇城市");
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    foreach (string files in Directory.GetFiles(folderName))
                    {
                        PictureBox pb = new PictureBox();
                        pb.Width = 100;
                        pb.Height = 100;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Image = Image.FromFile(files);
                        this.flowLayoutPanel3.Controls.Add(pb);
                    }
                }
            }
        }
    }
}
