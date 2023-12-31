﻿using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;

namespace FlappyBird
{
    public partial class Form : System.Windows.Forms.Form
    {
        int gameSpeed = 5;
        int gravity = 5;
        int startPosPipes = 800;
        int points = 0;
        int maxPoints = 0;
        bool runGame = false;

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

            Bitmap ground = new Bitmap(@"C:\Repos\baby-joda\FlappyBird\Images\gound.png");
            pbxGround.Image = ground;
            pbxGround.BringToFront();

            int yPos = setPipes();
            pbxTopPipe.Location = new Point(startPosPipes, yPos);
            pbxBottomPipe.Location = new Point(startPosPipes, (yPos + 775));
            pbxTopPipe2.Location = new Point((startPosPipes + 100), yPos);
            pbxBottomPipe2.Location = new Point((startPosPipes + 100), yPos + 775);

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            RunGame();

            if (GameOver())
            {
                runGame = false;
            }
        }

        int setPipes()
        {
            Random random = new Random();
            int pipePosY = random.Next(-540, -335);

            return pipePosY;
        }

        private void Form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            gravity = -12;
            runGame = true;
            if (GameOver())
            {
                RestartGame();
                runGame = true;
            }
        }

        private void Form_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Thread.Sleep(75);
            gravity = 5;
        }

        void RunGame()
        {
            if (!GameOver() && runGame)
            {
                GamePhysics();
                CountPoints();
            } 
        }

        void GamePhysics()
        {
            pbxBird.Top += gravity;
            pbxTopPipe2.Left -= gameSpeed;
            pbxBottomPipe2.Left -= gameSpeed;
            pbxTopPipe.Left -= gameSpeed;
            pbxBottomPipe.Left -= gameSpeed;

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
                int yPos = setPipes();
                pbxTopPipe2.Visible = true;
                pbxBottomPipe2.Visible = true;
                pbxTopPipe2.Location = new Point(startPosPipes, yPos);
                pbxBottomPipe2.Location = new Point(startPosPipes, (yPos + 775));
            }

            if (pbxTopPipe2.Location.X == 200)
            {
                int yPos = setPipes();
                pbxTopPipe.Location = new Point(startPosPipes, yPos);
                pbxBottomPipe.Location = new Point(startPosPipes, (yPos + 775));
            }
        }

        bool GameOver()
        {
            if (pbxBird.Bounds.IntersectsWith(pbxGround.Bounds))
            {
                return true;
            }
            else if (pbxBird.Location.Y <= 0)
            {
                return true;
            }
            else if (pbxBird.Bounds.IntersectsWith(pbxBottomPipe.Bounds))
            {
                return true;
            }
            else if (pbxBird.Bounds.IntersectsWith(pbxTopPipe.Bounds))
            {
                return true;
            }
            else if (pbxBird.Bounds.IntersectsWith(pbxBottomPipe2.Bounds))
            {
                return true;
            }
            else if (pbxBird.Bounds.IntersectsWith(pbxTopPipe2.Bounds))
            {
                return true;
            }

            return false;
        }

        void RestartGame()
        {
            int yPos1 = setPipes();
            int yPos2 = setPipes();
            pbxBird.Location = new Point(145, 195);
            pbxBottomPipe.Location = new Point(startPosPipes, (yPos1 + 775));
            pbxTopPipe.Location = new Point(startPosPipes, yPos1);
            pbxBottomPipe2.Location = new Point(startPosPipes, (yPos2 + 775));
            pbxTopPipe2.Location = new Point(startPosPipes, yPos2);

            points = 0;
            runGame = false;
        }

        void CountPoints()
        {
            if (pbxBird.Location.X == (pbxTopPipe.Location.X + 90) || pbxBird.Location.X == (pbxTopPipe2.Location.X + 90))
            {
                points++;
                if (points <= maxPoints)
                {
                    maxPoints = maxPoints;
                }
                else
                {
                    maxPoints = points;
                }
                Console.WriteLine("Score: " + points + ", Max score: " + maxPoints);
            }
        }
    }
}

