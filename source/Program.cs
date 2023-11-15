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
        => new Window()
            .SetSize(new Size(800, 600))
            .SetHeading("Ultimate Match-3 Game Of The Year");
    }
}