using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectIndividual
{
    public partial class Form1 : Form
    {
        public struct mebli
        {
            public string name, material, brend, color, price, count, path;
        };
        mebli r;
        public int n;
        public mebli[] arr = new mebli[100];
        bool change, clicked;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CountOfAllGoods();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(arr);
            f2.Owner = this;
            f2.n = this.n;
            f2.arr_ = this.arr;
            f2.ShowDialog();
            CountOfAllGoods();
        }

        public void ReturnWords(System.Windows.Forms.TextBox textBox, int o, string one, string twofor, string fivezero)
        {
            textBox.Text = o.ToString();
            if (o >= 5 || o == 0) textBox.Text += fivezero;
            else if (o >= 2 && o <= 4) textBox.Text += twofor;
            else if (o == 1) textBox.Text += one;
        }

        public void CountOfAllGoods()
        {
            int nc = dataGridView1.RowCount - 1;
            int all = 0, allPrice = 0;
            if (nc != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    all += Convert.ToInt32(arr[i].count);
                    allPrice += Convert.ToInt32(arr[i].count) * Convert.ToInt32(arr[i].price);
                }
            }

            ReturnWords(textBox1, nc, " елемент", " елементи", " елементів");
            ReturnWords(textBox2, all, " штука", " штуки", " штук");
            textBox3.Text = allPrice.ToString() + " грн";
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            if ((dataGridView1.Rows[i].Cells[0].Value != null) && (dataGridView1.Rows[i].Cells[1].Value != null) && (dataGridView1.Rows[i].Cells[2].Value != null) && (dataGridView1.Rows[i].Cells[3].Value != null) && (dataGridView1.Rows[i].Cells[4].Value != null) && (dataGridView1.Rows[i].Cells[5].Value != null))
            {
                arr[i].name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                arr[i].material = dataGridView1.Rows[i].Cells[1].Value.ToString();
                arr[i].brend = dataGridView1.Rows[i].Cells[2].Value.ToString();
                arr[i].color = dataGridView1.Rows[i].Cells[3].Value.ToString();
                arr[i].price = dataGridView1.Rows[i].Cells[4].Value.ToString();
                arr[i].count = dataGridView1.Rows[i].Cells[5].Value.ToString();
                if (i == n) n++;
                CountOfAllGoods();
            }
            
            Form2 f2 = new Form2(arr);
            f2.arr_ = this.arr;
            f2.n = this.n;
            change = true;
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            openFileDialog1.ShowDialog();
            if (openFileDialog1 == null) return;
            
                try
            {
                int i = 0, pf = 0;
                BinaryReader reader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open));

                while (reader.PeekChar() > -1)
                {
                    dataGridView1.Rows.Add();
                    r.name = reader.ReadString();
                    r.material = reader.ReadString();
                    r.brend = reader.ReadString();
                    r.color = reader.ReadString();
                    r.price = reader.ReadString();
                    r.count = reader.ReadString();
                    dataGridView1.Rows[i].Cells[0].Value = r.name;
                    dataGridView1.Rows[i].Cells[1].Value = r.material;
                    dataGridView1.Rows[i].Cells[2].Value = r.brend;
                    dataGridView1.Rows[i].Cells[3].Value = r.color;
                    dataGridView1.Rows[i].Cells[4].Value = r.price;
                    dataGridView1.Rows[i].Cells[5].Value = r.count;
                    r.path = reader.ReadString();
                    if (File.Exists(r.path))
                    {
                        dataGridView1.Rows[i].Cells[6].Value = new Bitmap(r.path);
                    }
                    else pf++;
                    arr[n] = r;
                    i++;
                    n++;
                }
                reader.Close();
                CountOfAllGoods();
                if (pf > 0) MessageBox.Show("Картинки не знайдено. Можливо, ви їх видалили або перемістили", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                change = false;
            }
            catch (Exception) {  }
        }

        private void зберегти_якToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName == null) return;
                try
                {
                    int i = 0;
                    BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog1.FileName, FileMode.Create));
                    while (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        r.name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        r.material = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        r.brend = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        r.color = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        r.price = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        r.count = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        r.path = arr[i].path;
                        writer.Write(r.name);
                        writer.Write(r.material);
                        writer.Write(r.brend);
                        writer.Write(r.color);
                        writer.Write(r.price);
                        writer.Write(r.count);
                        writer.Write(r.path);
                        i++;
                    }
                    writer.Close();
                    change = false;
                }
                catch (Exception) { }
            }

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (((e.ColumnIndex == 4) || (e.ColumnIndex == 5)))
            {
                const string disallowed = @"[^0-9]"; 
                dataGridView1.Rows[e.RowIndex].ErrorText = "";
                var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, "");
                if (dataGridView1.Rows[e.RowIndex].IsNewRow) return;
                if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) == 0) return;
                dataGridView1.Rows[e.RowIndex].ErrorText = "!";
                MessageBox.Show("Введіть число!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void createGraphicsColumn(int i)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) dataGridView1.Rows[i].Cells[6].Value = new Bitmap(openFileDialog1.FileName);
            arr[i].path = openFileDialog1.FileName;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            playSimpleSound(0);
            if (MessageBox.Show("Ви дійсно хочете завершити роботу?", "Завершення роботи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
            else if (change) if (MessageBox.Show("Дані було змінено. Бажаєте зберегти дані?", "Збереження даних", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) зберегти_якToolStripMenuItem_Click(sender, e);
            playSimpleSound(2);
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show("Ви обрали вірний рядок, до якого хочете додати картинку?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    createGraphicsColumn(e.RowIndex);
                    change = true;
                }
                else change = false;
            }
        }

        private void закритиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            change = false;
            CountOfAllGoods();
            MessageBox.Show("Дані елементів було очищено", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            playSimpleSound(2);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && !clicked)
            {
                MessageBox.Show("Для того, щоб додати картинку, двічі клацніть по потрібному рядку", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                clicked = true;
            }
        }

        private void закритиФайлToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            закритиФайлToolStripMenuItem_Click(sender, e);
        }

        public void playSimpleSound(int a)
        {
            SoundPlayer simpleSound;
            switch (a)
            {
                case 0:
                    {
                        simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Notify Email.wav");
                        simpleSound.Play();
                        break;
                    }
                case 1:
                    {
                        simpleSound = new SoundPlayer(@"c:\Windows\Media\notify.wav");
                        simpleSound.Play();
                        break;
                    }
                case 2:
                    {
                        simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Message Nudge.wav");
                        simpleSound.Play();
                        break;
                    }
            }
            
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            playSimpleSound(1);
            f3.ShowDialog();
        }
    }
}

