namespace Game_Forest_Test_Task.source.graphics
{
    public class Window : Form
    {
        private string heading = "Window";
        private Size size;

        public Window()
        {
            size = new Size(800, 600);
            Draw();
        }

        public Window SetSize(Size size)
        {
            this.size = size;
            Draw();
            return this;
        }

        public Window SetHeading(string heading)
        {
            this.heading = heading;
            Draw();
            return this;
        }

        private void Draw()
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = size;
            this.Text = heading;
        }
    }
}