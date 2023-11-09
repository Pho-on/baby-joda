using System;
using System.Drawing;
using System.Threading.Tasks;
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

        DateTime gameStartedAt;

        bool gameOver;
        bool firstClick = true;

        public Form()
        {
            InitializeComponent();

            cbxDifficulty.Text = "Normal";
        }

        async void NewGame()
        {
            gameOver = false;
            firstClick = true;
            gameStartedAt = DateTime.Now - TimeSpan.FromSeconds(1);

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
            SetForm();
            await Timer();
        }

        private void cbxDifficulty_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            NewGame();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            NewGame();
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
                    HandleLeftClick(cell);
                    break;

                case MouseButtons.Right:
                    Flag(cell);
                    break;

                default:
                    break;
            }
        }

        void HandleLeftClick(Cell cell)
        {
            if (firstClick)
            {
                GeneraateCellTypes(cell);
                Reveal(cell);
                firstClick = false;
            }
            else
            {
                Reveal(cell);
            }
        }

        void Flag(Cell cell)
        {
            if (cell.revealed)
            {
                return;
            }

            cell.flagged = !cell.flagged;

            state[cell.row, cell.column] = cell;
            state[cell.row, cell.column].Image = board.GetTile(cell);
        }

        void Reveal(Cell cell)
        {
            if (cell.revealed || cell.flagged)
            {
                return;
            }

            switch (cell.type)
            {
                case Cell.Type.Mine:
                    Explode(cell);
                    break;

                case Cell.Type.Empty:
                    Flood(cell.row, cell.column);
                    break;

                default:
                    cell.revealed = true;
                    state[cell.row, cell.column] = cell;
                    break;
            }

            state[cell.row, cell.column].Image = board.GetTile(cell);
            CheckWin();
        }

        void Flood(int cellRow, int cellColumn)
        {
            if (cellRow < 0 || cellRow >= state.GetLength(0) || cellColumn < 0 || cellColumn >= state.GetLength(1)) { return; }
            if (state[cellRow, cellColumn].type == Cell.Type.Mine) { return; }
            if (state[cellRow, cellColumn].revealed) { return; }

            Cell cell = state[cellRow, cellColumn];

            cell.revealed = true;
            state[cell.row, cell.column] = cell;
            state[cell.row, cell.column].Image = board.GetTile(cell);

            if (cell.type == Cell.Type.Empty)
            {
                Flood(cellRow - 1, cellColumn);     // N
                Flood(cellRow - 1, cellColumn + 1); // NE
                Flood(cellRow, cellColumn + 1);     // E
                Flood(cellRow + 1, cellColumn + 1); // SE
                Flood(cellRow + 1, cellColumn);     // S
                Flood(cellRow + 1, cellColumn - 1); // SW
                Flood(cellRow, cellColumn - 1);     // W
                Flood(cellRow - 1, cellColumn - 1); // NW
            }
        }

        async void Explode(Cell cell)
        {
            gameOver = true;

            cell.revealed = true;
            cell.exploded = true;
            state[cell.row, cell.column] = cell;
            state[cell.row, cell.column].Image = board.GetTile(cell);
            await Task.Delay(50);

            for (int r = 0; r < state.GetLength(0); r++)
            {
                for (int c = 0; c < state.GetLength(1); c++)
                {
                    cell = state[r, c];

                    if (cell.type == Cell.Type.Mine)
                    {
                        cell.revealed = true;
                        state[r, c] = cell;
                        state[cell.row, cell.column].Image = board.GetTile(cell);
                        await Task.Delay(50);
                    }
                }
            }

        }

        void CheckWin()
        {
            foreach (Cell cell in state)
            {
                if (cell.type != Cell.Type.Mine && !cell.revealed)
                {
                    return;
                }
            }

            gameOver = true;
        }

        async Task Timer()
        {
            while (!gameOver)
            {
                lblTimer.Text = ((int)(DateTime.Now - gameStartedAt).TotalSeconds).ToString();
                await Task.Delay(1);
            }
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

        int GetNoMineSpace(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return 2;
                case Difficulty.Normal:
                    return 3;
                case Difficulty.Hard:
                    return 4;
                default:
                    return 0;
            }
        }

        bool IsInsideNoMineSpace(Cell cell, int r, int c)
        {
            if (r < (cell.row + GetNoMineSpace(difficulty)) && r > (cell.row - GetNoMineSpace(difficulty)) &&
               c < (cell.column + GetNoMineSpace(difficulty)) && c > (cell.column - GetNoMineSpace(difficulty)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void GenerateMines(Cell cell)
        {
            // funkar inte
            for (int i = 0; i < GetMineCount(difficulty); i++)
            {
                Random random = new Random();

                int r = random.Next(0, state.GetLength(0) - 1);
                int c = random.Next(0, state.GetLength(1) - 1);

                if (IsInsideNoMineSpace(cell, r, c))
                {
                    while (r < (cell.row + GetNoMineSpace(difficulty)) && r >= cell.row)
                    {
                        r++;

                        if (r >= state.GetLength(0))
                        {
                            r = 0;
                        }
                    }

                    if (!IsInsideNoMineSpace(cell, r, c))
                    {
                        while (state[r, c].type == Cell.Type.Mine)
                        {
                            r++;

                            if (r >= state.GetLength(0))
                            {
                                r = 0;
                                c++;

                                if (c >= state.GetLength(1))
                                {
                                    c = 0;
                                }
                            }
                        }

                        if (IsInsideNoMineSpace(cell, r, c))
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            state[r, c].type = Cell.Type.Mine;
                            continue;
                        }
                    }

                    

                    while (r >= (cell.row - GetNoMineSpace(difficulty)) && r <= cell.row)
                    {
                        r--;

                        if (r <= 0)
                        {
                            r = state.GetLength(0) - 1;
                        }
                    }

                    if (!IsInsideNoMineSpace(cell, r, c))
                    {
                        while (state[r, c].type == Cell.Type.Mine)
                        {
                            r--;

                            if (r <= 0)
                            {
                                r = state.GetLength(0) - 1;
                                c--;

                                if (c <= 0)
                                {
                                    c = 0;
                                }
                            }
                        }

                        if (IsInsideNoMineSpace(cell, r, c))
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            state[r, c].type = Cell.Type.Mine;
                            continue;
                        }
                    }

                    while (c <= (cell.column + GetNoMineSpace(difficulty)) && c >= cell.column)
                    {
                        c++;

                        if (c >= state.GetLength(1))
                        {
                            c = 0;
                        }
                    }

                    if (!IsInsideNoMineSpace(cell, r, c))
                    {
                        while (state[r, c].type == Cell.Type.Mine)
                        {
                            c++;

                            if (c >= state.GetLength(1))
                            {
                                c = 0;
                                r++;

                                if (r >= state.GetLength(0))
                                {
                                    r = 0;
                                }
                            }
                        }

                        if (IsInsideNoMineSpace(cell, r, c))
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            state[r, c].type = Cell.Type.Mine;
                            continue;
                        }
                    }

                    while (c >= (cell.column - GetNoMineSpace(difficulty)) && c <= cell.column)
                    {
                        c--;

                        if (c <= 0)
                        {
                            c = state.GetLength(1) - 1;
                        }
                    }

                    if (!IsInsideNoMineSpace(cell, r, c))
                    {
                        while (state[r, c].type == Cell.Type.Mine)
                        {
                            c--;

                            if (c <= 0)
                            {
                                c = state.GetLength(1) - 1;
                                r--;

                                if (r <= 0)
                                {
                                    r = 0;
                                }
                            }
                        }

                        if (IsInsideNoMineSpace(cell, r, c))
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            state[r, c].type = Cell.Type.Mine;
                            continue;
                        }
                    }
                }
                else
                {
                    while (state[r, c].type == Cell.Type.Mine)
                    {
                        r++;

                        if (r >= state.GetLength(0))
                        {
                            r = 0;
                            c++;

                            if (c >= state.GetLength(1))
                            {
                                c = 0;
                            }
                        }
                    }

                    if (IsInsideNoMineSpace(cell, r, c))
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        state[r, c].type = Cell.Type.Mine;
                    }
                }
            }
        }

        void GenerateNumbers()
        {
            for (int r = 0; r < state.GetLength(0); r++)
            {
                for (int c = 0; c < state.GetLength(1); c++)
                {
                    Cell cell = state[r, c];

                    if (cell.type == Cell.Type.Mine)
                    {
                        continue;
                    }

                    cell.number = CountMines(r, c);

                    if (cell.number > 0)
                    {
                        cell.type = Cell.Type.Number;
                    }

                    state[r, c] = cell;
                }
            }
        }

        int CountMines(int cellRow, int cellColumn)
        {
            int count = 0;

            for (int adjacentRows = -1; adjacentRows <= 1; adjacentRows++)
            {
                for (int adjacentColumns = -1; adjacentColumns <= 1; adjacentColumns++)
                {
                    if (adjacentRows == 0 && adjacentColumns == 0)
                    {
                        continue;
                    }

                    int r = cellRow + adjacentRows;
                    int c = cellColumn + adjacentColumns;

                    if (r < 0 || r >= state.GetLength(0) || c < 0 || c >= state.GetLength(1))
                    {
                        continue;
                    }

                    if (state[r, c].type == Cell.Type.Mine)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        void GeneraateCellTypes(Cell cell)
        {
            GenerateMines(cell);
            CountMines(cell.row, cell.column);
            GenerateNumbers();
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