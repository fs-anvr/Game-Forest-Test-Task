namespace Game_Forest_Test_Task.source.graphics
{
    public class Window : Form
    {
        private List<List<Control>> screens = new();
        public Window()
        {
            this.Size = Size.Empty;
            this.Text = String.Empty;
            this.Location = Point.Empty;
        }

        public Window SetSize(Size size)
        {
            this.Size = size;
            return this;
        }

        public Window SetHeading(string heading)
        {
            this.Text = heading;
            return this;
        }

        public Window SetPositionOnScreen(Point position)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = position;
            return this;
        }

        public Window AddScreen(List<Control> screen)
        {
            screens.Add(screen);
            return this;
        }

        public Window SetActiveScreen(int index)
        {
            this.Controls.Clear();
            if (index >= 0 && index < screens.Count)
            {
                this.Controls.AddRange(screens[index].ToArray());
            }
            return this;
        }
    }
}