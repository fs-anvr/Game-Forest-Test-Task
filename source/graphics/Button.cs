namespace Game_Forest_Test_Task.source.graphics
{
    public class Button : System.Windows.Forms.Button
    {
        private string text = "";
        private Size size = Size.Empty;

        public Button()
        {}

        public Button SetSize(Size size)
        {
            this.size = size;
            Draw();
            return this;
        }

        public Button SetText(string text)
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