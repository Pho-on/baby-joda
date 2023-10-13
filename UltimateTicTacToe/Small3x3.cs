using System.Drawing;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Small3x3 : FlowLayoutPanel
    {
        private int size = 150;
        private Color color = Color.DimGray;

        public Small3x3(int x, int y, int index)
        {
            this.Index = index;
            this.Border = color;

            Width = size;
            Height = size;
            BackColor = Color.DimGray;
            Margin = new Padding(0, 0, 0, 0);
            Location = new Point(x, y);
            Enabled = true;
        }

        public int Index { get; set; }

        public Color Border { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen boarderColor = new Pen(color, 3);
            Rectangle boarder = new Rectangle(0, 0, size - 1, size - 1);

            e.Graphics.DrawRectangle(boarderColor, boarder);
        }
    }
}
