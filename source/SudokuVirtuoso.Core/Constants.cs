namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Constants used in the SudokuVirtuoso project. THEY SHOULD NOT BE MODIFIED.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The minimum number of clues required for a sudoku puzzle to have a unique solution.
        /// </summary>
        public const int MIN_CLUE_COUNT = 17;

        /// <summary>
        /// The minimum size of the sudoku inner square.
        /// </summary>
        public const int MIN_SUBGRID_SIZE = 2;

        /// <summary>
        /// The value representing an empty cell in the sudoku grid.
        /// </summary>
        public const int EMPTY_CELL_VALUE = 0;

        /// <summary>
        /// The number of times a value can be wriiten in each row, column, and inner square.
        /// </summary>
        public const int WRITTEN_VALUE_LIMIT = 1;
    }
}