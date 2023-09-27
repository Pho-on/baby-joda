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
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    small3x3 = new Small3x3(FlpPosX(x, y), FlpPosY(x, y));
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
                if (circleTurn)
                {
                    square.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
                    circleTurn = false;
                }
                else
                {
                    square.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");
                    circleTurn = true;
                }
                square.IsUsed = true;
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
    }
}
