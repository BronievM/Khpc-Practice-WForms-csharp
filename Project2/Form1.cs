namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "п";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "р";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double f1, f2, f3, f4;
            f1 = Convert.ToDouble(textBox1.Text);
            f2 = Convert.ToDouble(textBox2.Text);
            f3 = Convert.ToDouble(textBox3.Text);
            if (radioButton1.Checked) f4 = f1 * f3;
            else f4 = f2 * f3;
            textBox4.Text = f4.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox3, "Введіть суму в доларах");
            toolTip1.SetToolTip(textBox1, "Введіть курс купівлі");
            toolTip1.SetToolTip(textBox2, "Введіть курс продажу");
            //5
            toolTip1.SetToolTip(textBox5, "Введіть милі");
            toolTip1.SetToolTip(textBox6, "Введіть кілометри");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label3.Text = "п";
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            else 
            {
                label3.Text = "р";
                radioButton1.Checked = true;
                radioButton2.Checked = false; 
            }
        }
//5
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = false;
            label5.Text = "п";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.ReadOnly = true;
            textBox5.ReadOnly = false;
            label5.Text = "р";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = false;
                label5.Text = "п";
                radioButton5.Checked = false;
                radioButton6.Checked = true;
            }
            else
            {
                textBox6.ReadOnly = true;
                textBox5.ReadOnly = false;
                label5.Text = "р";
                radioButton5.Checked = true;
                radioButton6.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double f1, f2, f4;
            const double mil = 1.609, mmil = 1.852;
            if (radioButton5.Checked)
            {
                f1 = Convert.ToDouble(textBox6.Text);
                if (radioButton3.Checked)
                {
                    f4 = f1 / mmil;
                }

                else
                {
                    f4 = f1 / mil;
                }
                textBox5.Text = f4.ToString();
            }
            else
            {
                f2 = Convert.ToDouble(textBox5.Text);
                if (radioButton3.Checked)
                {
                    f4 = f2 * mmil;
                }
                else f4 = f2 * mil;
                textBox6.Text = f4.ToString();
            }
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked) toolTip1.SetToolTip(textBox5, "Введіть морські милі");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) toolTip1.SetToolTip(textBox5, "Введіть милі");
        }
    }
}