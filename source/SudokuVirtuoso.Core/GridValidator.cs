using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Provides methods for validating sudoku grids.
    /// </summary>
    public static class GridValidator
    {
        /// <summary>
        /// Checks if the size of inner grid of the sudoku puzzle is less than the minimum size.
        /// </summary>
        /// <param name="size">The size of inner grid to check.</param>
        /// <returns>True if the <paramref name="size"/> is less than the minimum, false otherwise.</returns>
        public static bool IsSubGridSizeInvalid(int size)
        {
            return size < Constants.MIN_SUBGRID_SIZE;
        }

        /// <summary>
        /// Checks if the number of clues (displayed values) ​​is less than the minimum number of clues.
        /// </summary>
        /// <param name="count">The number of clues.</param>
        /// <returns>True if the <paramref name="count"/> is less than the minimum, false otherwise.</returns>
        public static bool IsClueCountInvalid(int count)
        {
            return count < Constants.MIN_CLUE_COUNT;
        }

        /// <summary>
        /// Checks if the given grid is valid according to the specified rules.
        /// </summary>
        /// <param name="grid">The sudoku grid to validate.</param>
        /// <returns>True if the grid is valid, false otherwise.</returns>
        public static bool IsGridValid(int[,] grid)
        {
            return HasValidDimensions(grid) && HasValidValues(grid);
        }

        

        /// <summary>
        /// Checks if the grid has valid dimensions according to the specified rules.
        /// </summary>
        /// <param name="grid">The Sudoku grid to check.</param>
        /// <param name="rules">The rules specifying the expected grid size.</param>
        /// <returns>True if the grid has valid dimensions, false otherwise.</returns>
        private static bool HasValidDimensions(int[,] grid)
        {
            return grid != null // object exists & it is 2D array with valid dimensions
                && grid.GetLength(0) == Rules.GridSize
                && grid.GetLength(1) == Rules.GridSize;
        }

        private static bool HasValidValues(int[,] grid)
        {
            return grid.Cast<int>().All(cellValue => IsValidValue(cellValue));
        }

        private static bool IsValidValue(int value)
        {
            var min = Rules.ValidValues.Min;
            var max = Rules.ValidValues.Max;

            return value == Constants.EMPTY_CELL_VALUE || (value >= min && value <= max);
        }
    }
}