using Game_Forest_Test_Task.source.features.board;
using Game_Forest_Test_Task.source.graphics;

namespace Game_Forest_Test_Task.source.core
{
    public class Game
    {
        public GameBoard? GameBoard { get; private set; }

        private int targetFPS = (int)(1000f / 60f);
        private readonly System.Windows.Forms.Timer timer = new();
        private DateTime frameStart;
        private DateTime frameEnd;

        private readonly List<IUpdatable> updatables = new();


        public Game()
        {
            frameStart = DateTime.Now;
            frameEnd = frameStart;
            SetupUpdate();
        }

        public Game SetGameBoard(GameBoard board)
        {
            GameBoard = board;
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

            foreach(var obj in updatables)
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
    }
}