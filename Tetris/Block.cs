using System.Collections.Generic;

namespace Tetris
{

    abstract class  Block
    { 

        protected abstract Position[][] Tiles { get; }

        protected abstract Position StartOffset { get; }

        public abstract int  Id { get; }

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePosition()
        {
            foreach (Position pos in Tiles[rotationState]) 
            { 
                yield return new Position(pos.Row + offset.Row, pos.Column + offset.Column);
            }
        }

        public void Rotate()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
