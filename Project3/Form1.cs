using System.IO;
using System;
using System.Text;

namespace Project3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] arr;
        int n, i, count;
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void кінецьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void очиститиПолеВиведенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }


        private void протабулюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            double x, xk, h, y, yp =0, ymax=0, ymin=2.1;
            i = 0;
            x = Convert.ToDouble(textBox1.Text);
            xk = Convert.ToDouble(textBox2.Text);
            h = Convert.ToDouble(textBox3.Text);
            n = (int)((xk - x) / h) + 1;
            arr = new double[n];

            if (checkBox1.Checked)
            {
                if (checkBox4.Checked) listBox1.Items.Add("| X \t| Y \t| Y'");
                else listBox1.Items.Add("| X \t| Y ");
            }

            if (checkBox2.Checked)
            {
                using (StreamWriter writer1 = new StreamWriter("file.txt"))
                {
                    if (checkBox4.Checked) writer1.WriteLineAsync("| X      \t| Y      \t| Y'     ");
                    else writer1.WriteLineAsync("| X   \t| Y   \t");
                }
            }
            for (; x <= xk + 0.000001; x += h)
            {
               
                if (checkBox4.Checked) yp = Math.Cos(x);
                y = Math.Sin(x) + 1;
                if (checkBox1.Checked)
                {
                    if (checkBox4.Checked) 
                         listBox1.Items.Add("| " + x.ToString("0.00") + "\t| " + y.ToString("0.000") + "\t| " + yp.ToString("0.000"));
                    else listBox1.Items.Add("| " + x.ToString("0.00") + "\t| " + y.ToString("0.000"));
                }
                if (checkBox2.Checked)
                {
                    using (StreamWriter writer = new StreamWriter("file.txt", true))
                    {
                        if (checkBox4.Checked) 
                             writer.WriteLine("| " + x.ToString("0.00") + "\t| " + y.ToString("0.000") + "\t| " + yp.ToString("0.000"));
                        else writer.WriteLine("| " + x.ToString("0.00") + "\t| " + y.ToString("0.000"));
                    }
                }
                if (checkBox3.Checked)
                {
                    arr[i] = y;
                    i++;
                }
                if (y > 0.5 && y < 1) count++;
                if (y > ymax) ymax = y;
                if (y < ymin) ymin = y;
            }
            if (checkBox1.Checked)
            {
                listBox1.Items.Add("| Кількість елементів, 0,5 < y < 1: " + count);
                listBox1.Items.Add("| Найбільше значення: " + ymax.ToString("0.000"));
                listBox1.Items.Add("| Найменше значення: " + ymin.ToString("0.000"));
            }

            if (checkBox2.Checked)
            {
                using (StreamWriter writer = new StreamWriter("file.txt", true))
                {
                    writer.WriteLine("| Кількість елементів,  0,5 < y < 1: " + count);
                    listBox1.Items.Add("| Найбільше значення: " + ymax.ToString("0.000"));
                    listBox1.Items.Add("| Найменше значення: " + ymin.ToString("0.000"));
                }
            }
            
            count = 0;
        }

        private void кінецьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void знятиУсіПрапорціToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void встановитиУсіПрапорціToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
        }

        private void встановитиІнверсивноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            checkBox2.Checked = !checkBox2.Checked;
            checkBox3.Checked = !checkBox3.Checked;
            checkBox4.Checked = !checkBox4.Checked;
        }

        private void вивестиЗМасивуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MessageBox.Show("Масив порожній", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                else {
                        for (int j = 0; j < n; j++)
                        {
                            listBox1.Items.Add(arr[j].ToString("0.000") + "\n");
                        } 
            }
        }
    }
}