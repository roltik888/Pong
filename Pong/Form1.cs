using System.Drawing.Drawing2D;
using System.Numerics;

namespace Pong
{
    public partial class Form1 : Form
    {
        int PlayerY = 150;
        int AiY = 150;

        int BallX = 200;
        int BallY = 150;

        int BallspeedY = 4;
        int BallspeedX = 4;

        int PlayerScore = 0;
        int AiScore = 0;

        bool moveUP, moveDOWN;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 20;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (moveUP && PlayerY > 0) PlayerY -= 6;
            if (moveDOWN && PlayerY < this.ClientSize.Height -80) PlayerY += 6;
            if (AiY + 40 < BallY) AiY += 2;
            if (AiY + 40 > BallY) AiY -= 2;
            BallX += BallspeedX;
            BallY += BallspeedY;
            if (BallY <= 0 || BallY >= this.ClientSize.Height - 10) BallspeedY *= -1;
            Rectangle playerRect = new Rectangle(10, PlayerY, 10, 80);
            Rectangle ballRect = new Rectangle(BallX, BallY, 10, 10);
            if (playerRect.IntersectsWith(ballRect)) BallspeedX = Math.Abs(BallspeedX);
            Rectangle aiRect = new Rectangle(this.ClientSize.Width - 20, AiY, 10, 80);
            if (aiRect.IntersectsWith(ballRect)) BallspeedX = -Math.Abs(BallspeedX);
            if (BallX < 0)
            {
                AiScore++;
                ResetBall();
            }
            if (BallX > this.ClientSize.Width)
            {
                PlayerScore++;
                ResetBall();
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, 10, PlayerY, 10, 80);
            g.FillRectangle(Brushes.White, this.ClientSize.Width - 20, AiY, 10, 80);
            g.FillEllipse(Brushes.White, BallX, BallY, 10, 10);
            g.DrawString($"Gracz: {PlayerScore}", new Font("Arial", 12), Brushes.White, 50, 10);
            g.DrawString($"Ai: {AiScore}", new Font("Arial", 12), Brushes.White, 400, 10);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) moveDOWN = true;
            if (e.KeyCode == Keys.Up) moveUP = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) moveDOWN = false;
            if (e.KeyCode == Keys.Up) moveUP = false;
            
        }
        private void ResetBall()
        {
            if (BallX < 0)
            {
                BallspeedX *= -1;
                BallX = this.ClientSize.Width / 2;
                BallY = this.ClientSize.Height / 2;
            }
            if (BallX > this.ClientSize.Width)
            {
                BallspeedX *= -1;
                BallX = this.ClientSize.Width / 2;
                BallY = this.ClientSize.Height / 2;
            } 
        }
    }
}
