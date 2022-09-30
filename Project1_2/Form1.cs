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
            if (pictureBox1.Visible)
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
            }
            else if (pictureBox2.Visible)
            {
                pictureBox3.Visible = true;
                pictureBox2.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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