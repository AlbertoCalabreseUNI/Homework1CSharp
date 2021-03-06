using System;
using System.Windows.Forms;
using System.Drawing;

namespace First
{
    public class Ball
    {
        public int width { get; set; }
        public int height { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int speedX { get; set; }
        public int speedY { get; set; }
        public Brush ballColor { get; set; }
        private Pen borderColor = Pens.Black;
        private PictureBox pictureBox;

        public Ball(int w, int h, int x, int y, int sX, int sY, Brush color, PictureBox pb)
        {
            this.width = w;
            this.height = h;
            this.posX = x;
            this.posY = y;
            this.speedX = sX;
            this.speedY = sY;
            this.ballColor = color;
            this.pictureBox = pb;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(this.ballColor, this.posX, this.posY, this.width, this.height);
            g.DrawEllipse(this.borderColor, this.posX, this.posY, this.width, this.height);
        }

        public void Update()
        {
            this.posX += this.speedX;
            this.posY += this.speedY;
            if(this.posX < 0 || this.posX + this.width > this.pictureBox.Width)
                this.speedX = -this.speedX;
            if (this.posY < 0 || this.posY + this.height > this.pictureBox.Height)
                this.speedY = -this.speedY;
        }
    }
}
