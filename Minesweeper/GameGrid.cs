namespace Minesweeper
{

    class GameGrid
    {
        private int[,] grid;

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int this[int r, int c]
        {
            get { return grid[r, c]; }
            set { grid[r, c] = value; }
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }
    }
}
