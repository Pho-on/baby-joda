using System.Drawing;
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

        public Form()
        {
            InitializeComponent();

            cbxDifficulty.Text = "Normal";
            NewGame();
        }

        void NewGame()
        {
            state = new Cell[GetRows(difficulty), GetColumns(difficulty)];

            SetForm();
            GetGameDifficulty(cbxDifficulty.Text);
            GenerateCells();
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

                    cell.Image = board.GetTile(cell);
                    state[r, c] = cell;
                    Controls.Add(cell);
                }
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

        void SetForm()
        {
            this.Width = 30 * state.GetLength(0) + 16;
            this.Height = 30 * state.GetLength(1) + 68;

            btnRestart.Location = new Point(this.Width / 2 - 8, 5);
            lblTimer.Location = new Point(this.Width - 108, 12);
        }
    }
}