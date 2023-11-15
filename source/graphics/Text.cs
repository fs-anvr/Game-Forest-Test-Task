namespace Game_Forest_Test_Task.source.graphics
{
    public class Text : Label
    {
        private string text = "";
        private Size size = Size.Empty;

        public Text()
        {
            Draw();
        }

        public Text SetSize(Size size)
        {
            this.size = size;
            Draw();
            return this;
        }

        public Text SetText(string text)
        {
            this.text = text;
            Draw();
            return this;
        }

        private void Draw()
        {
            this.ClientSize = size;
            this.Text = text;
        }
    }
}