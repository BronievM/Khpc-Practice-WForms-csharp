using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectIndividual
{
    public partial class Form2 : Form
    {
        public Form1.mebli[] arr_ = new Form1.mebli[100];
        public int n;
        public Form2(Form1.mebli[] a)
        {
            InitializeComponent();
            Form1 main = this.Owner as Form1;
        }
        Form1 main = new Form1();
        Picture_ pic = new Picture_();

        public bool findFurn(int i)
        {
            comboBox1.Items.Add(arr_[i].name);
            comboBox1.SelectedIndex = 0;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool res = false;


            comboBox1.Items.Clear();
            for (i = 0; i < n; i++)
            {
                int spaceIndex = arr_[i].name.IndexOf(" ");
                string LCfirstLine = " ";
                string firstLine = " ";
                string lowcase = arr_[i].name.ToLower();
                try
                {
                    firstLine = arr_[i].name.Substring(0, spaceIndex);
                    LCfirstLine = lowcase.Substring(0, spaceIndex);
                }
                catch { }

                string TBnoSpaces = textBox1.Text.Replace(" ", "");
                string TBnoSpacesLC = TBnoSpaces.ToLower();


                if (textBox1.Text.Equals(firstLine) || textBox1.Text.Equals(arr_[i].name) || textBox1.Text.Equals(lowcase) || textBox1.Text.Equals(LCfirstLine) || TBnoSpaces.Equals(firstLine) || TBnoSpacesLC.Equals(LCfirstLine))
                {
                    if ((checkBox1.Checked) && (Convert.ToInt64(arr_[i].count) >= 1))
                    {
                        comboBox1.Items.Add(arr_[i].name);
                        comboBox1.SelectedIndex = 0;
                    }

                    else if (!checkBox1.Checked)
                    {
                        comboBox1.Items.Add(arr_[i].name);
                        comboBox1.SelectedIndex = 0;
                    }
                    res = true;
                }
            }

            if (!res) MessageBox.Show("Меблі з назвою '" + textBox1.Text + "' не знайдено", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= n - 1; i++)
            {
                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == arr_[i].name)
                {
                    textBox2.Text = arr_[i].name;
                    textBox3.Text = arr_[i].material;
                    textBox4.Text = arr_[i].brend;
                    textBox5.Text = arr_[i].color;
                    textBox6.Text = arr_[i].price + " грн";
                    textBox7.Text = arr_[i].count + " шт";
                    if (File.Exists(arr_[i].path))
                    {
                        pictureBox1.Image = Image.FromFile(arr_[i].path);
                        pic.pictureBox1.Image = Image.FromFile(arr_[i].path);
                    }
                }
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pic.ShowDialog();
        }
    }
}
