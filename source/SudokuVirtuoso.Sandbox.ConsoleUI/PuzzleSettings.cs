using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    public static class PuzzleSettings
    {
        public const int MINIMAL_CLUES_COUNT = 17;
        public const int EMPTY_CELL_VALUE = 0;

        public static int GridSize { get; set; } = 9;
        
        public static int BoxSize { get; set; } = 3;

        public static int ClueCount { get; set; } = 60;

        public static List<int> ValidValues { get; set; } = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
}
