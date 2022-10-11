using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4
{
    public partial class Form1 : Form
    {
        struct info
        {
            public string prizv, imja, adresa, tel;
        };
        info[] arr = new info[100];
        info r;
        int n;
        bool change;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 1;
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[0].HeaderText = "Прізвище";
            dataGridView1.Columns[1].HeaderText = "Ім'я";
            dataGridView1.Columns[2].HeaderText = "Адреса";
            dataGridView1.Columns[3].HeaderText = "Телефон";
            change = false;
        }
        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.ShowDialog();
        }

        private void кінецьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void записатиУФайлToolStripMenuItem_Click(object sender, EventArgs e)
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
                        r.prizv = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        r.imja = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        r.adresa = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        r.tel = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        writer.Write(r.prizv);
                        writer.Write(r.imja);
                        writer.Write(r.adresa);
                        writer.Write(r.tel);
                        i++;
                    }
                    writer.Close();
                    change = false;
                }
                catch (Exception) { }
            }
        }

        private void прочитатиЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            openFileDialog1.ShowDialog();
            if (openFileDialog1 == null) return;
            try
            {
                int i = 0;
                n = 0;
                BinaryReader reader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open));
                while (reader.PeekChar() > -1)
                {
                    dataGridView1.Rows.Add();
                    r.prizv = reader.ReadString();
                    r.imja = reader.ReadString();
                    r.adresa = reader.ReadString();
                    r.tel = reader.ReadString();
                    dataGridView1.Rows[i].Cells[0].Value = r.prizv;
                    dataGridView1.Rows[i].Cells[1].Value = r.imja;
                    dataGridView1.Rows[i].Cells[2].Value = r.adresa;
                    dataGridView1.Rows[i].Cells[3].Value = r.tel;
                    arr[n] = r;
                    i++;
                    n++;
                }
                newComboBox();
                reader.Close();
                change = false;
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        private void newComboBox()
        {
            int i, j;
            j = comboBox1.SelectedIndex;
            comboBox1.Items.Clear();
            if (n != 0)
            {
                for (i = 0; i < n; i++)
                    comboBox1.Items.Add(dataGridView1.Rows[i].Cells[0].Value);
                if (j < n) comboBox1.SelectedIndex = j;
                else if (j == n) comboBox1.SelectedIndex = j - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n != 0)
            {
                if (comboBox1.SelectedIndex == 0) comboBox1.SelectedIndex = n - 1;
                else comboBox1.SelectedIndex = comboBox1.SelectedIndex - 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (n != 0)
            {
                if (comboBox1.SelectedIndex == n - 1) comboBox1.SelectedIndex = 0;
                else comboBox1.SelectedIndex = comboBox1.SelectedIndex + 1;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            if (i > -1)
            {
                textBox2.Text = arr[i].prizv;
                textBox3.Text = arr[i].imja;
                textBox4.Text = arr[i].adresa;
                textBox5.Text = arr[i].tel;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            bool result = false;
            for (i = 0; i < n; i++)
            {
                if (arr[i].prizv == textBox1.Text)
                {
                    comboBox1.SelectedIndex = i;
                    result = true;
                }
            }

            if (!result) MessageBox.Show("Прізвище '" + textBox1.Text + "' не знайдено", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n != 0)
            {
                int i = comboBox1.SelectedIndex;
                for (; i < n; i++)
                    arr[i] = arr[i + 1];
                n--;
                dataGridView1.Rows.Clear();
                for (i = 0; i < n; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = arr[i].prizv;
                    dataGridView1.Rows[i].Cells[1].Value = arr[i].imja;
                    dataGridView1.Rows[i].Cells[2].Value = arr[i].adresa;
                    dataGridView1.Rows[i].Cells[3].Value = arr[i].tel;
                }
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                newComboBox();
                change = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете завершити роботу?", "Завершення роботи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
            else if (change) if (MessageBox.Show("Дані було змінено. Бажаєте зберегти дані?", "Збереження даних", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) записатиУФайлToolStripMenuItem_Click(sender, e);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            change = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            if ((dataGridView1.Rows[i].Cells[0].Value != null) && (dataGridView1.Rows[i].Cells[1].Value != null) && (dataGridView1.Rows[i].Cells[2].Value != null) && (dataGridView1.Rows[i].Cells[3].Value != null))
            {
                arr[i].prizv = dataGridView1.Rows[i].Cells[0].Value.ToString();
                arr[i].imja = dataGridView1.Rows[i].Cells[1].Value.ToString();
                arr[i].adresa = dataGridView1.Rows[i].Cells[2].Value.ToString();
                arr[i].tel = dataGridView1.Rows[i].Cells[3].Value.ToString();
                if (i == n) n++;
                newComboBox();
                comboBox1.SelectedIndex = i;
            }
        }
    }
}
