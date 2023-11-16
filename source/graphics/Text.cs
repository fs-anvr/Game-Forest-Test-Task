namespace Game_Forest_Test_Task.source.graphics
{
    public class Text : Label
    {

        public Text()
        {
            this.Size = Size.Empty;
            this.Text = String.Empty;
            this.Location = Point.Empty;
        }

        public Text SetSize(Size size)
        {
            this.Size = size;
            return this;
        }

        public Text SetText(string text)
        {
            this.Text = text;
            return this;
        }

        public Text SetPosition(Point position)
        {
            this.Location = position;
            return this;
        }
    }
}