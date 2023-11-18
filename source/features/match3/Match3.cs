using Game_Forest_Test_Task.source.features.board;

namespace Game_Forest_Test_Task.source.features.match3
{
    public struct Match3
    {
        public List<Cell> cells;

        public Match3(Cell c1, Cell c2, Cell c3)
        {
            cells = new List<Cell> { c1, c2, c3 };
        }
    }
}