namespace Game_Forest_Test_Task.source.graphics
{
    public class Window : Form
    {
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

        public Window SetControls(List<Control> elements)
        {
            this.Controls.Clear();
            this.Controls.AddRange(elements.ToArray());
            return this;
        }
    }
}