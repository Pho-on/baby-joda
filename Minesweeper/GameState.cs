namespace Minesweeper
{

    class GameState
    {
        public string Difficulty { get ; set; }

        public GameGrid GameGrid { get; private set; }

        public GameState(string difficulty)
        {
            this.Difficulty = difficulty;

            if (difficulty == "Easy")
            {
                GameGrid = new GameGrid(8, 10);
            }
            else if (difficulty == "Normal")
            {
                GameGrid = new GameGrid(14, 18);
            }
            else if (difficulty == "Hard")
            {
                GameGrid = new GameGrid(20, 24);
            }  
        }
    }
}
