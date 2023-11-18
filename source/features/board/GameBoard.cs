using Game_Forest_Test_Task.source.graphics;

namespace Game_Forest_Test_Task.source.features.board
{
    public class GameBoard
    {
        public GameBoardView View { get; private set; }
        private readonly Cell[,] cells;

        public GameBoard(Size shape, GameBoardView boardView)
        {
            View = boardView;
            cells = new Cell[shape.Width, shape.Height];
        }

        public void SetCell(int x, int y, Cell cell)
        {
            if (!IsCorrectPosition(x, y))
            {
                return;
            }

            cells[x, y] = cell;
            View.SetCellView(x, y, cell);            
        }

        public Cell? GetCell(int x, int y)
        {
            if (!IsCorrectPosition(x, y))
            {
                return null;
            }

            return cells[x, y];
        }

        public Point? GetCellPosition(Cell cellToFind)
        {
            for (int x = 0; x < cells.GetLength(0); ++x)
            {
                for (int y = 0; y < cells.GetLength(1); ++y)
                {
                    var cell = cells[x, y];
                    if (cell.Equals(cellToFind))
                    {
                        return new Point(x, y);
                    }
                }
            }

            return null;
        }

        private bool IsCorrectPosition(int x, int y)
        {
            return !(x < 0 || x > cells.GetLength(0) || y < 0 || y > cells.GetLength(1));
        }
    }
}