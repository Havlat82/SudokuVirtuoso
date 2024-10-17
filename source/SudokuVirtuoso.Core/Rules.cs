using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuVirtuoso.Core
{
    public class Rules
    {
        /// <summary>
        /// Minimální počet nápověd / vyplněných polí mřížky,
        /// aby bylo mělo sudoku právě jedno řešení a tím pádem šlo vyřešit
        /// </summary>
        // možná budu měnit názvy
        public const int MINIMAL_CLUES_COUNT = 17;

        public const int EMPTY_CELL_VALUE = 0;
        public const int ALLOWED_UNIQUE_VALUE_COUNT = 1;

        // možná odeberu pokud nechám tak jen kvůli tomu, aby si člověk mohl udělat pravidla na míru
        public string Name { get; }

        // kontrola validity při vytváření
        // udělat public setter methdodu pro gettery
        public int GridSize { get; }
        public int SquareSize { get; }

        public int ClueCount { get; }

        public ValidValues ValidValues { get; }

        // pokud zustane Name, tak se budu vytvářet z jiných vlastnosti
        private Rules(string name, int gridSize, int clueCount, ValidValues validValues)
        {
            Name = name;
            GridSize = gridSize;
            SquareSize = (int)Math.Sqrt(gridSize);
            ClueCount = SetValidClueCount(clueCount);
            ValidValues = validValues;
        }

        // pravděpodobně změnit na public a void
        private int SetValidClueCount(int value)
        {
            if (value < MINIMAL_CLUES_COUNT)
                throw new ArgumentException($"Clue count must be at least {MINIMAL_CLUES_COUNT}");

            return value;
        }

        public static Rules Create(string name, ValidValues validValues)
        {
            // TODO: refaktorizace vytváření místo stringu enum
            
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