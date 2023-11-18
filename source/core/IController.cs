using Game_Forest_Test_Task.source.features;

namespace Game_Forest_Test_Task.source.core
{
    public interface IController
    {
        public void Process(GameAction actionId, object? data = null);
    }
}