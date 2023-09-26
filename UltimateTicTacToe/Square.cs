using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Square
    {
        private int size = 48;
        private bool circleTurn;
        private bool isUsed = false;
        private Bitmap image;

        public Square()
        {
            Padding margin = new Padding(1, 1, 1, 1);
            pbx = new PictureBox()
            { 
                Width = size,
                Height = size,
                BackColor = Color.White,
                Image = WichImage(),
                Margin = margin
            };
        }

        public PictureBox pbx
        {
            get; set;
        }

        private Bitmap WichImage()
        {
            if (isUsed)
            {
                if (circleTurn)
                {
                    return new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
                }
                else
                {
                    return new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");
                }
            }

            return null;
        }

        public bool CircleTurn
        {
            get
            {
                return circleTurn;
            }
            set
            {
                circleTurn = value;
            }
        }

        public bool IsUsed
        {
            get
            {
                return isUsed;
            }
            set
            {
                isUsed = value;
            }
        }
    }
}
