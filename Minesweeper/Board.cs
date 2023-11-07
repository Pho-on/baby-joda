using System.Drawing;

namespace Minesweeper
{

    class Board
    {
        readonly Bitmap tileUnknown = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileUnknown.png");
        readonly Bitmap tileEmpty = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileEmpty.png");
        readonly Bitmap tileMine = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileMine.png");
        readonly Bitmap tileExploded = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileExploded.png");
        readonly Bitmap tileFlag = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\TileFlag.png");
        readonly Bitmap tileOne = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile1.png");
        readonly Bitmap tileTwo = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile2.png");
        readonly Bitmap tileThree = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile3.png");
        readonly Bitmap tileFour = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile4.png");
        readonly Bitmap tileFive = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile5.png");
        readonly Bitmap tileSix = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile6.png");
        readonly Bitmap tileSeven = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile7.png");
        readonly Bitmap tileEight = new Bitmap(@"C:\Repos\baby-joda\Minesweeper\Images\Tile8.png");

        public Bitmap GetTile(Cell cell)
        {
            if (cell.revealed)
            {
                return GetRevealedTile(cell);
            }
            else if (cell.flagged)
            {
                return tileFlag;
            }
            else
            {
                return tileUnknown;
            }
        }

        private Bitmap GetRevealedTile(Cell cell)
        {
            switch (cell.type)
            {
                case Cell.Type.Empty:
                    return tileEmpty;
                case Cell.Type.Mine:
                    return tileMine;
                case Cell.Type.Number:
                    return GetNumberTile(cell);
                default:
                    return null;
            }
        }

        private Bitmap GetNumberTile(Cell cell)
        {
            switch (cell.number)
            {
                case 1:
                    return tileOne;
                case 2:
                    return tileTwo;
                case 3:
                    return tileThree;
                case 4:
                    return tileFour;
                case 5:
                    return tileFive;
                case 6:
                    return tileSix;
                case 7:
                    return tileSeven;
                case 8:
                    return tileEight;
                default:
                    return null;
            }
        }
    }
}
