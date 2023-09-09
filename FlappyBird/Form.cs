using System;
using System.Drawing;
using System.Threading;

namespace FlappyBird
{

    public partial class Form : System.Windows.Forms.Form
    {
        int gameSpeed = 5;

        public Form()
        {
            InitializeComponent();

            Bitmap bird = new Bitmap(@"C:\Repos\baby-joda\FlappyBird\Images\bird.png");
            bird.MakeTransparent();
            pbxBird.Image = bird;

            Bitmap bottomPipe = new Bitmap(@"C:\Repos\baby-joda\FlappyBird\Images\pipe.png");
            bottomPipe.MakeTransparent();
            pbxBottomPipe.Image = bottomPipe;

            Bitmap topPipe = new Bitmap(@"C:\Repos\baby-joda\FlappyBird\Images\pipe.png");
            topPipe.MakeTransparent();
            topPipe.RotateFlip(RotateFlipType.Rotate180FlipX);
            pbxTopPipe.Image = topPipe;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (pbxGround.Location.X == -700)
            {
                pbxGround.Location = new Point(0, 449);
            }
            else
            {
                pbxGround.Left -= gameSpeed;
            }

            pbxTopPipe.Left -= gameSpeed;
            pbxBottomPipe.Left -= gameSpeed;
        }
    }
}

