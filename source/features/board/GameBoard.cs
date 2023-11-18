namespace Game_Forest_Test_Task.source.features.board
{
    public class GameBoard
    {
        public GameBoardView View { get; private set; }
        public Size Shape { get; private set; }
        public Cell?[,] Cells {get; private set; }

        public GameBoard(Size shape, GameBoardView boardView)
        {
            Shape = shape;
            View = boardView;
            Cells = new Cell[shape.Width, shape.Height];
        }

        public void SwapCells(Cell first, Cell second)
        {
            var pos1 = first.position;
            var pos2 = second.position;

            first.position = pos2;
            second.position = pos1;

            Cells[pos1.Width, pos1.Height] = second;
            Cells[pos2.Width, pos2.Height] = first;
        }

        public void SetCell(int x, int y, Cell cell)
        {
            if (!IsCorrectPosition(x, y))
            {
                return;
            }

            Cells[x, y] = cell;
            View.SetCellView(x, y, cell);            
        }

        public Cell? GetCell(int x, int y)
        {
            if (!IsCorrectPosition(x, y))
            {
                return null;
            }

            return Cells[x, y];
        }

        public void ClearCell(int x, int y)
        {
            if (!IsCorrectPosition(x, y))
            {
                return;
            }

            Cells[x, y] = null;
            View.ClearCellView(x, y);
        }

        public Point? GetCellPosition(Cell cellToFind)
        {
            for (int x = 0; x < Cells.GetLength(0); ++x)
            {
                for (int y = 0; y < Cells.GetLength(1); ++y)
                {
                    var cell = Cells[x, y];
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
            return !(x < 0 || x > Cells.GetLength(0) || y < 0 || y > Cells.GetLength(1));
        }
    }
}