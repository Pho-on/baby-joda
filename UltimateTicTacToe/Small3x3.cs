using System.Drawing;
using System.Windows.Forms;

namespace UltimateTicTacToe
{

    internal class Small3x3
    {
        private int size = 150;
        private int tabIndex;

        public Small3x3(int x, int y)
        {
            Padding margin = new Padding(0, 0, 0, 0);
            FlowLayoutPanel = new FlowLayoutPanel()
            {
                Width = size,
                Height = size,
                BackColor = Color.DimGray,
                Margin = margin,
                Location = new Point(x, y),
                TabIndex = tabIndex
            };
        }

        public FlowLayoutPanel FlowLayoutPanel
        {
            get; set;
        }

        public int TabIndex
        {
            get
            {
                return tabIndex;
            }
            set
            {
                tabIndex = value;
            }
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
