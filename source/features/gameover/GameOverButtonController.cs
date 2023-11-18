using Game_Forest_Test_Task.source.core;

namespace Game_Forest_Test_Task.source.features.gameover
{
    public class GameOverButtonController : IController
    {
        public void Process(GameAction actionId, object? data = null)
        {
            switch (actionId)
            {
                case GameAction.ClickGameOver:
                    if (Game.Instance().GameState.Equals(GameState.GameOver))
                    {
                        Game.Instance().UI?.Window.SetActiveScreen(0);
                        Game.Instance().GameState = GameState.MainMenu;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}