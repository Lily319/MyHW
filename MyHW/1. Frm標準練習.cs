
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmHomeWork : Form
    {
        public FrmHomeWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 100;
            int b = 66;
            int c = 77;
            int[] arr = {a,b,c };
            lblResult.Text="三個數的最大值為 "+ arr.Max();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] nums = { 33, 4, 5, 11, 222, 34 };
            int OddC = 0,EvenC = 0;
            foreach (int item in nums)
            {
                OddC = item % 2 == 1 ? OddC+1 : OddC;
                EvenC = item % 2 == 0 ? EvenC+1 : EvenC;
            }
            lblResult.Text = "陣列{ 33, 4, 5, 11, 222, 34 }\n奇數有"+OddC+"個, 偶數有"+EvenC+"個";
        }
        void EvenOdd()
        {
            try
            {
                if (int.Parse(textBox4.Text) % 2 == 0)
                {
                    lblResult.Text=textBox4.Text+ "是 Even";
                }
                if (int.Parse(textBox4.Text) % 2 == 1)
                {
                    lblResult.Text = textBox4.Text + "是 Odd";
                }
            }
            catch
            {
                MessageBox.Show("請輸入整數值!");
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            string[] names = { "aaa", "ksdkfjsdk"};
            int[] namesL = new int[names.Length];
            foreach (string item in names)
            {
                int i = 0;
                namesL[i] = item.Length;
                i++;
            }
            foreach(string item in names)
            {
                lblResult.Text = namesL.Max() == item.Length ? "陣列{aaa,ksdkfjsdk}最長名字是" +item:"";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EvenOdd();
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EvenOdd();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] scores = { 2, 3, 46, 33, 22, 100,150, 33,55};
            int max =  scores.Max();
            lblResult.Text = "int[]的最大值為 " + max + "\nint[]的最小值為 " + MyMinScore(scores);
        }

        int MyMinScore(int[] nums)
        {
            int min = nums[0];
            foreach(int i in nums)
            {
                min = i < min ? i : min;
            }
            return min;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int F = int.Parse(textBox1.Text);
                int T = int.Parse(textBox2.Text);
                int S = int.Parse(textBox3.Text);
                int[] arr = new int[1];
                int j = 0;
                for (int i = F; i <= T; i += S)
                {
                    Array.Resize(ref arr, j + 1);
                    arr[j] = i;
                    j++;
                }
                lblResult.Text = F.ToString() + "到" + T + "相隔" + (S - 1) + "\n加總為 " + arr.Sum().ToString();
            }
            catch
            {
                MessageBox.Show("請輸入數值");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int F = int.Parse(textBox1.Text);
                int T = int.Parse(textBox2.Text);
                int S = int.Parse(textBox3.Text);
                int[] arr = new int[1];
                int j = 0;
                int i = F;
                do
                {
                    Array.Resize(ref arr, j + 1);
                    arr[j] = i;
                    j++;
                    i += S;
                }
                while (i <= T);
                lblResult.Text = F.ToString() + "到" + T + "相隔" + (S - 1) + "\n加總為 " + arr.Sum().ToString();
            }
            catch
            {
                MessageBox.Show("請輸入數值");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int F = int.Parse(textBox1.Text);
                int T = int.Parse(textBox2.Text);
                int S = int.Parse(textBox3.Text);
                int[] arr = new int[1];
                int j = 0;
                int i = F;
                while (i <= T)
                {
                    Array.Resize(ref arr, j + 1);
                    arr[j] = i;
                    j++;
                    i += S;
                }
                lblResult.Text = F.ToString() + "到" + T + "相隔" + (S - 1) + "\n加總為 " + arr.Sum().ToString();
            }
            catch
            {
                MessageBox.Show("請輸入數值");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lblResult.Text = "九九乘法表\n";
            for (int j = 1; j <= 9; j++)
            {
                for (int i = 1; i <= 9; i++)
                {
                    int a = j;
                    lblResult.Text += $"{i.ToString(),-1}";
                    a = j * i;
                    lblResult.Text += $"{"x" + j + "=" + a.ToString(),-8}";
                }
                lblResult.Text += "\n";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            lblResult.Text = Convert.ToString(100, 2);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string[] names = { "aaa", "ksdkfjsdk","candy","Cc" };
            int count = 0;
            foreach(string item in names)
            {
                count = item.Contains("c") || item.Contains("C") ? count + 1 : count;
            }
            lblResult.Text = "string[]名字有“C”or“c”字樣有" + count + "個";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            lblResult.Text = "結果";
        }
        int max(params int[] arr)
        {
            int max = arr[0];
            foreach (int i in arr)
            {
                max = i > max ? i : max;
            }
            return max;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int[] scores = { 2, 3, 46, 33, 22, 100, 150, 33, 55 };
            lblResult.Text = "陣列 { 2, 3, 46, 33, 22, 100, 150, 33, 55 }\n的最大值是 " + max(scores);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            lblResult.Text = "樂透號碼\n";
            Random rnd = new Random();
            List<int> randomList = Enumerable.Range(1, 49)
                .OrderBy(x => rnd.Next()).Take(6).ToList();
            for (int i = 0; i < 6; i++)
            {
                lblResult.Text += " " + randomList[i];
            }
        }
    }
}
