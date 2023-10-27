using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{

    public partial class Form : System.Windows.Forms.Form
    {

        PictureBox[,] pixtureBoxGrid;

        GameState gameState = new GameState();

        public Form()
        {
            InitializeComponent();
            pixtureBoxGrid = SetupPictureBoxGrid(gameState.GameGrid);

            topDiv.SendToBack();
        }

        PictureBox[,] SetupPictureBoxGrid(GameGrid grid)
        {
            PictureBox[,] pictureBoxGrid = new PictureBox[grid.Rows, grid.Columns];
            int pbxSize = 30;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    PictureBox pbx = new PictureBox
                    {
                        BackColor = Color.Black,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = pbxSize,
                        Height = pbxSize,
                        Location = new Point(pbxSize * c, pbxSize * r + 45),
                    };

                    pbx.Click += PictureBox_Click;
                    Controls.Add(pbx);
                    pictureBoxGrid[r, c] = pbx;
                }
            }

            return pictureBoxGrid;
        }

        void PictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
