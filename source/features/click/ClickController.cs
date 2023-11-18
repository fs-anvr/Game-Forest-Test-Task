using Game_Forest_Test_Task.source.core;

namespace Game_Forest_Test_Task.source.features.click
{
    public class ClickController : IController
    {
        //private Cell first;
        //private Cell second;
        public void Process(GameAction actionId, object? data = null)
        {
            switch (actionId)
            {
                case GameAction.ClickCell:
                    switch (Game.Instance().GameState)
                    {
                        case GameState.Board_AwaitClickFirst:
                            //first = (Cell)data;
                            Game.Instance().GameState = GameState.Board_AwaitClickSecond;
                            break;
                        case GameState.Board_AwaitClickSecond:
                            //second = (Cell)data;
                            //Game.Instance().GameBoard.SwapCells(first, second);
                            Game.Instance().GameState = GameState.Board_ProcessInput;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}