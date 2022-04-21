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

            CreateLinklab_Combox();

            //拖拉放
            flowLayoutPanel3.AllowDrop = true;
            flowLayoutPanel3.DragEnter += FlowLayoutPanel3_DragEnter;
            flowLayoutPanel3.DragDrop += FlowLayoutPanel3_DragDrop;
        }
        string countryName = "";
        FrmShowImage frmShowImage = null;
        PictureBox pb = null;
        int tag = 0;

        private void CreateLinklab_Combox()
        {
            cityTableAdapter1.Fill(myAlbumDataSet1.City);

            for (int i = 0; i < myAlbumDataSet1.City.Rows.Count; i++)
            {
                comboBox1.Items.Add(myAlbumDataSet1.City[i].CityName);
                LinkLabel lb = new LinkLabel();
                lb.Text = myAlbumDataSet1.City[i].CityName;
                lb.Font = new Font("微軟正黑體", 12, FontStyle.Italic);
                this.flowLayoutPanel2.Controls.Add(lb);
                lb.Click += Lb_Click;
            }
        }
        private void Lb_Click(object sender, EventArgs e)
        {
            countryName = ((LinkLabel)sender).Text;
            myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum, ((LinkLabel)sender).Text);
            this.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < myAlbumDataSet1.MyAlbum.Rows.Count; i++)
            {
                PictureBox pb = new PictureBox();
                byte[] bytes = myAlbumDataSet1.MyAlbum[i].Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pb.Image = Image.FromStream(ms);
                pb.Width = 150;
                pb.Height = 150;
                pb.Tag = i;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                this.flowLayoutPanel1.Controls.Add(pb);
                pb.Click += Pb_Click;
            }
        }
        private void Pb_Click(object sender, EventArgs e)
        {
            frmShowImage = new FrmShowImage();
            tag = (int)(((PictureBox)sender).Tag);
            pb = new PictureBox();
            pb.Image = ((PictureBox)sender).Image;
            showImage();
        }
        void showImage()
        {
            pb.Dock = DockStyle.Fill;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            ToolStrip toolStrip = new ToolStrip();
            ToolStripButton stripButton1 = new ToolStripButton();
            stripButton1.Text = "上一張";
            stripButton1.Click += StripButton1_Click;
            ToolStripButton stripButton = new ToolStripButton();
            stripButton.Text = "自動撥放";
            stripButton.Click += StripButton_Click;
            ToolStripButton stripButton2 = new ToolStripButton();
            stripButton2.Text = "下一張";
            stripButton2.Click += StripButton2_Click;
            toolStrip.Items.Add(stripButton1);
            toolStrip.Items.Add(stripButton);
            toolStrip.Items.Add(stripButton2);
            frmShowImage.Controls.Clear();
            frmShowImage.Controls.Add(pb);
            frmShowImage.Controls.Add(toolStrip);
            frmShowImage.Show();
            frmShowImage.BringToFront();
            frmShowImage.FormClosing += FrmShowImage_FormClosing;
        }
        private void StripButton1_Click(object sender, EventArgs e)//上一張
        {
            myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum, countryName);
            if (tag - 1 < 0)
            {
                tag = myAlbumDataSet1.MyAlbum.Rows.Count - 1;
                pb = new PictureBox();
                byte[] bytes = myAlbumDataSet1.MyAlbum[tag].Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pb.Image = Image.FromStream(ms);
                showImage();
            }
            else
            {
                tag = tag - 1;
                pb = new PictureBox();
                byte[] bytes = myAlbumDataSet1.MyAlbum[tag].Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pb.Image = Image.FromStream(ms);
                showImage();
            }
        }
        private void StripButton2_Click(object sender, EventArgs e)//下一張
        {
            myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum, countryName);
            if (tag + 1 >= myAlbumDataSet1.MyAlbum.Rows.Count)
            {
                tag = 0;
                pb = new PictureBox();
                byte[] bytes = myAlbumDataSet1.MyAlbum[tag].Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pb.Image = Image.FromStream(ms);
                showImage();
            }
            else
            {
                tag = tag + 1;
                pb = new PictureBox();
                byte[] bytes = myAlbumDataSet1.MyAlbum[tag].Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pb.Image = Image.FromStream(ms);
                showImage();
            }
        }
        private void StripButton_Click(object sender, EventArgs e)//自動撥放按鈕
        {
            timer1.Enabled = !timer1.Enabled;
        }
        private void timer1_Tick(object sender, EventArgs e)//自動撥放
        {
            myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum, countryName);
            if (tag < myAlbumDataSet1.MyAlbum.Rows.Count)
            {
                timerShowImage();
            }
            else
            {
                tag = 0;
                timerShowImage();
            }
        }
        void timerShowImage()
        {
            pb = new PictureBox();
            byte[] bytes = myAlbumDataSet1.MyAlbum[tag].Image;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            pb.Image = Image.FromStream(ms);
            showImage();
            tag++;
        }
        private void FrmShowImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
        //tabpage2=============================================================================
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
                pb.Width = 150;
                pb.Height = 150;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                this.flowLayoutPanel3.Controls.Add(pb);
            }
        }
        private void button1_Click(object sender, EventArgs e)//File...
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
                    cityTableAdapter1.FillByCityName(myAlbumDataSet2.City, comboBox1.Text);
                    Image image = Image.FromFile(this.openFileDialog1.FileName);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.GetBuffer();

                    myAlbumTableAdapter1.Insert(myAlbumDataSet2.City[0].CityId, openFileDialog1.SafeFileName, bytes);

                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromStream(ms);
                    pb.Width = 150;
                    pb.Height = 150;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    this.flowLayoutPanel3.Controls.Add(pb);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)//Folder..
        {
            if (comboBox1.Text == "請選擇城市")
            {
                MessageBox.Show("請先選擇城市");
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    cityTableAdapter1.FillByCityName(myAlbumDataSet2.City, comboBox1.Text);
                    string folderName = folderBrowserDialog1.SelectedPath;
                    foreach (string files in Directory.GetFiles(folderName))
                    {
                        Image image = Image.FromFile(files);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] bytes = ms.GetBuffer();
                        myAlbumTableAdapter1.Insert(myAlbumDataSet2.City[0].CityId, comboBox1.Text, bytes);
                        PictureBox pb = new PictureBox();
                        pb.Width = 150;
                        pb.Height = 150;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Image = Image.FromFile(files);
                        this.flowLayoutPanel3.Controls.Add(pb);
                    }
                }
            }
        }
        private void FlowLayoutPanel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void FlowLayoutPanel3_DragDrop(object sender, DragEventArgs e)
        {
            if (comboBox1.Text == "請選擇城市")
            {
                MessageBox.Show("請先選擇城市");
            }
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                cityTableAdapter1.FillByCityName(myAlbumDataSet2.City, comboBox1.Text);
                for (int i = 0; i < files.Length; i++)
                {
                    Image image = Image.FromFile(files[i]);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.GetBuffer();
                    myAlbumTableAdapter1.Insert(myAlbumDataSet2.City[0].CityId, comboBox1.Text, bytes);
                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromFile(files[i]);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Width = 150;
                    pb.Height = 150;
                    flowLayoutPanel3.Controls.Add(pb);
                }
            }
        }
        //tabpage3=============================================================================
        private void cityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                myAlbumTableAdapter1.FillByJoin(myAlbumDataSet1.MyAlbum,myAlbumDataSet1.City[cityBindingSource.Position].CityName);
                myAlbumBindingSource.DataSource = myAlbumDataSet1.MyAlbum;
                myAlbumDataGridView.DataSource = myAlbumBindingSource;
        }


    }
}
