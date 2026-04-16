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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
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
    }
}
