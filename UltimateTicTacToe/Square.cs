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
        private string name;

        public Square()
        {
            Padding margin = new Padding(1, 1, 1, 1);
            pbx = new PictureBox()
            {
                Width = size,
                Height = size,
                BackColor = Color.White,
                Image = WichImage(),
                Margin = margin,
                Name = name
            };
        }

        public PictureBox pbx
        {
            get; set;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        } 

        private Bitmap WichImage()
        {
            if (isUsed)
            {
                if (circleTurn)
                {
                    return new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
                    circleTurn = false;
                }
                else
                {
                    return new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");
                    circleTurn = true;
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
