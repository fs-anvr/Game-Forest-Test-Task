using Game_Forest_Test_Task.source.features;
using Game_Forest_Test_Task.source.features.board;
using Game_Forest_Test_Task.source.tools;

namespace Game_Forest_Test_Task.source.graphics
{
    public struct UI
    {
        public Window Window { get; set; }
        public List<List<Control>> Screens { get; set; }
        public GameBoardView GameBoardView { get; set; }
        public ButtonView PlayButton { get; private set; }
        public ButtonView GameOverButton { get; private set; }

        public static UI Create(Window window, Size boardShape, Dictionary<int, string> cellFilenames)
        {
            var margin = 15;

            var playButtonSize = new Size(200, 80);
            var playButtonText = "Play";

            var scoreTextSize = new Size(160, 40);
            var scoreText = "Score: -inf";
            var timerTextSize = new Size(140, 40);
            var timerText = "Time: 60 sec";
            var cellSize = new Size(48, 48);
            var boardSize = new Size(cellSize.Width * 8, cellSize.Height * 8);

            var gameOverTextSize = new Size(300, 80);
            var gameOverText = "Game Over";
            var gameOverButtonSize = new Size(200, 80);
            var gameOverTextButton = "Ok";

            var playButton = new ButtonView()
                                .SetSize(playButtonSize)
                                .SetPosition(new Point {
                                    X = window.Size.Width / 2 - playButtonSize.Width / 2,
                                    Y = window.Size.Height / 2 - playButtonSize.Height / 2
                                    })
                                .SetText(playButtonText)
                                .SetActionId(GameAction.ClickPlay);

            var boardView = new Sprite()
                            .SetSize(boardSize)
                            .SetPosition(new Point {
                                X = window.Size.Width / 2 - boardSize.Width / 2,
                                Y = window.Size.Height / 2 - boardSize.Height / 2
                            })
                            .SetImage(Resources.LoadImage("board"));

            var gameBoardView = new GameBoardView(boardView, boardShape, cellFilenames);

            var gameOverButton = new ButtonView()
                                    .SetSize(gameOverButtonSize)
                                    .SetPosition(new Point {
                                        X = window.Size.Width / 2 - gameOverButtonSize.Width / 2,
                                        Y = window.Size.Height / 2 - gameOverButtonSize.Height / 2
                                        })
                                    .SetText(gameOverTextButton)
                                    .SetActionId(GameAction.ClickGameOver);

            var mainScreen = new List<Control>
            {
                playButton
            };

            var gameScreen = new List<Control>
            {
                new Text()
                    .SetSize(scoreTextSize)
                    .SetPosition(new Point {
                        X = window.Size.Width - scoreTextSize.Width - timerTextSize.Width - margin * 2,
                        Y = 10
                        })
                    .SetText(scoreText),
                new Text()
                    .SetSize(timerTextSize)
                    .SetPosition(new Point {
                        X = window.Size.Width - timerTextSize.Width - margin,
                        Y = 10
                        })
                    .SetText(timerText),
                boardView
            };

            var gameOverScreen = new List<Control>
            {
                new Text()
                    .SetSize(gameOverTextSize)
                    .SetPosition(new Point {
                        X = window.Size.Width / 2 - gameOverTextSize.Width / 2,
                        Y = window.Size.Height / 2 - gameOverButtonSize.Height / 2 - gameOverTextSize.Height
                        })
                    .SetText(gameOverText)
                    .SetFontSize(20),
                gameOverButton
            };

            var screens = new List<List<Control>>
            {
                mainScreen,
                gameScreen,
                gameOverScreen
            };

            foreach(var screen in screens)
            {
                window.AddScreen(screen);
            }

            return new UI
            {
                Window = window,
                Screens = screens,
                GameBoardView = gameBoardView,
                PlayButton = playButton,
                GameOverButton = gameOverButton
            };
        }
    }
}