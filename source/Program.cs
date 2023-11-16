using Game_Forest_Test_Task.source.graphics;
using Game_Forest_Test_Task.source.core;

namespace Game_Forest_Test_Task
{
    static class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            ApplicationConfiguration.Initialize();
        
            var window = CreateMainWindow();
            var game = new Game();

            Application.Run(window);
        }

        private static Window CreateMainWindow()
        {
            var heading = "Ultimate Match-3 Game Of The Year";
            var size = new Size(800, 600);
            Point positionOnScreen;
            if (Screen.PrimaryScreen is not null)
            {
                positionOnScreen = new Point{
                    X = Screen.PrimaryScreen.Bounds.Width / 2 - size.Width / 2,
                    Y = Screen.PrimaryScreen.Bounds.Height / 2 - size.Height / 2
                    };
            } else
            {
                positionOnScreen = Point.Empty;
            }
            return new Window()
                .SetSize(size)
                .SetHeading(heading)
                .SetPositionOnScreen(positionOnScreen);
        }
    }
}