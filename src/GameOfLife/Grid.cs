using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        readonly ISet<Cell> cells;

        public Grid(params Cell[] cells)
        {
            this.cells = new HashSet<Cell>(cells);
        }

        public Grid CreateNextGeneration()
        {
            var aliveCells = cells
                .Where(x => {
                    var aliveNeighbours = GetAliveNeighbourCount(x);
                    return aliveNeighbours == 2 || aliveNeighbours == 3;
                });

            var reviveCells = cells
                .SelectMany(GetDeadNeighbours)
                .Where(x => GetAliveNeighbourCount(x) == 3);

            return new Grid(aliveCells.Union(reviveCells).ToArray());
        }

        int GetAliveNeighbourCount(Cell cell)
        {
            return GetNeighbours(cell).Count(IsAlive);
        }

        static IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            return Enumerable.Range(-1, 3)
                .SelectMany(x => Enumerable.Range(-1, 3).Select(y => new Cell(cell.X + x, cell.Y + y)))
                .Except(new[] { cell });
        }

        IEnumerable<Cell> GetDeadNeighbours(Cell coordinate)
        {
            return GetNeighbours(coordinate).Where(c => !IsAlive(c));
        }

        public bool IsAlive(Cell cell)
        {
            return cells.Contains(cell);
        }
    }
}
