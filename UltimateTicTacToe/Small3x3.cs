using System.Drawing;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Small3x3 : FlowLayoutPanel
    {
        private int size = 150;
        private int x;
        private int y;

        public Small3x3(int x, int y, int index)
        {
            this.Index = index;
            this.x = x;
            this.y = y;

            Width = size;
            Height = size;
            BackColor = Color.DimGray;
            Margin = new Padding(0, 0, 0, 0);
            Location = new Point(x, y);
            Enabled = true;
        }

        public int Index { get; set; }

        public Color BorderColor { get; set; }

        public void DrawBorder(Graphics g)
        {
            Pen borderColor = new Pen(BorderColor, 3);
            Rectangle border = new Rectangle(x, y, size - 1, size - 1);

            g.DrawRectangle(borderColor, border);
        }
    }
}
