﻿using System.Drawing;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Square : PictureBox
    {
        private int size = 48;

        public Square(int index, int parentIndex)
        {
            this.Index = index;
            this.ParentIndex = parentIndex;

            Width = size;
            Height = size;
            BackColor = Color.White;
            Margin = new Padding(1, 1, 1, 1);
            Enabled = true;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int Index { get; set; }

        public int ParentIndex { get; set; }

        public bool IsUsed { get; set; }

        public bool IsCircle { get; set; }
    }
}
