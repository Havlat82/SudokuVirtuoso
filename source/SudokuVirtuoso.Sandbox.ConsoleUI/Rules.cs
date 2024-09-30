using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    public struct Rules
    {
        public const int MINIMAL_CLUES_COUNT = 17;
        public const int EMPTY_CELL_VALUE = 0;
        public const int MAX_VALUE = 9;

        public int GridSize { get; }
        public int BoxSize { get; }

        public int ClueCount { get; }

        public IEnumerable<int> ValidValues { get; }

        public Rules(int gridSize, int boxSize, int clueCount, IEnumerable<int> validValues)
        {
            GridSize = gridSize;
            BoxSize = boxSize;
            ClueCount = clueCount;
            ValidValues = validValues;
        }
        public static Rules Create(string name)
        {
            var validValues = Enumerable.Range(1, 9).ToList();
            var max = validValues.Max();
            
            switch (name)
            {
                case
                    "Classic9x9Easy": return new Rules(9, 3, 60, validValues);
                case
                    "Classic9x9Medium": return new Rules(9, 3, 45, validValues);
                case
                    "Classic9x9Hard": return new Rules(9, 3, 30, validValues);
                default:
                    throw new ArgumentException("This rule name is not supported!");
            }

        }
    }
}
