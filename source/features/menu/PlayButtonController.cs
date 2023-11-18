using Game_Forest_Test_Task.source.core;

namespace Game_Forest_Test_Task.source.features.menu
{
    public class PlayButtonController : IController
    {
        public void Process(GameAction actionId, object? data = null)
        {
            switch (actionId)
            {
                case GameAction.ClickPlay:
                    if (Game.Instance().GameState.Equals(GameState.MainMenu))
                    {
                        Game.Instance()?.UI?.Window.SetActiveScreen(1);
                        Game.Instance().GameState = GameState.Board_AwaitClickFirst;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}