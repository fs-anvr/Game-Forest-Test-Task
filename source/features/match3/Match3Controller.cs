using Game_Forest_Test_Task.source.features.board;
using Game_Forest_Test_Task.source.core;

namespace Game_Forest_Test_Task.source.features.match3
{
    public class Match3Controller : IController, IUpdatable
    {
        public void Process(GameAction actionId, object? data = null)
        {
            switch (actionId)
            {
                case GameAction.ClickCell:
                    break;
                default:
                    break;
            }
        }

        public void Update(float daltaTime)
        {
            switch (Game.Instance().GameState)
            {
                case GameState.Board_ProcessInput:
                    ProcessMatch3();
                    Game.Instance().GameState = GameState.Board_Animation;
                    break;
                default:
                    break;
            }
        }

        private static void ProcessMatch3()
        {
            var matches = FindMatch3();
            var cellsToRemove = MatchesToCells(matches);
            foreach (var cell in cellsToRemove)
            {
                Game.Instance().GameBoard?.ClearCell(cell.position.Width, cell.position.Height);
            }

            Game.Instance().Score += matches.Count;
        }

        private static List<Match3> FindMatch3()
        {
            var matches = FindMatch3Horizontal();
            matches.AddRange(FindMatch3Vertical());
            return matches;
        }

        private static List<Match3> FindMatch3Horizontal()
        {
            var cells = Game.Instance().GameBoard.Cells;
            var matches = new List<Match3>();
                        
            for (int y = 0; y < cells.GetLength(1); ++y)
            {
                for (int x = 1; x < cells.GetLength(0) - 1; ++x)
                {
                    var cell = cells[x, y];
                    var cellLeft = cells[x - 1, y];
                    var cellRight = cells[x + 1, y];

                    if (cellLeft.valueTypeId == cell.valueTypeId &&
                        cellRight.valueTypeId == cell.valueTypeId)
                    {
                        var match = new Match3(cellLeft, cell, cellRight);
                        matches.Add(match);
                        x += 2;
                    }
                }
            }

            return matches;
        }

        private static List<Match3> FindMatch3Vertical()
        {
            var cells = Game.Instance().GameBoard.Cells;
            var matches = new List<Match3>();
            
            for (int x = 0; x < cells.GetLength(0); ++x)
            {
                for (int y = 1; y < cells.GetLength(1) - 1; ++y)
                {
                    var cell = cells[x, y];
                    var cellTop = cells[x, y - 1];
                    var cellBottom = cells[x, y + 1];

                    if (cellTop.valueTypeId == cell.valueTypeId &&
                        cellBottom.valueTypeId == cell.valueTypeId)
                    {
                        var match = new Match3(cellTop, cell, cellBottom);
                        matches.Add(match);
                        y += 2;
                    }
                }
            }

            return matches;
        }

        private static List<Cell> MatchesToCells(List<Match3> matches)
        {
            var cells = new List<Cell>();
            
            foreach (var match in matches)
            {
                cells.AddRange(match.cells);
            }

            var uniqueCells = cells.Distinct().ToList();
            return uniqueCells;
        }
    }
}