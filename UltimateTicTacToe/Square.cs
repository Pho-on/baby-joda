using System.Drawing;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Square
    {
        private int size = 48;
        private bool isUsed = false;
        private Bitmap image = null;
        private string name;

        public Square()
        {
            Padding margin = new Padding(1, 1, 1, 1);
            pbx = new PictureBox()
            {
                Width = size,
                Height = size,
                BackColor = Color.White,
                Image = image,
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

        public Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
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
