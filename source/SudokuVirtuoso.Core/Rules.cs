using System.Collections.Generic;

namespace SudokuVirtuoso.Core
{
    public class Rules
    {
        public static int EMPTY_CELL_VALUE { get; internal set; }
        public int GridSize { get; internal set; }
        public IEnumerable<int> ValidValues { get; internal set; }
    }
}