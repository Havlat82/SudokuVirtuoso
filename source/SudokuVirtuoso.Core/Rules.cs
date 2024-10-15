using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuVirtuoso.Core
{
    // neni už lepší z toho udělat třídu?
    public struct Rules
    {
        /// <summary>
        /// Minimální počet nápověd / vyplněných polí mřížky, 
        /// aby bylo mělo sudoku právě jedno řešení a tím pádem šlo vyřešit
        /// </summary>
        public const int MINIMAL_CLUES_COUNT = 17;
        public const int EMPTY_CELL_VALUE = 0;
        public const int ALLOWED_COUNT = 1;
        
        public string Name { get; }
        public int GridSize { get; }
        public int SquareSize { get; }

        public int ClueCount { get; }

        // možná to dám do samostatný třídy
        public IEnumerable<int> ValidValues { get; }

        public int MinValue => ValidValues.Min();

        public int MaxValue => ValidValues.Max();

        // chtěl bych to jako množinu, aby bylo jasný že každá hodnota je unikátní
        

        public Rules(string name, int gridSize, int clueCount, List<int> validValues)
        {
            Name = name;
            GridSize = gridSize;
            SquareSize = (int)Math.Sqrt(gridSize);
            ClueCount = clueCount;
            ValidValues = validValues;
        }

        // která je lepší?
        private int SetValidClueCount_Defensive(int value) 
        { 
            return value < MINIMAL_CLUES_COUNT ? MINIMAL_CLUES_COUNT : value;
        }

        private int SetValidClueCount_ThrowException(int value)
        {
            if (value < MINIMAL_CLUES_COUNT)
                throw new ArgumentException($"Clue count must be at least {MINIMAL_CLUES_COUNT}");
            
            return value;
        }

        /// <summary>
        /// Vytvoří nová pravidla l.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="validValues"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Rules Create(string name)
        {
            // TODO: refaktorizace vytváření místo stringu enum
            var validValues = Enumerable.Range(1, 9).ToList();
            
            switch (name)
            {
                case
                    "Classic9x9Easy":
                    return new Rules("Classic9x9Easy", 9, 60, validValues);
                case
                    "Classic9x9Medium":
                    return new Rules("Classic9x9Medium", 9, 45, validValues);
                case
                    "Classic9x9Hard":
                    return new Rules("Classic9x9Hard", 9, 30, validValues);
                default:
                    throw new ArgumentException("This rule name is not supported!");
            }

        }
    }
}