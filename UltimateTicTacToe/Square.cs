using System;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Square : PictureBox
    {
        private int size = 48;

        public Square()
        {
            Width = size;
            Height = size;
            BackColor = Color.White;
            Margin = new Padding(1, 1, 1, 1);
            Enabled = true;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int Index { get; set; }

        public int ParentIndex { get; set; }
    }
}
