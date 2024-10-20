using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Provides methods for validating Sudoku grids.
    /// </summary>
    public static class GridValidator
    {
        /// <summary>
        /// Validates whether the given grid is valid according to the specified rules.
        /// </summary>
        /// <param name="grid">The Sudoku grid to validate.</param>
        /// <param name="rules">The rules to apply for validation.</param>
        /// <returns>True if the grid is valid, false otherwise.</returns>
        public static bool IsGridValid(int[,] grid, Rules rules)
        {
            return HasValidDimensions(grid, rules) && HasValidValues(grid, rules);
        }

        /// <summary>
        /// Checks if the grid has valid dimensions according to the specified rules.
        /// </summary>
        /// <param name="grid">The Sudoku grid to check.</param>
        /// <param name="rules">The rules specifying the expected grid size.</param>
        /// <returns>True if the grid has valid dimensions, false otherwise.</returns>
        private static bool HasValidDimensions(int[,] grid, Rules rules)
        {
            return grid != null // object exists & it is 2D array with valid dimensions
                && grid.GetLength(0) == rules.GridSize
                && grid.GetLength(1) == rules.GridSize;
        }

        /// <summary>
        /// Checks if all values in the grid are valid according to the specified rules.
        /// </summary>
        /// <param name="grid">The Sudoku grid to check.</param>
        /// <param name="rules">The rules specifying the valid values.</param>
        /// <returns>True if all values in the grid are valid, false otherwise.</returns>
        private static bool HasValidValues(int[,] grid, Rules rules)
        {
            return grid.Cast<int>().All(cellValue => IsValidValue(cellValue, rules));
        }

        /// <summary>
        /// Determines if a single value is valid according to the specified rules.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="rules">The rules specifying the valid value range.</param>
        /// <returns>True if the value is valid, false otherwise.</returns>
        private static bool IsValidValue(int value, Rules rules)
        {
            var min = rules.ValidValues.Min;
            var max = rules.ValidValues.Max;

            return value == Rules.EMPTY_CELL_VALUE || (value >= min && value <= max);
        }
    }
}