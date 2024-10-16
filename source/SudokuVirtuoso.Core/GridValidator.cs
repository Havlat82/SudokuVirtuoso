using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuVirtuoso.Core
{
    public static class GridValidator
    {
        public static bool IsGridValid(int[,] grid, Rules rules)
        {
            return HasValidDimensions(grid, rules) && HasValidValues(grid, rules);
        }

        private static bool HasValidDimensions(int[,] grid, Rules rules)
        {
            return grid != null // object exists & it is 2D array with valid dimensions
                && grid.GetLength(0) == rules.GridSize
                && grid.GetLength(1) == rules.GridSize;
        }

        private static bool HasValidValues(int[,] grid, Rules rules)
        {
            return grid.Cast<int>().All(cellValue => IsValidValue(cellValue, rules));
        }

        private static bool IsValidValue(int value, Rules rules)
        {
            var min = rules.ValidValues.Min();
            var max = rules.ValidValues.Max();

            return value == Rules.EMPTY_CELL_VALUE || (value >= min && value <= max);
        }
    }
}