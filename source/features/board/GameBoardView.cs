using Game_Forest_Test_Task.source.core;
using Game_Forest_Test_Task.source.features.click;
using Game_Forest_Test_Task.source.graphics;
using Game_Forest_Test_Task.source.graphics.elements;
using Game_Forest_Test_Task.source.tools;

namespace Game_Forest_Test_Task.source.features.board
{
    public class GameBoardView
    {
        private readonly Sprite boardView;
        private readonly CellView?[,] cellViews;
        private Dictionary<int, string> filenames;

        private Size cellSize;
        private Size boardSize;

        public GameBoardView(Sprite boardView, Size shape, Dictionary<int, string> filenames)
        {
            this.boardView = boardView;
            boardSize = boardView.Size;
            cellSize = new Size(boardSize.Width / shape.Width, boardSize.Height / shape.Height);
            cellViews = new CellView[shape.Width, shape.Height];
            this.filenames = filenames;
        }

        public void SwapViews(Cell first, Cell second)
        {
            var firstView = cellViews[first.position.Width, first.position.Height];
            var secondView = cellViews[second.position.Width, second.position.Height];

            var pos1 = firstView.Location;
            var pos2 = secondView.Location;

            SetCellView(pos1.X, pos1.Y, second);
            SetCellView(pos2.X, pos2.Y, first);
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
                ClearCellView(x, y);
            }

            cellViews[x, y] = cellView;
            boardView.Controls.Add(cellViews[x, y]);
        }

        public void ClearCellView(int x, int y)
        {
            if (!IsCorrectPosition(x, y))
            {
                return;
            }
            
            var view = cellViews[x, y];
            boardView.Controls.Remove(view);
            cellViews[x, y] = null;
        }

        private bool IsCorrectPosition(int x, int y)
        {
            return !(x < 0 || x > cellViews.GetLength(0) || y < 0 || y > cellViews.GetLength(1));
        }

        private CellView? CreateCellView(int x, int y, Cell cell)
        {
            var image = LoadImageById(cell.valueTypeId);
            if (image is null)
            {
                return null;
            }

            ClickController? clickController = null;
            foreach (var controller in Game.Instance().Controllers)
            {
                if (controller is ClickController click)
                {
                    clickController = click;
                    continue;
                }
            }

            var cellView = new CellView()
                .SetImage(image)
                .SetPosition(new Point{
                    X = x * cellSize.Width,
                    Y = y * cellSize.Height
                })
                .SetSize(cellSize);
            
            if (clickController is not null)
            {
                cellView
                    .SetController(clickController)
                    .SetActionId(GameAction.ClickCell)
                    .SetActionData(cell);
            }

            return cellView;
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