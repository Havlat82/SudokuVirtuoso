namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Provides an abstract base class for Sudoku solvers.
    /// </summary>
    public abstract class SudokuSolver : ISudokuSolver
    {
        /// <summary>
        /// Generates a new Sudoku puzzle.
        /// </summary>
        /// <returns>A 2D array representing the generated Sudoku puzzle.</returns>
        public abstract int[,] GeneratePuzzle();

        /// <summary>
        /// Solves the given Sudoku puzzle.
        /// </summary>
        /// <param name="sudokuGrid">The Sudoku puzzle to solve.</param>
        /// <returns>True if the puzzle is solvable, false otherwise.</returns>
        public abstract bool SolvePuzzle(int[,] sudokuGrid);

        /// <summary>
        /// Initializes a new instance of the SudokuSolver class.
        /// </summary>
        /// <param name="puzzleType">The puzzle type that defines the rules for the sudoku puzzle.</param>
        protected SudokuSolver(PuzzleType puzzleType)
        {
            SetRules(puzzleType);
        }

        private void SetRules(PuzzleType puzzleType)
        {
            switch (puzzleType)
            {
                case PuzzleType.Classic9x9Easy:
                    Rules.TrySet(3, 60, new ValidValues(1, 9));
                    break;

                case PuzzleType.Classic9x9Medium:
                    Rules.TrySet(3, 45, new ValidValues(1, 9));
                    break;

                case PuzzleType.Classic9x9Hard:
                    Rules.TrySet(3, 30, new ValidValues(1, 9));
                    break;
            }
        }
    }
}