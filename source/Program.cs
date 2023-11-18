using Game_Forest_Test_Task.source.features.gameover;
using Game_Forest_Test_Task.source.features.board;
using Game_Forest_Test_Task.source.features.menu;
using Game_Forest_Test_Task.source.features;
using Game_Forest_Test_Task.source.graphics;
using Game_Forest_Test_Task.source.core;
using Game_Forest_Test_Task.source.features.click;
using Game_Forest_Test_Task.source.features.match3;

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
            var boardShape = new Size(8, 8);
            var ui = CreateUI(window, boardShape);
            
            Game.Instance()
                .SetTargetFPS(60)
                .SetUI(ui)
                .SetGameBoard(new GameBoard(boardShape, ui.GameBoardView))
                .SetState(GameState.MainMenu);
            Game.Instance().UI?.Window.SetActiveScreen(0);

            var playButtonController = new PlayButtonController();
            Game.Instance().UI?.PlayButton.SetController(playButtonController);
            Game.Instance().Controllers.Add(playButtonController);

            var gameOverButtonController = new GameOverButtonController();
            Game.Instance().UI?.GameOverButton.SetController(gameOverButtonController);
            Game.Instance().Controllers.Add(gameOverButtonController);

            var ClickController = new ClickController();
            Game.Instance().Controllers.Add(ClickController);

            var match3Controller = new Match3Controller();
            Game.Instance().Updatables.Add(match3Controller);

            GenerateCells();
            
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

        private static UI CreateUI(Window window, Size boardShape)
        {
            var cellFilenames = new Dictionary<int, string>()
            {
                {1, "blue"},
                {2, "gray"},
                {3, "green"},
                {4, "ogre"},
                {5, "red"}
            };

            return UI.Create(window, boardShape, cellFilenames);
        }

        private static void GenerateCells()
        {
            var boardShape = Game.Instance().GameBoard?.Shape;
            if (boardShape is null)
            {
                return;
            }

            var cellIdGenerator = new Random();
            for (int x = 0; x < boardShape?.Width; ++x)
            {
                for (int y = 0; y < boardShape?.Height; ++ y)
                {
                    var cell = new Cell {
                        valueTypeId = cellIdGenerator.Next(1, 5),
                        position = new Size(x, y)
                        };
                    Game.Instance().GameBoard?.SetCell(x, y, cell);
                }
            }
        }
    }
}