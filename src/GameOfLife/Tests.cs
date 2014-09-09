using Xunit;

namespace GameOfLife
{
    public class Tests
    {
        [Fact]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDiesAsIfCausedByUnderPopulation()
        {
            var grid = new Grid(new Cell(1, 1), new Cell(0, 1));

            grid = grid.CreateNextGeneration();

            Assert.False(grid.IsAlive(new Cell(1, 1)));
        }

        [Fact]
        public void AnyLiveCellWithTwoLiveNeighboursLivesOnToTheNextGeneration()
        {
            var grid = new Grid(new Cell(1, 1), new Cell(0, 1), new Cell(2, 1));

            grid.CreateNextGeneration();

            Assert.True(grid.IsAlive(new Cell(1, 1)));
        }
        
        [Fact]
        public void AnyLiveCellWithThreeLiveNeighboursLivesOnToTheNextGeneration()
        {
            var grid = new Grid(new Cell(1, 1), new Cell(0, 1), new Cell(2, 1), new Cell(1, 2));

            grid = grid.CreateNextGeneration();

            Assert.True(grid.IsAlive(new Cell(1, 1)));
        }

        [Fact]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDiesAsIfByOvercrowding()
        {
            var grid = new Grid(new Cell(0, 0), new Cell(1, 0), new Cell(2, 0), new Cell(0, 1), new Cell(1, 1));

            grid = grid.CreateNextGeneration();

            Assert.False(grid.IsAlive(new Cell(1, 1)));
        }

        [Fact]
        public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesALiveCellAsIfByReproduction()
        {
            var grid = new Grid(new Cell(0, 0), new Cell(1, 0), new Cell(2, 0));

            grid = grid.CreateNextGeneration();

            Assert.True(grid.IsAlive(new Cell(1, 1)));
        }
    }
}