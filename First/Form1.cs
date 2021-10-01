using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace First
{
    public partial class Form1 : Form
    {
        public ArrayList list;
        private Random random;
        private Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            this.UpdateStyles();

            random = new Random();
            list = new ArrayList();

            populate();

            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Controls.Add(this.pictureBox1);

            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 20;
        }

        private void button1_Click(object sender, EventArgs e) { timer.Start(); }
        private void button2_Click(object sender, EventArgs e) { timer.Stop(); }
        private void button3_Click(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (Ball ball in list)
            {
                ball.posX = random.Next(0, this.pictureBox1.Width / 2);
                ball.posY = random.Next(0, this.pictureBox1.Height / 2);
                ball.speedX = random.Next(1, 10);
                ball.speedY = random.Next(1, 10);
                ball.ballColor = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
            }
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e) { this.pictureBox1.Refresh(); }
        public void populate()
        {
            int size = 50;
            for(int i = 0; i < 10; i++)
            {
                int startX = random.Next(0, this.pictureBox1.Width / 2);
                int startY = random.Next(0, this.pictureBox1.Height / 2);
                int speedX = random.Next(1, 10);
                int speedY = random.Next(1, 10);
                SolidBrush color = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));

                list.Add(new Ball(size, size, startX, startY, speedX, speedY, color, this.pictureBox1));
            }
            
        }
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Ball ball in list)
            {
                ball.Update();
                ball.Draw(g);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Hello! Welcome to Statistics!";
        }
    }
}
