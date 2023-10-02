using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

            WichPicture(pbx);
            Next3x3(pbx.Index);
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

        void WichPicture(Square pbx)
        {
            if (circleTurn)
            {
                pbx.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
                circleTurn = false;
            }
            else
            {
                pbx.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");
                circleTurn = true;
            }

            pbx.IsUsed = true;
            pbx.Enabled = false;
        }

        void Next3x3(int index)
        {
            bool isUsed = false;

            foreach (Square square in this.Controls.OfType<Square>())
            {
                if (square.ParentIndex == index)
                {
                    if (square.IsUsed == false)
                    {
                        isUsed = false;
                    }
                    else
                    {
                        isUsed = true;
                    }
                }
            }

            foreach (Small3x3 small3x3 in this.Controls.OfType<Small3x3>())
            {
                if (isUsed)
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
    }
}

