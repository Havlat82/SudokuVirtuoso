using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Represents the rules and configuration for a Sudoku puzzle.
    /// </summary>
    public class Rules
    {
        // TODO: refaktorizace
        // možná budu měnit názvy        
        // kontrola validity při vytváření
        // udělat public setter methdodu pro gettery
        // Name možná odeberu pokud nechám tak jen kvůli tomu, 
        // aby si člověk mohl udělat pravidla na míru
        // pokud zustane Name, tak se budu vytvářet z jiných vlastnosti
        
        /// <summary>
        /// The minimum number of clues required for a Sudoku puzzle to have a unique solution.
        /// </summary>
        public const int MINIMAL_CLUES_COUNT = 17;

        /// <summary>
        /// The value representing an empty cell in the Sudoku grid.
        /// </summary>
        public const int EMPTY_CELL_VALUE = 0;

        /// <summary>
        /// The number of times a unique value is allowed in each row, column, and square.
        /// </summary>
        public const int ALLOWED_UNIQUE_VALUE_COUNT = 1;

        
        /// <summary>
        /// Gets the name of the rule set.
        /// </summary>
        public string Name { get; } 

        /// <summary>
        /// Gets the size of the Sudoku grid (e.g., 9 for a 9x9 grid).
        /// </summary>
        public int GridSize { get; }

        /// <summary>
        /// Gets the size of each square within the grid (e.g., 3 for a 9x9 grid).
        /// </summary>
        public int SquareSize { get; }

        /// <summary>
        /// Gets the number of clues (pre-filled cells) in the puzzle.
        /// </summary>
        public int ClueCount { get; }

        /// <summary>
        /// Gets the set of valid values for the Sudoku puzzle.
        /// </summary>
        public ValidValues ValidValues { get; }

        /// <summary>
        /// Initializes a new instance of the Rules class.
        /// </summary>
        /// <param name="name">The name of the rule set.</param>
        /// <param name="gridSize">The size of the Sudoku grid.</param>
        /// <param name="clueCount">The number of clues in the puzzle.</param>
        /// <param name="validValues">The set of valid values for the puzzle.</param>
        private Rules(string name, int gridSize, int clueCount, ValidValues validValues)
        {
            Name = name;
            GridSize = gridSize;
            SquareSize = (int)Math.Sqrt(gridSize);
            ClueCount = SetValidClueCount(clueCount);
            ValidValues = validValues;
        }

        /// <summary>
        /// Validates and sets the clue count.
        /// </summary>
        /// <param name="value">The proposed clue count.</param>
        /// <returns>The validated clue count.</returns>
        /// <exception cref="ArgumentException">Thrown when the clue count is less than the minimum required.</exception>
        private int SetValidClueCount(int value)
        {
            // pravděpodobně změnit na public a void, možná to změnim uplně..
            // validace parametrů a tohle  nebude potřeba tady budu volat value validator

            if (value < MINIMAL_CLUES_COUNT)
                throw new ArgumentException($"Clue count must be at least {MINIMAL_CLUES_COUNT}");

            return value;
        }

        /// <summary>
        /// Creates a Rules instance based on a predefined rule set name.
        /// </summary>
        /// <param name="name">The name of the predefined rule set.</param>
        /// <param name="validValues">The set of valid values for the puzzle.</param>
        /// <returns>A new Rules instance.</returns>
        /// <exception cref="ArgumentException">Thrown when an unsupported rule name is provided.</exception>
        public static Rules Create(string name, ValidValues validValues)
        {
            // TODO: refaktorizace vytváření místo stringu enum
            // todo: mebudude tam retrurn ale volání privátních statických
            // metody, která ty pravidla vytvoří
            // chci se zbavit všech magic numbers..
            
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