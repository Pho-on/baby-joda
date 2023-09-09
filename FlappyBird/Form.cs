using System;
using System.Drawing;
using System.Threading;

namespace FlappyBird
{
    public partial class Form : System.Windows.Forms.Form
    {
        int gameSpeed = 5;
        int gravity = 5;

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

            Bitmap bottomPipe2 = new Bitmap(@"C:\Repos\baby-joda\FlappyBird\Images\pipe.png");
            bottomPipe2.MakeTransparent();
            pbxBottomPipe2.Image = bottomPipe2;

            Bitmap topPipe2 = new Bitmap(@"C:\Repos\baby-joda\FlappyBird\Images\pipe.png");
            topPipe2.MakeTransparent();
            topPipe2.RotateFlip(RotateFlipType.Rotate180FlipX);
            pbxTopPipe2.Image = topPipe2;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!GameOver())
            {
                if (pbxGround.Location.X == -700)
                {
                    pbxGround.Location = new Point(0, 449);
                }
                else
                {
                    pbxGround.Left -= gameSpeed;
                }

                if (pbxTopPipe.Location.X == 200)
                {
                    pbxTopPipe2.Visible = true;
                    pbxBottomPipe2.Visible = true;
                    pbxTopPipe2.Location = new Point(800, setPipes());
                    pbxBottomPipe2.Location = new Point(800, (setPipes() + 750));
                }

                if (pbxTopPipe2.Location.X == 200)
                {
                    pbxTopPipe.Location = new Point(800, setPipes());
                    pbxBottomPipe.Location = new Point(800, (setPipes() + 750));
                }

                pbxBird.Top += gravity;
                pbxTopPipe.Left -= gameSpeed;
                pbxBottomPipe.Left -= gameSpeed;
                pbxTopPipe2.Left -= gameSpeed;
                pbxBottomPipe2.Left -= gameSpeed;
            }
            else
            {
                Console.WriteLine("Hit" + Environment.NewLine);
            }   
        }

        int setPipes()
        {
            Random random = new Random();
            int pipePosY = random.Next(-540, -310);

            return pipePosY;
        }

        private void Form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            gravity = -12;
        }

        private void Form_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Thread.Sleep(75);
            gravity = 5;
        }

        bool GameOver()
        {
            if (pbxBird.Location.Y + 55 >= pbxGround.Location.Y)
            {
                return true;
            }
            else if (pbxBird.Location.Y <= 0)
            {
                return true;
            }
            else if (pbxBird.Location.X >= pbxBottomPipe.Location.X && pbxBird.Location.X + 75 <= pbxBottomPipe.Location.X + 90 && pbxBird.Location.Y + 55 >= pbxBottomPipe.Location.Y)
            {
                return true;
            }
            else if (pbxBird.Location.X >= pbxTopPipe.Location.X && pbxBird.Location.X + 75 <= pbxTopPipe.Location.X + 90 && pbxBird.Location.Y <= pbxTopPipe.Location.Y + 600)
            {
                return true;
            }
            else if (pbxBird.Location.X >= pbxBottomPipe2.Location.X && pbxBird.Location.X + 75 <= pbxBottomPipe2.Location.X + 90 && pbxBird.Location.Y + 55 >= pbxBottomPipe2.Location.Y)
            {
                return true;
            }
            else if (pbxBird.Location.X >= pbxTopPipe2.Location.X && pbxBird.Location.X + 75 <= pbxTopPipe2.Location.X + 90 && pbxBird.Location.Y <= pbxTopPipe2.Location.Y + 600)
            {
                return true;
            }

            return false;
        }
    }
}

