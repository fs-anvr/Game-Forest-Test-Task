namespace Game_Forest_Test_Task.source.graphics
{
    public class Button : System.Windows.Forms.Button
    {

        public Button()
        {
            this.Size = Size.Empty;
            this.Text = String.Empty;
            this.Location = Point.Empty;
        }

        public Button SetSize(Size size)
        {
            this.Size = size;
            return this;
        }

        public Button SetText(string text)
        {
            this.Text = text;
            return this;
        }

        public Button SetPosition(Point position)
        {
            this.Location = position;
            return this;
        }
    }
}