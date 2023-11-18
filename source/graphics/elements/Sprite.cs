namespace Game_Forest_Test_Task.source.graphics
{
    public class Sprite : PictureBox
    {
        public Sprite()
        {
            this.Image = null;
            this.Size = Size.Empty;
            this.Location = Point.Empty;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }

        public Sprite SetImage(Image image)
        {
            this.Image = image;
            return this;
        }

        public Sprite SetSize(Size size)
        {
            this.Size = size;
            return this;
        }

        public Sprite SetPosition(Point position)
        {
            this.Location = position;
            return this;
        }
    }
}