
namespace Tetris
{

    class GameState
    {

        private Block currentBlock;

        public Block CurrentBlock
        {
            get { return currentBlock; }
            set
            {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        public GameGrid GameGrid { get; }

        public BlockQueue BlockQueue { get; }

        public bool GameOver { get; private set; }

        public int Score { get; private set; }

        public int HighScore { get; set; }

        public string HighScoreText { get; private set; }

        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        private bool BlockFits()
        {
            foreach (Position pos in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(pos.Row, pos.Column))
                {
                    return false;
                }
            }

            return true;
        }

        public void RotateBlock()
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach (Position pos in CurrentBlock.TilePositions())
            {
                GameGrid[pos.Row, pos.Column] = CurrentBlock.Id;
            }

            Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
                SetHighScore();
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        private void SetHighScore()
        {
            if (Score > HighScore || HighScore == -1)
            {
                HighScoreText = $"New High Score: {Score}";
                HighScore = Score;
            }
            else
            {
                HighScoreText = $"High Score: {HighScore}";
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        private int TileDropDistance(Position pos)
        {
            int drop = 0;

            while (GameGrid.IsEmpty(pos.Row + drop + 1, pos.Column))
            {
                drop++;
            }

            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;

            foreach (Position pos in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(pos));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
