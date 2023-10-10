using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    public partial class Form : System.Windows.Forms.Form
    {
        Square square;
        Small3x3 small3x3;

        List<int> finished3x3 = new List<int>();
        List<int> bigCircle = new List<int>();
        List<int> bigCross = new List<int>();

        bool circleTurn;

        public Form()
        {
            InitializeComponent();

            MakePlayingBoard();
            circleTurn = WhoStarts();
        }

        void MakePlayingBoard()
        {
            int i = 1;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    small3x3 = new Small3x3(FlpPosX(x, y), FlpPosY(x, y), i);
                    this.Controls.Add(small3x3);

                    for (int j = 0; j < 9; j++)
                    {
                        square = new Square((j + 1), i);
                        square.Click += PictureBoxClick;
                        small3x3.Controls.Add(square);
                    }
                    i++;
                }
            }
        }

        void PictureBoxClick(object sender, EventArgs e)
        {
            var pbx = (sender as Square);

            WhosTurn(pbx);
            IsWinSmall3x3(pbx.ParentIndex);
            Next3x3(pbx.Index);
            WinGame();
        }

        void WhosTurn(Square pbx)
        {
            if (circleTurn)
            {
                pbx.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
                pbx.IsCircle = true;
                circleTurn = false;
            }
            else
            {
                pbx.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");
                pbx.IsCircle = false;
                circleTurn = true;
            }

            pbx.IsUsed = true;
            pbx.Enabled = false;
        }

        void IsWinSmall3x3(int parenIndex)
        {
            bool circleWin = false;
            bool crossWin = false;

            List<int> circle = new List<int>();
            List<int> cross = new List<int>();

            foreach (Small3x3 small3x3 in this.Controls.OfType<Small3x3>())
            {
                if (small3x3.Index == parenIndex)
                {
                    foreach (Square square in small3x3.Controls)
                    {
                        if (square.IsUsed)
                        {
                            if (square.IsCircle)
                            {
                                circle.Add(square.Index);
                            }
                            if (!square.IsCircle)
                            {
                                cross.Add(square.Index);
                            }
                        }
                    }
                }
            }

            if (circle.Contains(1) && circle.Contains(2) && circle.Contains(3)) { circleWin = true; }
            if (circle.Contains(4) && circle.Contains(4) && circle.Contains(6)) { circleWin = true; }
            if (circle.Contains(7) && circle.Contains(8) && circle.Contains(9)) { circleWin = true; }

            if (circle.Contains(1) && circle.Contains(4) && circle.Contains(7)) { circleWin = true; }
            if (circle.Contains(2) && circle.Contains(5) && circle.Contains(8)) { circleWin = true; }
            if (circle.Contains(3) && circle.Contains(6) && circle.Contains(9)) { circleWin = true; }

            if (circle.Contains(1) && circle.Contains(5) && circle.Contains(9)) { circleWin = true; }
            if (circle.Contains(3) && circle.Contains(5) && circle.Contains(7)) { circleWin = true; }

            if (cross.Contains(1) && cross.Contains(2) && cross.Contains(3)) { crossWin = true; }
            if (cross.Contains(4) && cross.Contains(4) && cross.Contains(6)) { crossWin = true; }
            if (cross.Contains(7) && cross.Contains(8) && cross.Contains(9)) { crossWin = true; }

            if (cross.Contains(1) && cross.Contains(4) && cross.Contains(7)) { crossWin = true; }
            if (cross.Contains(2) && cross.Contains(5) && cross.Contains(8)) { crossWin = true; }
            if (cross.Contains(3) && cross.Contains(6) && cross.Contains(9)) { crossWin = true; }

            if (cross.Contains(1) && cross.Contains(5) && cross.Contains(9)) { crossWin = true; }
            if (cross.Contains(3) && cross.Contains(5) && cross.Contains(7)) { crossWin = true; }

            if (circleWin || crossWin)
            {
                finished3x3.Add(parenIndex);
                WinSmall3x3(circleWin, crossWin, parenIndex);
            }
        }

        void Next3x3(int index)
        {
            foreach (Small3x3 small3x3 in this.Controls.OfType<Small3x3>())
            {
                bool is3x3Full = false;

                if (small3x3.Index == index)
                {
                    if (!finished3x3.Contains(index))
                    {
                        foreach (Square square in small3x3.Controls)
                        {
                            if (square.IsUsed == false)
                            {
                                is3x3Full = false;
                                break;
                            }
                            else
                            {
                                is3x3Full = true;
                            }
                        }
                    }
                }

                if (is3x3Full)
                {
                    finished3x3.Add(small3x3.Index);
                }

                if (finished3x3.Contains(index))
                {
                    if (small3x3.Index == index)
                    {
                        small3x3.Enabled = false;
                    }
                    else if (finished3x3.Contains(small3x3.Index))
                    {
                        small3x3.Enabled = false;
                    }
                    else
                    {
                        small3x3.Enabled = true;
                    }
                }
                else
                {
                    if (small3x3.Index == index)
                    {
                        small3x3.Enabled = true;
                    }
                    else
                    {
                        small3x3.Enabled = false;
                    }
                }
            }
        }

        void WinSmall3x3(bool circleWin, bool crossWin, int index)
        {
            Bitmap image = null;

            if (circleWin)
            {
                image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
                bigCircle.Add(index);
            }

            if (crossWin)
            {
                image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");
                bigCross.Add(index);
            }

            PictureBox pbx = new PictureBox
            {
                BackColor = Color.White,
                Image = image,
                Width = 148,
                Height = 148,
                Enabled = false,
                Margin = new Padding(1, 1, 1, 1),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            foreach (Small3x3 small3x3 in this.Controls.OfType<Small3x3>())
            {
                if (small3x3.Index == index)
                {
                    small3x3.Controls.Clear();
                    small3x3.Controls.Add(pbx);
                }
            }
        }

        void WinGame()
        {
            bool win = false;

            if (bigCircle.Count() >= 3 || bigCross.Count() <= 3)
            {
                if (bigCircle.Contains(1) && bigCircle.Contains(2) && bigCircle.Contains(3)) { win = true; }
                if (bigCircle.Contains(4) && bigCircle.Contains(4) && bigCircle.Contains(6)) { win = true; }
                if (bigCircle.Contains(7) && bigCircle.Contains(8) && bigCircle.Contains(9)) { win = true; }

                if (bigCircle.Contains(1) && bigCircle.Contains(4) && bigCircle.Contains(7)) { win = true; }
                if (bigCircle.Contains(2) && bigCircle.Contains(5) && bigCircle.Contains(8)) { win = true; }
                if (bigCircle.Contains(3) && bigCircle.Contains(6) && bigCircle.Contains(9)) { win = true; }

                if (bigCircle.Contains(1) && bigCircle.Contains(5) && bigCircle.Contains(9)) { win = true; }
                if (bigCircle.Contains(3) && bigCircle.Contains(5) && bigCircle.Contains(7)) { win = true; }

                if (bigCross.Contains(1) && bigCross.Contains(2) && bigCross.Contains(3)) { win = true; }
                if (bigCross.Contains(4) && bigCross.Contains(4) && bigCross.Contains(6)) { win = true; }
                if (bigCross.Contains(7) && bigCross.Contains(8) && bigCross.Contains(9)) { win = true; }

                if (bigCross.Contains(1) && bigCross.Contains(4) && bigCross.Contains(7)) { win = true; }
                if (bigCross.Contains(2) && bigCross.Contains(5) && bigCross.Contains(8)) { win = true; }
                if (bigCross.Contains(3) && bigCross.Contains(6) && bigCross.Contains(9)) { win = true; }

                if (bigCross.Contains(1) && bigCross.Contains(5) && bigCross.Contains(9)) { win = true; }
                if (bigCross.Contains(3) && bigCross.Contains(5) && bigCross.Contains(7)) { win = true; }
            }

            if (win)
            {
                Thread.Sleep(5000);

                this.Controls.Clear();

                InitializeComponent();

                MakePlayingBoard();
                circleTurn = WhoStarts();
            }

        }
        bool WhoStarts()
        {
            Random random = new Random();

            if (random.Next(0, 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int FlpPosX(int x, int y)
        {
            int xPos;
            int size = 150;

            if ((x == 0 && y == 0) || (x == 0 && y == 1) || (x == 0 && y == 2))
            {
                xPos = (x * size) + (5 * (x + 1));
            }
            else
            {
                xPos = (x * size) + (2 * (x + 1) + 3);
            }
            return xPos;
        }

        int FlpPosY(int x, int y)
        {
            int yPos;
            int size = 150;

            if ((x == 0 && y == 0) || (x == 1 && y == 0) || (x == 2 && y == 0))
            {
                yPos = (y * size) + (5 * (y + 1));
            }
            else
            {
                yPos = (y * size) + (2 * (y + 1) + 3);
            }
            return yPos;
        }
    }
}

