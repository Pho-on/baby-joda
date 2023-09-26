using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Small3x3
    {
        private int size = 150;

        public Small3x3(int x, int y)
        {
            Padding margin = new Padding(0, 0, 0, 0);
            flp = new FlowLayoutPanel()
            {
                Width = size,
                Height = size,
                BackColor = Color.DimGray,
                Margin = margin,
                Location = new Point(x, y)
            };
        }

        public FlowLayoutPanel flp
        {
            get; set;
        }

        public int Size
        {
            get
            {
                return size;

            }
            set
            {
                size = value;
            }
        }
    }
}
