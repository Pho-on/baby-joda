using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UltimateTicTacToe
{
    /*
     - Gör en klasser 
        - en för varje liten ruta (81st)
           - pbx, bool träff (är rutan använd), bool isCircle (cross eller cirkle)
        - en för varje 3x3 (är hela ifyld, isf vem vann)
        - en för hela planen (vilken är den nästa 3x3, vem van totalt)
    */

    public partial class Form : System.Windows.Forms.Form
    {
        Square square;
        Small3x3 small3x3;

        bool circleTurn = true;

        public Form()
        {
            InitializeComponent();

            MakePlayingBoard();
        }

        void MakePlayingBoard()
        {
            int xPos;
            int yPos;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        xPos = (x * 150) + (5 * (x + 1));
                        yPos = (y * 150) + (5 * (y + 1));
                    }
                    else if (x == 0 && y == 1)
                    {
                        xPos = (x * 150) + (5 * (x + 1));
                        yPos = (y * 150) + (2 * (y + 1) + 3);
                    }
                    else if (x == 0 && y == 2)
                    {
                        xPos = (x * 150) + (5 * (x + 1));
                        yPos = (y * 150) + (2 * (y + 1) + 3);
                    }
                    else if (x == 1 && y == 0)
                    {
                        xPos = (x * 150) + (2 * (x + 1) + 3);
                        yPos = (y * 150) + (5 * (y + 1));
                    }
                    else if (x == 2 && y == 0)
                    {
                        xPos = (x * 150) + (2 * (x + 1) + 3);
                        yPos = (y * 150) + (5 * (y + 1));
                    }
                    else
                    {
                        xPos = (x * 150) + (2 * (x + 1) + 3);
                        yPos = (y * 150) + (2 * (y + 1) + 3);
                    }

                    small3x3 = new Small3x3(xPos, yPos);
                    this.Controls.Add(small3x3.flp);
                }
            }

            foreach (var flp in this.Controls.OfType<FlowLayoutPanel>())
            {
                for (int i = 0; i < 9; i++)
                {
                    square = new Square();
                    square.pbx.Click += PictureBoxClick;
                    flp.Controls.Add(square.pbx);
                }
            }
        }

        void PictureBoxClick(object sender, EventArgs e)
        {
            // behöver något för att hitta vilken pbx som klickats

            if (!square.IsUsed)
            {
                square.IsUsed = false;
                square.CircleTurn = circleTurn;
                if (circleTurn)
                {
                    circleTurn = false;
                }
                else
                {
                    circleTurn = true;
                }
            }
        }
    }
}
