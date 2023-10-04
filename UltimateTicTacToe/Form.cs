using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace UltimateTicTacToe
{
    /*
     - Gör en klasser 
        - en för varje liten ruta (81st)
           - pbx, bool träff (är rutan använd), index för varje box i flp (1-9 per flp)
        - en för varje 3x3 (är hela ifyld, isf vem vann), index för varje flp (1-9)
        - en för hela planen (vilken är den nästa 3x3, vem van totalt)
    */

    public partial class Form : System.Windows.Forms.Form
    {
        Square square;
        Small3x3 small3x3;

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
            Next3x3(pbx.Index);
            IsWin(pbx.ParentIndex);
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

        void Next3x3(int index)
        {
            bool is3x3Full = false;

            foreach (Small3x3 small3x3 in this.Controls.OfType<Small3x3>())
            {
                if (small3x3.Index == index)
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

                if (is3x3Full)
                {
                    if (small3x3.Index == index)
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

        void IsWin(int parenIndex)
        {
            bool circleWin = false;
            bool crossWin = false;

            List<int> circle = new List<int>();
            List<int> cross = new List<int>();

            foreach (Small3x3 small3x3 in this.Controls.OfType<Small3x3>())
            {
                if (small3x3.Index == parenIndex)
                {
                    foreach(Square square in small3x3.Controls)
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

            if (circleWin)
            {
                Console.WriteLine("CIRCLE WIN");
            }

            if (crossWin)
            {
                Console.WriteLine("CROSS WIN");
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

