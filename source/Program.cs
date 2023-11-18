using Game_Forest_Test_Task.source.features.board;
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

            var windowSize = new Size(800, 600);
            var boardShape = new Size(8, 8);
            var cellFilenames = new Dictionary<int, string>()
            {
                {1, "blue"},
                {2, "gray"},
                {3, "green"},
                {4, "ogre"},
                {5, "red"}
            };
            var ui = UI.Create(windowSize, boardShape, cellFilenames);
            foreach(var screen in ui.Screens)
            {
                window.AddScreen(screen);
            }
            window.SetActiveScreen(1);

            var game = new Game()
                .SetTargetFPS(60)
                .SetGameBoard(new GameBoard(boardShape, ui.GameBoardView));

            var cellIdGenerator = new Random();
            for (int x = 0; x < boardShape.Width; ++x)
            {
                for (int y = 0; y < boardShape.Height; ++ y)
                {
                    var cell = new Cell{ valueTypeId = cellIdGenerator.Next(1, 5)};
                    game.GameBoard?.SetCell(x, y, cell);
                }
            }
            
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