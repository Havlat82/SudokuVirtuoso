namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Implements a backtracking algorithm to solve and generate Sudoku puzzles.
    /// </summary>
    public class BacktrackingSolver : SudokuSolver
    {
        private ValueSetManager _setManager;

        /// <summary>
        /// Initializes a new instance of the BacktrackingSolver class.
        /// </summary>
        /// <param name="rules">The rules defining the Sudoku puzzle structure.</param>
        public BacktrackingSolver(Rules rules) : base(rules)
        {
            _setManager = new ValueSetManager(rules);
        }

        /// <summary>
        /// Generates a new Sudoku puzzle.
        /// </summary>
        /// <returns>A 2D array representing the generated Sudoku puzzle.</returns>
        public override int[,] GeneratePuzzle()// bude generovat třídu sudokusheet
        {
            var grid = CreateGridWithValidValues();
            // hide cells
            return grid;
        }

        /// <summary>
        /// Creates a fully filled Sudoku grid with valid values.
        /// </summary>
        /// <returns>A 2D array representing a fully filled Sudoku grid.</returns>
        private int[,] CreateGridWithValidValues()
        {
            var grid = new int[_rules.GridSize, _rules.GridSize];

            _ = FillGrid(grid, true);

            return grid;
        }

        /// <summary>
        /// Solves the given Sudoku puzzle.
        /// </summary>
        /// <param name="sudokuGrid">The Sudoku puzzle to solve.</param>
        /// <returns>True if the puzzle is solvable, false otherwise.</returns>
        public override bool SolvePuzzle(int[,] sudokuGrid)// bude řešit třídu sudokusheet změnit v abstrakcích
        {
            if (!CanBeSolved(sudokuGrid))
                return false;

            return FillGrid(sudokuGrid);
        }

        /// <summary>
        /// Checks if the given Sudoku grid can be solved.
        /// </summary>
        /// <param name="grid">The Sudoku grid to check.</param>
        /// <returns>True if the grid can be solved, false otherwise.</returns>
        public bool CanBeSolved(int[,] grid)
        {
            for (var row = 0; row < _rules.GridSize; row++)
                for (var col = 0; col < _rules.GridSize; col++)
                    if (grid[row, col] != Rules.EMPTY_CELL_VALUE)
                    {
                        // get the square group index
                        var sgi = ((row / _rules.SquareSize) * _rules.SquareSize) + (col / _rules.SquareSize);
                        var value = grid[row, col];

                        if (!CanWriteValueToPosition(value, row, col, sgi))
                            return false; // We've found a duplicate
                        else
                            _setManager.AddValueInPositionToValueSets(row, col, sgi, value);
                    }

            return true;
        }

        /// <summary>
        /// Fills the Sudoku grid using a backtracking algorithm.
        /// </summary>
        /// <param name="grid">The Sudoku grid to fill.</param>
        /// <param name="newPuzzle">Indicates whether this is a new puzzle generation.</param>
        /// <returns>True if the grid was successfully filled, false otherwise.</returns>
        private bool FillGrid(int[,] grid, bool newPuzzle = false)
        {
            // TODO: předělat na iterativní způsob

            var numbers = _rules.ValidValues.Get();

            for (var row = 0; row < _rules.GridSize; row++)
                for (var col = 0; col < _rules.GridSize; col++)
                {
                    if (grid[row, col] == Rules.EMPTY_CELL_VALUE)
                    {
                        // get the square group index
                        var sgi = ((row / _rules.SquareSize) * _rules.SquareSize) + (col / _rules.SquareSize);

                        if (newPuzzle) // pravděpodobně změnim název
                            numbers = ValueShuffler.Shuffle(numbers);

                        foreach (var value in numbers)
                        {
                            if (CanWriteValueToPosition(value, row, col, sgi))
                            {
                                _setManager.AddValueInPositionToValueSets(row, col, sgi, value);
                                grid[row, col] = value;

                                if (FillGrid(grid, newPuzzle))
                                    return true;

                                // If we couldn't complete the grid with this value, backtrack
                                _setManager.RemoveValueInPositionFromSets(row, col, sgi, value);
                                grid[row, col] = 0;
                            }
                        }

                        return false; // Trigger backtracking
                    }
                }

            return true;
        }

        /// <summary>
        /// Checks if a value can be written to a specific position in the Sudoku grid.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="r">The row index.</param>
        /// <param name="c">The column index.</param>
        /// <param name="sgi">The square group index.</param>
        /// <returns>True if the value can be written, false otherwise.</returns>
        private bool CanWriteValueToPosition(int value, int r, int c, int sgi)
        {
            var IsNotInRow = !_setManager.IsValueInRow(value, r);
            var IsNotInColumn = !_setManager.IsValueInColumn(value, c);
            var IsNotInSquare = !_setManager.IsValueInSquare(value, sgi);

            return (IsNotInRow && IsNotInColumn && IsNotInSquare);
        }
    }
}