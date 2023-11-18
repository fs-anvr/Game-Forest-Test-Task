namespace Game_Forest_Test_Task.source.graphics
{
    public class Text : Label
    {
        public const string baseFontFamily = "Microsoft Sans Serif";

        public Text()
        {
            this.Size = Size.Empty;
            this.Text = String.Empty;
            this.Location = Point.Empty;

            this.AutoSize = false;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = new Font(baseFontFamily, 12);
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

        public Text SetFontSize(int size)
        {
            this.Font = new Font(baseFontFamily, size);
            return this;
        }
    }
}