using GOLconsole.Source;

namespace GameOfLife
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void TestConstructor()
        {
            // Test that a new cell is correctly initialized as dead
            var cell = new Cell(false);
            Assert.IsFalse(cell.IsAlive);

            // Test that a new cell is correctly initialized as alive
            cell = new Cell(true);
            Assert.IsTrue(cell.IsAlive);
        }

        [Test]
        public void TestUpdate()
        {
            // Test that a live cell with fewer than two live neighbors dies
            var cell = new Cell(true);
            cell.Update(0);
            Assert.IsFalse(cell.NextState);
            cell.Update(1);
            Assert.IsFalse(cell.NextState);

            // Test that a live cell with two or three live neighbors lives on
            cell.Update(2);
            Assert.IsTrue(cell.NextState);
            cell.Update(3);
            Assert.IsTrue(cell.NextState);

            // Test that a live cell with more than three live neighbors dies
            cell.Update(4);
            Assert.IsFalse(cell.NextState);
            cell.Update(5);
            Assert.IsFalse(cell.NextState);

            // Test that a dead cell with exactly three live neighbors becomes alive
            cell = new Cell(false);
            cell.Update(3);
            Assert.IsTrue(cell.NextState);

            // Test that a dead cell with any other number of live neighbors stays dead
            cell.Update(0);
            Assert.IsFalse(cell.NextState);
            cell.Update(1);
            Assert.IsFalse(cell.NextState);
            cell.Update(2);
            Assert.IsFalse(cell.NextState);
            cell.Update(4);
            Assert.IsFalse(cell.NextState);
            cell.Update(5);
            Assert.IsFalse(cell.NextState);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void GameTest_Rule1(int neighbor)
        {
            // A live cell with fewer than two live neighbors should die
            var cell = new Cell(true);
            cell.Update(neighbor);
            Assert.IsFalse(cell.NextState);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void GameTest_Rule2(int neighbor)
        {
            // A live cell with two or three live neighbors should survive
            var cell = new Cell(true);
            cell.Update(neighbor);
            Assert.IsTrue(cell.NextState);
        }

        [Test]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(100)]
        public void GameTest_Rule3(int neighbor)
        {
            // A live cell with more than three live neighbors should die
            var cell = new Cell(true);
            cell.Update(neighbor);
            Assert.IsFalse(cell.NextState);
        }

        [Test]
        [TestCase(3)]
        public void GameTest_Rule4(int neighbor)
        {
            // A live cell with more than three live neighbors should die
            var cell = new Cell(false);
            cell.Update(neighbor);
            Assert.IsTrue(cell.NextState);
        }

        [Test]
        [TestCase(2)]
        [TestCase(4)]
        public void GameTest_Rule4_Fails(int neighbor)
        {
            // A live cell with more than three live neighbors should die
            var cell = new Cell(false);
            cell.Update(neighbor);
            Assert.IsFalse(cell.NextState);
        }

    }
}