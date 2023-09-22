using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    public partial class Form : System.Windows.Forms.Form
    {
        List<int[]> usedSquares = new List<int[]>();
        List<int> playableGrids = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int spaceBetweenTargets = 51;
        int targetSize = 48;    // storlke på markörerna
        int turn = 0;           // 0 == Circle, 1 == Cross
        int gridPosX;           // vilken box i x-led
        int gridPosY;           // vilken box i y-led
        int targetStartPosX;    // vilket x-värde markören ska placeras på
        int targetStartPosY;    // vilket y-värde markören ska placeras på

        public Form()
        {
            InitializeComponent();

            pbxPlayingBoard.SendToBack();
        }

        private void pbxPlayingBoard_MouseClick(object sender, MouseEventArgs e)
        {
            CalculateSquare(e.X, e.Y);
            int[] placedSquare = { gridPosX, gridPosY };     // placera den använda rutan i en array
            usedSquares.Add(placedSquare);                   // lägg en array med den använda rutan i en lista 

            PlaceTarget(targetStartPosX, targetStartPosY);
            
            Next3x3(gridPosX, gridPosY);
        }


        void CalculateSquare(int mouseX, int mouseY)
        {
            double findBox = 472 / 9;
            gridPosX = (int)(mouseX / findBox);
            gridPosY = (int)(mouseY / findBox);

            targetStartPosX = FindStartPosX(gridPosX);
            targetStartPosY = FindStartPosY(gridPosY);
        }

        void makeCircle(int xPos, int yPos)
        {
            Bitmap circle = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");

            var Circle = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White,
                Size = new Size(targetSize, targetSize),
                Location = new Point(xPos, yPos),
                Image = circle,
            };

            this.Controls.Add(Circle);
            Circle.BringToFront();
        }

        void makeCross(int xPos, int yPos)
        {
            Bitmap cross = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");

            var Cross = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White,
                Size = new Size(targetSize, targetSize),
                Location = new Point(xPos, yPos),
                Image = RotateImage(cross, 45),
            };

            this.Controls.Add(Cross);
            Cross.BringToFront();
        }

        int FindStartPosX(int posX)
        {
            int targetPosX;

            if (posX >= 0 && posX <= 2)
            {
                targetPosX = (posX * 51) + 4;
            }
            else if (posX >= 3 && posX <= 5)
            {
                targetPosX = (posX * 51) + 7;
            }
            else if (posX == 8)
            {
                targetPosX = (posX * 51) + 11;
            }
            else
            {
                targetPosX = (posX * 51) + 10;
            }

            return targetPosX;
        }

        int FindStartPosY(int posY)
        {
            int targetPosY;

            if (posY >= 0 && posY <= 2)
            {
                targetPosY = (posY * 51) + 4;
            }
            else if (posY >= 3 && posY <= 5)
            {
                targetPosY = (posY * 51) + 7;
            }
            else if (posY == 8)
            {
                targetPosY = (posY * 51) + 11;
            }
            else
            {
                targetPosY = (posY * 51) + 10;
            }

            return targetPosY;
        }

        void Next3x3(int gridPosX, int gridPosY)
        {
            if ((gridPosX == 0 || gridPosX == 3 || gridPosX == 6) && (gridPosY == 0 || gridPosY == 3 || gridPosY == 6))
            {
                playableGrids = new List<int> { 1 };
            }
            else if ((gridPosX == 1 || gridPosX == 4 || gridPosX == 7) && (gridPosY == 0 || gridPosY == 3 || gridPosY == 6))
            {
                playableGrids = new List<int> { 2 };
            }
            else if ((gridPosX == 2 || gridPosX == 5 || gridPosX == 8) && (gridPosY == 0 || gridPosY == 3 || gridPosY == 6))
            {
                playableGrids = new List<int> { 3 };
            }
            else if ((gridPosX == 0 || gridPosX == 3 || gridPosX == 6) && (gridPosY == 1 || gridPosY == 4 || gridPosY == 7))
            {
                playableGrids = new List<int> { 4 };
            }
            else if ((gridPosX == 1 || gridPosX == 4 || gridPosX == 7) && (gridPosY == 1 || gridPosY == 4 || gridPosY == 7))
            {
                playableGrids = new List<int> { 5 };
            }
            else if ((gridPosX == 2 || gridPosX == 5 || gridPosX == 8) && (gridPosY == 1 || gridPosY == 4 || gridPosY == 7))
            {
                playableGrids = new List<int> { 6 };
            }
            else if ((gridPosX == 0 || gridPosX == 3 || gridPosX == 6) && (gridPosY == 2 || gridPosY == 5 || gridPosY == 8))
            {
                playableGrids = new List<int> { 7 };
            }
            else if ((gridPosX == 1 || gridPosX == 4 || gridPosX == 7) && (gridPosY == 2 || gridPosY == 5 || gridPosY == 8))
            {
                playableGrids = new List<int> { 8 };
            }
            else if ((gridPosX == 2 || gridPosX == 5 || gridPosX == 8) && (gridPosY == 2 || gridPosY == 5 || gridPosY == 8))
            {
                playableGrids = new List<int> { 9 };
            }
        }


        void PlaceTarget(int xPos, int yPos)
        {
            if (turn == 0)
            {
                makeCircle(xPos, yPos);
                turn = 1;
            }
            else
            {
                makeCross(xPos, yPos);
                turn = 0;
            }
        }

        public Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            PointF offset = new PointF(600, 600);
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics g = Graphics.FromImage(rotatedImage);

            g.TranslateTransform(offset.X, offset.Y);

            g.RotateTransform(angle);

            g.TranslateTransform(-offset.X, -offset.Y);

            g.DrawImage(image, new PointF(0, 0));

            return rotatedImage;
        }

        bool Is3x3Full()
        {
            if (playableGrids[0] == { 0, 0 })
            {

            }
            
        }
    }
}
