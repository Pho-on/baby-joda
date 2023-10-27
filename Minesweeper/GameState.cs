namespace Minesweeper
{

    class GameState
    {
        public string Difficulty { get ; set; }

        public GameGrid GameGrid { get; }

        public GameState()
        {
            Difficulty = "Normal";

            if (Difficulty == "Easy")
            {
                GameGrid = new GameGrid(8, 10);
            }
            else if (Difficulty == "Normal")
            {
                GameGrid = new GameGrid(14, 18);
            }
            else if (Difficulty == "Hard")
            {
                GameGrid = new GameGrid(20, 24);
            }  
        }
    }
}
