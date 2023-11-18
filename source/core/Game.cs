using Game_Forest_Test_Task.source.features;
using Game_Forest_Test_Task.source.features.board;
using Game_Forest_Test_Task.source.graphics;

namespace Game_Forest_Test_Task.source.core
{
    public class Game
    {
        public int Score {get; set; }
        public GameBoard? GameBoard { get; private set; }
        public UI? UI { get; private set; }
        public GameState GameState { get; set; }
        
        public readonly List<IUpdatable> Updatables = new();
        public readonly List<IController> Controllers = new();

        private static Game? instance;

        private int targetFPS = (int)(1000f / 60f);
        private readonly System.Windows.Forms.Timer timer = new();
        private DateTime frameStart;
        private DateTime frameEnd;

        public static Game Instance()
        {
            instance ??= new Game();
            return instance;
        }

        public Game SetState(GameState state)
        {
            GameState = state;
            return this;
        }
        
        public Game SetGameBoard(GameBoard board)
        {
            GameBoard = board;
            return this;
        }

        public Game SetUI(UI ui)
        {
            UI = ui;
            return this;
        }

        public Game SetTargetFPS(int fps)
        {
            targetFPS = fps;
            timer.Interval = targetFPS;
            return this;
        }

        private void SetupUpdate()
        {
            timer.Stop();
            timer.Interval = targetFPS;
            timer.Tick += Update;
            timer.Start();
        }

        private void Update(object? sender, EventArgs e)
        {
            var deltaTime = DeltaTime(frameStart, frameEnd);

            foreach(var obj in Updatables)
            {
                obj.Update(deltaTime);
            }
        }

        private float DeltaTime(DateTime start, DateTime end)
        {
            frameStart = frameEnd;
            frameEnd = DateTime.Now;

            const float msInSecond = 1000f;
            return Math.Abs(end.Millisecond - start.Millisecond) / msInSecond;
        }

        private Game()
        {
            frameStart = DateTime.Now;
            frameEnd = frameStart;
            SetupUpdate();
        }
    }
}