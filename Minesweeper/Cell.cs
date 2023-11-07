using System.Windows.Forms;

namespace Minesweeper
{

    class Cell : PictureBox
    {
        public enum Type
        {
            Empty,
            Mine,
            Number
        }

        public Type type;
        public int row;
        public int column;
        public int number;
        public bool revealed;
        public bool flagged;
        public bool exploded;
    }
}
