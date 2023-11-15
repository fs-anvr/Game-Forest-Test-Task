namespace Game_Forest_Test_Task.source.graphics
{
    public class Sprite : PictureBox
    {
        private Image? image;
        private Size size = Size.Empty;

        public Sprite()
        {
            Draw();
        }

        public Sprite SetImage(Image image)
        {
            this.image = image;
            Draw();
            return this;
        }

        public Sprite SetSize(Size size)
        {
            this.size = size;
            Draw();
            return this;
        }

        private void Draw()
        {
            this.Image = image;
            this.Size = size;
        }
    }
}