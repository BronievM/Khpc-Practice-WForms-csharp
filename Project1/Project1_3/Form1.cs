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
                button1.Text = "Третє фото";
            }

           else if (pictureBox2.Visible)
            {
                pictureBox3.Visible = true;
                pictureBox2.Visible = false;
                button1.Text = "Портретне фото";
            }

            else
            {
                pictureBox3.Visible = false;
                pictureBox1.Visible = true;
                button1.Text = "Художнє фото";
            }

            button2.Enabled = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "Портретне фото";
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