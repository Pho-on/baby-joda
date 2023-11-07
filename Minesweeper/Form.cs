using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public partial class Form : System.Windows.Forms.Form
    {
        Difficulty difficulty = Difficulty.Normal;

        Board board = new Board();
        Cell[,] state;

        bool gameOver;

        public Form()
        {
            InitializeComponent();

            cbxDifficulty.Text = "Normal";
        }

        private void cbxDifficulty_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            NewGame();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        void NewGame()
        {
            gameOver = false;

            if (state != null)
            {
                foreach (Cell cell in state)
                {
                    Controls.Remove(cell);
                }
            }

            GetGameDifficulty(cbxDifficulty.Text);

            state = new Cell[GetRows(difficulty), GetColumns(difficulty)];

            GenerateCells();
            GenerateMines();
            SetForm();
        }

        void GenerateCells()
        {
            for (int r = 0; r < state.GetLength(0); r++)
            {
                for (int c = 0; c < state.GetLength(1); c++)
                {
                    Cell cell = new Cell()
                    {
                        Size = new Size(30, 30),
                        Location = new Point(r * 30, c * 30 + 45),
                        BackColor = Color.FromArgb(128, 128, 128),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        row = r,
                        column = c,
                        type = Cell.Type.Empty,
                    };

                    cell.Click += Cell_Click;
                    cell.Image = board.GetTile(cell);
                    state[r, c] = cell;
                    Controls.Add(cell);
                }
            }
        }

        void Cell_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            var args = e as MouseEventArgs;
            var cell = sender as Cell;

            switch (args.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Right:
                    break;
                default:
                    break;
            }
        }

        void GetGameDifficulty(string level)
        {
            switch (level)
            {
                case "Easy":
                    difficulty = Difficulty.Easy;
                    break;
                case "Normal":
                    difficulty = Difficulty.Normal;
                    break;
                case "Hard":
                    difficulty = Difficulty.Hard;
                    break;
                default:
                    break;
            }
        }

        int GetRows(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return 10;
                case Difficulty.Normal:
                    return 18;
                case Difficulty.Hard:
                    return 26;
                default:
                    return 0;
            }
        }

        int GetColumns(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return 8;
                case Difficulty.Normal:
                    return 14;
                case Difficulty.Hard:
                    return 20;
                default:
                    return 0;
            }
        }

        int GetMineCount(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return 10;
                case Difficulty.Normal:
                    return 40;
                case Difficulty.Hard:
                    return 99;
                default:
                    return 0;
            }
        }

        void GenerateMines()
        {
            int i = 0;

            while (i < GetMineCount(difficulty))
            {
                Random random = new Random();

                int r = random.Next(0, state.GetLength(0));
                int c = random.Next(0, state.GetLength(1));

                if (state[r, c].type != Cell.Type.Mine)
                {
                    state[r, c].type = Cell.Type.Mine;
                    i++;
                }
            }
        }

        void SetForm()
        {
            this.Width = 30 * state.GetLength(0) + 16;
            this.Height = 30 * state.GetLength(1) + 84;

            btnRestart.Location = new Point(this.Width / 2 - 26, 5);
            btnRestart.Size = new Size(35, 35);
            lblTimer.Location = new Point(this.Width - 110, 12);
        }
    }
}