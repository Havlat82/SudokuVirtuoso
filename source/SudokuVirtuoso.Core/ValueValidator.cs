using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Provides methods for validating sets of values used in sudoku puzzles.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Checks if the given set of values is null or empty.
        /// </summary>
        /// <param name="values">The HashSet of values to check.</param>
        /// <returns>True if the set is null or empty, false otherwise.</returns>
        public static bool AreNullOrEmpty(ValidValues values)
        {
            if (values == null || values.Get() == null || values.Get().Count == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Checks if the given set of values has invalid length or contains any invalid entries.
        /// </summary>
        /// <param name="values">The HashSet of values to check.</param>
        /// <returns>True if the set contains invalid values, false otherwise.</returns>
        public static bool AreNotValid(ValidValues validValues)
        {
            var values = validValues.Get();

            if (ContainsEmptyCellValue(values))
                return true;

            if (HasInvalidLength(values))
                return true;

            return false;
        }

        private static bool ContainsEmptyCellValue(HashSet<int> values)
        {
            return values.Contains(Constants.EMPTY_CELL_VALUE);
        }

        private static bool HasInvalidLength(HashSet<int> values)
        {
            return values.Count != Rules.GridSize;
        }
    }
}