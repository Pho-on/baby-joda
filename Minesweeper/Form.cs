using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{

    public partial class Form : System.Windows.Forms.Form
    {

        readonly Bitmap[] tileImages = new Bitmap[]
        {
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileUnknown.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile1.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile2.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile3.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile4.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile5.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile6.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile7.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile8.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileMine.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileExploded.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileEmpty.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileFlag.png"),
        };

        PictureBox[,] pictureBoxGrid;

        GameState gameState = new GameState("Normal");

        public Form()
        {
            InitializeComponent();

            pictureBoxGrid = SetupPictureBoxGrid(gameState.GameGrid);

            cbxDifficulty.Text = "Normal";
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

        void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    pictureBoxGrid[r, c].Image = tileImages[id];
                }
            }
        }

        void PictureBox_Click(object sender, EventArgs e)
        {

        }

        private void cbxDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (PictureBox pbx in pictureBoxGrid)
            {
                Controls.Remove(pbx);
            }

            gameState = new GameState(cbxDifficulty.Text);

            this.Width = gameState.GameGrid.Columns * 30 + 14;
            this.Height = gameState.GameGrid.Rows * 30 + 45 + 39;

            pictureBoxGrid = SetupPictureBoxGrid(gameState.GameGrid);
            DrawGrid(gameState.GameGrid);
        }
    }
}
