using Game_Forest_Test_Task.source.core;
using Game_Forest_Test_Task.source.features;

namespace Game_Forest_Test_Task.source.graphics
{
    public class ButtonView : Button
    {
        private IController? controller;
        private GameAction action = GameAction.None;

        public ButtonView()
        {
            this.Size = Size.Empty;
            this.Text = String.Empty;
            this.Location = Point.Empty;

            this.Click += OnClick;
        }

        public void OnClick(object? sender, System.EventArgs e)
        {
            controller?.Process(action);
        }

        public ButtonView SetActionId(GameAction action)
        {
            this.action = action;
            return this;
        }

        public ButtonView SetController(IController controller)
        {
            this.controller = controller;
            return this;
        }

        public ButtonView SetSize(Size size)
        {
            this.Size = size;
            return this;
        }

        public ButtonView SetText(string text)
        {
            this.Text = text;
            return this;
        }

        public ButtonView SetPosition(Point position)
        {
            this.Location = position;
            return this;
        }
    }
}