using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Provides methods for validating sets of values used in Sudoku puzzles.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Checks if the given set of values is null or empty.
        /// </summary>
        /// <param name="values">The HashSet of values to check.</param>
        /// <returns>True if the set is null or empty, false otherwise.</returns>
        public static bool AreNullOrEmpty(HashSet<int> values)
        {
            if (values == null || values.Count == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Checks if the given set of values contains any invalid entries for a Sudoku puzzle.
        /// </summary>
        /// <param name="values">The HashSet of values to validate.</param>
        /// <returns>True if the set contains invalid values, false otherwise.</returns>
        public static bool AreNotValid(HashSet<int> values)
        {
            if (values.Contains(Rules.EMPTY_CELL_VALUE))
                return true;

            return false;
        }
    }
}