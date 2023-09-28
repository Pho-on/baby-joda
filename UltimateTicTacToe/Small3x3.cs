using System.Drawing;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Small3x3 : FlowLayoutPanel
    {
        private int size = 150;

        public Small3x3(int x, int y, int index)
        {
            this.Index = index;

            Width = size;
            Height = size;
            BackColor = Color.DimGray;
            Margin = new Padding(0, 0, 0, 0);
            Location = new Point(x, y);
            Enabled = true;
        }

        public int Index { get; set; }
    }
}
