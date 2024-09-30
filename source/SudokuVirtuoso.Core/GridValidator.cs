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
            return grid != null
                && grid.GetLength(0) == rules.GridSize
                && grid.GetLength(1) == rules.GridSize;
        }

        private static bool HasValidValues(int[,] grid, Rules rules)
        {
            var min = rules.ValidValues.Min();
            var max = rules.ValidValues.Max();

            var result = grid.Cast<int>()
                             .All(cellValue => cellValue == Rules.EMPTY_CELL_VALUE
                                                         || (cellValue >= min && cellValue <= max));

            return result;
        }
    }
}
