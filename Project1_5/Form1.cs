namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "������ ����")
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                button1.Text = "���� ����";
            }

            else if (button1.Text == "���� ����")
            {
                pictureBox3.Visible = true;
                pictureBox2.Visible = false;
                button1.Text = "��������� ����";
            }

            else
            {
                pictureBox1.Visible = true;
                pictureBox3.Visible = false;
                button1.Text = "������ ����";
            }

            button2.Enabled = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button2.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }
    }
}