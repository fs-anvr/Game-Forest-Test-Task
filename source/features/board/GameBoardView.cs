using Game_Forest_Test_Task.source.graphics;
using Game_Forest_Test_Task.source.tools;

namespace Game_Forest_Test_Task.source.features.board
{
    public class GameBoardView
    {
        private readonly Sprite boardView;
        private readonly Sprite[,] cellViews;
        private Dictionary<int, string> filenames;

        private Size cellSize;
        private Size boardSize;

        public GameBoardView(Sprite boardView, Size shape, Dictionary<int, string> filenames)
        {
            this.boardView = boardView;
            boardSize = boardView.Size;
            cellSize = new Size(boardSize.Width / shape.Width, boardSize.Height / shape.Height);
            cellViews = new Sprite[shape.Width, shape.Height];
            this.filenames = filenames;
        }

        public void SetCellView(int x, int y, Cell cell)
        {
            if (!IsCorrectPosition(x, y))
            {
                return;
            }

            var cellView = CreateCellView(x, y, cell);
            if (cellView is null)
            {
                return;
            }
            
            if (cellViews[x, y] is not null)
            {
                boardView.Controls.Remove(cellViews[x, y]);
                cellViews[x, y].Dispose();
            }

            cellViews[x, y] = cellView;
            boardView.Controls.Add(cellViews[x, y]);
        }

        private bool IsCorrectPosition(int x, int y)
        {
            return !(x < 0 || x > cellViews.GetLength(0) || y < 0 || y > cellViews.GetLength(1));
        }

        private Sprite? CreateCellView(int x, int y, Cell cell)
        {
            var image = LoadImageById(cell.valueTypeId);
            if (image is null)
            {
                return null;
            }

            return new Sprite()
                .SetImage(image)
                .SetPosition(new Point{
                    X = x * cellSize.Width,
                    Y = y * cellSize.Height
                })
                .SetSize(cellSize);
        }

        private Image? LoadImageById(int cellTypeId)
        {
            var filename = GetCellFilenameById(cellTypeId);
            if (String.IsNullOrEmpty(filename))
            {
                return null;
            }

            return Resources.LoadImage(filename);
        }

        private string GetCellFilenameById(int cellTypeId)
        {
            if (filenames.ContainsKey(cellTypeId))
            {
                return filenames[cellTypeId];
            }

            return String.Empty;
        }
    }
}