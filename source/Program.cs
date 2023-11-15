using Game_Forest_Test_Task.source.graphics;

namespace Game_Forest_Test_Task;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var window = new Window()
            .SetSize(new Size(800, 600))
            .SetHeading("THE GAME");

        var sunImage = Image.FromFile("resources/sun.png");
        var pictureBox = new Sprite()
            .SetImage(sunImage)
            .SetSize(sunImage.Size);
        //window.Controls.Add(pictureBox);

        var button = new source.graphics.Button()
            .SetSize(new Size(200, 50))
            .SetText("I'm Mr. Button!");
        window.Controls.Add(button);

        Application.Run(window);
    }
}