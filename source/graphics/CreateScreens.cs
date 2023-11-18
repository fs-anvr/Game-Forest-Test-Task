using Game_Forest_Test_Task.source.features;
using Game_Forest_Test_Task.source.tools;

namespace Game_Forest_Test_Task.source.graphics
{
    public class CreateScreens
    {
        public static List<List<Control>> Create(Size windowSize)
        {
            var margin = 15;

            var playButtonSize = new Size(200, 80);
            var mainScreen = new List<Control>
            {
                new ButtonView()
                    .SetSize(playButtonSize)
                    .SetPosition(new Point {
                        X = windowSize.Width / 2 - playButtonSize.Width / 2,
                        Y = windowSize.Height / 2 - playButtonSize.Height / 2
                        })
                    .SetText("Play")
                    .SetActionId(GameAction.ClickPlay)
            };

            var scoreTextSize = new Size(160, 40);
            var scoreText = "Score: -inf";
            var timerTextSize = new Size(140, 40);
            var timerText = "Time: 60 sec";
            var cellSize = new Size(48, 48);
            var boardSize = new Size(cellSize.Width * 8, cellSize.Height * 8);

            var cells = new List<Control>
            {
                new Sprite()
                    .SetSize(cellSize)
                    .SetPosition(new Point {
                        X = cellSize.Width * 0,
                        Y = cellSize.Height * 0
                        })
                    .SetImage(Resources.LoadImage("blue"))
            };

            var board = new Sprite()
                            .SetSize(boardSize)
                            .SetPosition(new Point {
                                X = windowSize.Width / 2 - boardSize.Width / 2,
                                Y = windowSize.Height / 2 - boardSize.Height / 2
                            })
                            .SetImage(Resources.LoadImage("board"));
            
            foreach (var cell in cells)
            {
                board.Controls.Add(cell);
            }

            var gameScreen = new List<Control>
            {
                new Text()
                    .SetSize(scoreTextSize)
                    .SetPosition(new Point {
                        X = windowSize.Width - scoreTextSize.Width - timerTextSize.Width - margin * 2,
                        Y = 10
                        })
                    .SetText(scoreText),
                new Text()
                    .SetSize(timerTextSize)
                    .SetPosition(new Point {
                        X = windowSize.Width - timerTextSize.Width - margin,
                        Y = 10
                        })
                    .SetText(timerText),
                board
            };

            var gameOverTextSize = new Size(300, 80);
            var gameOverText = "Game Over";
            var gameOverButtonSize = new Size(200, 80);
            var gameOverTextButton = "Ok";
            var gameOverScreen = new List<Control>
            {
                new Text()
                    .SetSize(gameOverTextSize)
                    .SetPosition(new Point {
                        X = windowSize.Width / 2 - gameOverTextSize.Width / 2,
                        Y = windowSize.Height / 2 - gameOverButtonSize.Height / 2 - gameOverTextSize.Height
                        })
                    .SetText(gameOverText)
                    .SetFontSize(20),
                new ButtonView()
                    .SetSize(gameOverButtonSize)
                    .SetPosition(new Point {
                        X = windowSize.Width / 2 - gameOverButtonSize.Width / 2,
                        Y = windowSize.Height / 2 - gameOverButtonSize.Height / 2
                        })
                    .SetText(gameOverTextButton)
                    .SetActionId(GameAction.ClickGameOver)
            };

            return new List<List<Control>>
            {
                mainScreen,
                gameScreen,
                gameOverScreen
            };
        }
    }
}