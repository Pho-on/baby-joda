using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{

    public enum Image
    {
        Empty,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Unknown,
        Flag,
        Mine,
        Exploded
    };

    public partial class Form : System.Windows.Forms.Form
    {

        readonly Bitmap[] tileImages = new Bitmap[]
        {
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileEmpty.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile1.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile2.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile3.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile4.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile5.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile6.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile7.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile8.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileUnknown.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileFlag.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileMine.png"),
            new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileExploded.png")
        };

        PictureBox[,] pictureBoxGrid;

        int[,] mineGrid;

        GameState gameState = new GameState("Normal");

        DateTime gameStartedAt;

        public Form()
        {
            InitializeComponent();

            SetGameBoard();
            cbxDifficulty.Text = "Normal";
        }

        void SetGameBoard()
        {
            pictureBoxGrid = SetupPictureBoxGrid(gameState.GameGrid);
            mineGrid = SetupMines(gameState.GameGrid);
            DrawGrid(gameState.GameGrid);
            gameStartedAt = DateTime.Now - TimeSpan.FromSeconds(1);

            btnRestart.Location = new Point((this.Width / 2) - 23, 5);
            btnRestart.Size = new Size(35, 35);
            btnRestart.BringToFront();
            lblTimer.Location = new Point(this.Width - 108, 12);
            lblTimer.BringToFront();
            topDiv.SendToBack();
        }

        async Task Timer()
        {
            while (!gameState.GameOver)
            {
                lblTimer.Text = ((int)(DateTime.Now - gameStartedAt).TotalSeconds).ToString();
                await Task.Delay(1);
            }
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
                        BackColor = Color.FromArgb(128, 128, 128),
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

        int[,] SetupMines(GameGrid grid)
        {
            int i = 0;

            int[,] mineGrid = new int[grid.Rows, grid.Columns];

            if (gameState.Difficulty == "Easy")
            {
                while (i < 10)
                {
                    Random random = new Random();

                    int row = random.Next(1, grid.Rows);
                    int column = random.Next(1, grid.Columns);

                    if (mineGrid[row, column] != (int)Image.Mine)
                    {
                        mineGrid[row, column] = (int)Image.Mine;
                        i++;
                    }
                }
            }
            else if (gameState.Difficulty == "Normal")
            {
                while (i < 40)
                {
                    Random random = new Random();

                    int row = random.Next(1, grid.Rows);
                    int column = random.Next(1, grid.Columns);

                    if (mineGrid[row, column] != (int)Image.Mine)
                    {
                        mineGrid[row, column] = (int)Image.Mine;
                        i++;
                    }
                }
            }
            else if (gameState.Difficulty == "Hard")
            {
                while (i < 99)
                {
                    Random random = new Random();

                    int row = random.Next(1, grid.Rows);
                    int column = random.Next(1, grid.Columns);

                    if (mineGrid[row, column] != (int)Image.Mine)
                    {
                        mineGrid[row, column] = (int)Image.Mine;
                        i++;
                    }
                }
            }

            for (int r = 0; r < gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < gameState.GameGrid.Columns; c++)
                {
                    if (mineGrid[r, c] != (int)Image.Mine)
                    {
                        mineGrid = SuroundingMines(mineGrid);
                    }
                }
            }

            return mineGrid;
        }

        int[,] SuroundingMines(int[,] mineGrid)
        {
            int[,] matrixOutput = new int[mineGrid.GetLength(0), mineGrid.GetLength(1)];

            int rMax = mineGrid.GetLength(0);
            int cMax = mineGrid.GetLength(1);

            for (int r = 0; r < rMax; r++)
            {
                for (int c = 0; c < cMax; c++)
                {
                    if (mineGrid[r, c] == (int)Image.Mine)
                    {
                        matrixOutput[r, c] = (int)Image.Mine;
                    }
                    else
                    {
                        int numberOfMines = 0;

                        numberOfMines += (r - 1 >= 0) && (mineGrid[r - 1, c] == 11) ? 1 : 0;
                        numberOfMines += (r - 1 >= 0 && c - 1 >= 0) && (mineGrid[r - 1, c - 1] == 11) ? 1 : 0;
                        numberOfMines += (c - 1 >= 0) && (mineGrid[r, c - 1] == 11) ? 1 : 0;
                        numberOfMines += (r + 1 < rMax && c - 1 >= 0) && (mineGrid[r + 1, c - 1] == 11) ? 1 : 0;
                        numberOfMines += (r + 1 < rMax) && (mineGrid[r + 1, c] == 11) ? 1 : 0;
                        numberOfMines += (r + 1 < rMax && c + 1 < cMax) && (mineGrid[r + 1, c + 1] == 11) ? 1 : 0;
                        numberOfMines += (c + 1 < cMax) && (mineGrid[r, c + 1] == 11) ? 1 : 0;
                        numberOfMines += (r - 1 >= 0 && c + 1 < cMax) && (mineGrid[r - 1, c + 1] == 11) ? 1 : 0;

                        matrixOutput[r, c] = numberOfMines;
                    }
                }
            }

            return matrixOutput;
        }

        void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    pictureBoxGrid[r, c].Image = tileImages[(int)Image.Unknown];
                }
            }
        }

        bool IsMineClicked(PictureBox pbx)
        {
            if (mineGrid[((pbx.Location.Y - 15) / 30) - 1, ((pbx.Location.X + 30) / 30) - 1] == (int)Image.Mine)
            {
                return true;
            }

            return false;
        }

        async void ShowAllMines(PictureBox pbx)
        {
            pictureBoxGrid[((pbx.Location.Y - 15) / 30) - 1, ((pbx.Location.X + 30) / 30) - 1].Image = tileImages[(int)Image.Exploded];
            await Task.Delay(85);

            for (int r = 0; r < gameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < gameState.GameGrid.Columns; c++)
                {
                    if (mineGrid[r, c] == (int)Image.Mine && pictureBoxGrid[r, c].Image != tileImages[(int)Image.Exploded])
                    {
                        pictureBoxGrid[r, c].Image = tileImages[(int)Image.Mine];
                        await Task.Delay(85);
                    }
                }
            }
        }

        void Flood(int row, int column)
        {
            if (row > gameState.GameGrid.Rows - 1 || column > gameState.GameGrid.Columns - 1 || row < 0 || column < 0) { return; }
            if (mineGrid[row, column] == (int)Image.Mine) { return; }
            if (pictureBoxGrid[row, column].Image != tileImages[(int)Image.Unknown]) { return; }

            pictureBoxGrid[row, column].Image = tileImages[mineGrid[row, column]];

            if (mineGrid[row, column] == (int)Image.Empty)
            {
                Flood(row - 1, column);
                Flood(row + 1, column);
                Flood(row, column - 1);
                Flood(row, column + 1);
            }
        }

        void PictureBox_Click(object sender, EventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            var args = e as MouseEventArgs;
            var pbx = sender as PictureBox;

            switch (args.Button)
            {
                case MouseButtons.Left:
                    if (IsMineClicked(pbx)) { ShowAllMines(pbx); }
                    else { Flood(((pbx.Location.Y - 15) / 30) - 1, ((pbx.Location.X + 30) / 30) - 1); }
                    break;
                case MouseButtons.Right:
                    pbx.Image = tileImages[(int)Image.Flag];
                    break;
                default:
                    break;
            }
        }

        private async void cbxDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (PictureBox pbx in pictureBoxGrid)
            {
                Controls.Remove(pbx);
            }

            gameState = new GameState(cbxDifficulty.Text);

            this.Width = gameState.GameGrid.Columns * 30 + 14;
            this.Height = gameState.GameGrid.Rows * 30 + 45 + 38;

            SetGameBoard();

            await Timer();
        }

        private async void btnRestart_Click(object sender, EventArgs e)
        {
            foreach (PictureBox pbx in pictureBoxGrid)
            {
                Controls.Remove(pbx);
            }

            gameState = new GameState(cbxDifficulty.Text);

            SetGameBoard();

            await Timer();
        }
    }
}