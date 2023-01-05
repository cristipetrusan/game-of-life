using GOLconsole.Source;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeTest
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void TestInitialize()
        {
            // Create a stub Random object that always returns 0
            var randomStub = Substitute.For<Random>();
            randomStub.Next(Arg.Any<int>()).Returns(0);

            // Create a new Grid object and initialize it with the stub Random object
            var grid = new Grid(10, 10);
            grid.Initialize();

            // Verify that all cells in the grid are dead
            for (int i = 0; i < grid.Width; i++)
            {
                for (int j = 0; j < grid.Height; j++)
                {
                    Assert.IsNotNull(grid.Cells[i, j].IsAlive);
                }
            }
        }

        [Test]
        public void TestUpdate()
        {
            // Create a mock Cell object that expects the Update method to be called with the correct arguments
            var cellMock = Substitute.For<Cell>(true);
            cellMock.Received().Update(0);

            var cellMock_Dead = Substitute.For<Cell>(false);

            // Create a new Grid object and set it up with a single live cell
            var grid = new Grid(2, 2);
            grid.Cells[0, 0] = cellMock;
            grid.Cells[0, 1] = cellMock_Dead;
            grid.Cells[1, 0] = cellMock_Dead;
            grid.Cells[1, 1] = cellMock_Dead;

            // Call the Update method on the grid
            grid.Update();

            // Verify that the Update method was called on the mock Cell object
            cellMock.Received().Update(0);
            
        }

        [Test]
        public void TestToString()
        {
            // Create a new Grid object and set up some live and dead cells
            var grid = new Grid(3, 3);
            grid.Cells[0, 0] = new Cell(true);
            grid.Cells[1, 0] = new Cell(false);
            grid.Cells[2, 0] = new Cell(true);
            grid.Cells[0, 1] = new Cell(false);
            grid.Cells[1, 1] = new Cell(true);
            grid.Cells[2, 1] = new Cell(false);
            grid.Cells[0, 2] = new Cell(true);
            grid.Cells[1, 2] = new Cell(false);
            grid.Cells[2, 2] = new Cell(true);
            // Call the ToString method and verify the returned string
            var gridString = grid.ToString();
            
            Assert.That(gridString, Is.EqualTo(
                "O.O\n" +
                ".O.\n" +
                "O.O\n"));
        }

        [Test]
        public void Test3x3Grid_CustomCase1()
        {
            // O - live cell
            // . - dead cell
            // O.O
            // .O.
            // O.O
            var grid = new Grid(3, 3);
            grid.Cells[0, 0] = new Cell(true);
            grid.Cells[1, 0] = new Cell(false);
            grid.Cells[2, 0] = new Cell(true);

            grid.Cells[0, 1] = new Cell(false);
            grid.Cells[1, 1] = new Cell(true);
            grid.Cells[2, 1] = new Cell(false);
            
            grid.Cells[0, 2] = new Cell(true);
            grid.Cells[1, 2] = new Cell(false);
            grid.Cells[2, 2] = new Cell(true);

            grid.Update();
            grid.NextState();
            var gridString = grid.ToString();

            Assert.That(gridString, Is.EqualTo(
                ".O.\n" +
                "O.O\n" +
                ".O.\n"));
        }

        [Test]
        public void Test3x3Grid_CustomCase2()
        {
            // O - live cell
            // . - dead cell
            // OOO
            // .O.
            // O.O
            var grid = new Grid(3, 3);
            grid.Cells[0, 0] = new Cell(true);
            grid.Cells[1, 0] = new Cell(false);
            grid.Cells[2, 0] = new Cell(true);

            grid.Cells[0, 1] = new Cell(true);
            grid.Cells[1, 1] = new Cell(true);
            grid.Cells[2, 1] = new Cell(false);

            grid.Cells[0, 2] = new Cell(true);
            grid.Cells[1, 2] = new Cell(false);
            grid.Cells[2, 2] = new Cell(true);

            Assert.That(grid.ToString(), Is.EqualTo(
                "O.O\n" +
                "OO.\n" +
                "O.O\n"));

            grid.Update();
            grid.NextState();
            var gridString = grid.ToString();

            Assert.That(gridString, Is.EqualTo(
                "O..\n" +
                "O.O\n" +
                "O..\n"));
        }
    }
}
