using SudokuVirtuoso.Core;

namespace SudokuVirtuoso.Core.Tests
{
    [TestFixture]
    public class SudokuSolverTests
    {
        private ISudokuSolver _solver;

        [SetUp]
        public void Setup()
        {
            //_solver = new OriginalSolver();
        }

        [Test]
        public void Solve_ValidPuzzle_ReturnsTrue()
        {
            // Arrange
            int[,] puzzle = {
                {5,3,0,0,7,0,0,0,0},
                {6,0,0,1,9,5,0,0,0},
                {0,9,8,0,0,0,0,6,0},
                {8,0,0,0,6,0,0,0,3},
                {4,0,0,8,0,3,0,0,1},
                {7,0,0,0,2,0,0,0,6},
                {0,6,0,0,0,0,2,8,0},
                {0,0,0,4,1,9,0,0,5},
                {0,0,0,0,8,0,0,7,9}
            };

            // Act
            bool solved = _solver.SolvePuzzle(puzzle);

            // Assert
            Assert.IsTrue(solved);
            // Add more specific assertions to check if the solution is correct
        }

        [Test]
        public void Solve_InvalidPuzzle_ReturnsFalse()
        {
            // Arrange
            int[,] invalidPuzzle = {
                {5,3,0,0,7,0,0,0,0},
                {5,0,0,1,9,5,0,0,0}, // Note the duplicate 5 in the second row
                {0,9,8,0,0,0,0,6,0},
                {8,0,0,0,6,0,0,0,3},
                {4,0,0,8,0,3,0,0,1},
                {7,0,0,0,2,0,0,0,6},
                {0,6,0,0,0,0,2,8,0},
                {0,0,0,4,1,9,0,0,5},
                {0,0,0,0,8,0,0,7,9}
            };

            // Act
            bool solved = _solver.SolvePuzzle(invalidPuzzle);

            // Assert
            Assert.IsFalse(solved);
        }
    }
}

