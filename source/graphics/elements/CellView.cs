using Game_Forest_Test_Task.source.core;
using Game_Forest_Test_Task.source.features;
using Game_Forest_Test_Task.source.features.board;

namespace Game_Forest_Test_Task.source.graphics.elements
{
    public class CellView : PictureBox
    {
        private IController? controller;
        private GameAction action = GameAction.None;
        private Cell cell;

        public CellView()
        {
            this.Image = null;
            this.Size = Size.Empty;
            this.Location = Point.Empty;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;

            this.Click += OnClick;
        }

        public void OnClick(object? sender, System.EventArgs e)
        {
            controller?.Process(action, cell);
        }

        public CellView SetActionId(GameAction action)
        {
            this.action = action;
            return this;
        }

        public CellView SetActionData(Cell cell)
        {
            this.cell = cell;
            return this;
        }

        public CellView SetController(IController controller)
        {
            this.controller = controller;
            return this;
        }

        public CellView SetImage(Image image)
        {
            this.Image = image;
            return this;
        }

        public CellView SetSize(Size size)
        {
            this.Size = size;
            return this;
        }

        public CellView SetPosition(Point position)
        {
            this.Location = position;
            return this;
        }
    }
}