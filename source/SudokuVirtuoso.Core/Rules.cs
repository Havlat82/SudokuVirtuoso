using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Represents the rules and configuration for a sudoku puzzle.
    /// </summary>
    public static class Rules
    {
        /// <summary>
        /// Gets the size of the sudoku grid (e.g., 9 for a 9x9 grid).
        /// </summary>
        public static int GridSize => SubGridSize * SubGridSize;

        /// <summary>
        /// Gets the size of inner square within the grid (e.g., 3 for a 9x9 grid).
        /// </summary>
        public static int SubGridSize { get; private set; }

        /// <summary>
        /// Gets the number of clues (pre-filled cells) in the puzzle.
        /// </summary>
        public static int ClueCount { get; private set; }

        /// <summary>
        /// Gets the set of valid values for the sudoku puzzle.
        /// </summary>
        public static ValidValues ValidValues { get; private set; }

        /// <summary>
        /// Tries to set the public static properties of <see cref="Rules"/> class.
        /// </summary>
        /// <param name="squareSize">The size of the sudoku inner square.</param>
        /// <param name="clueCount">The number of clues in the puzzle.</param>
        /// <param name="validValues">The set of valid values for the puzzle.</param>
        /// <exception cref="ArgumentException">Thrown when values are invalid.</exception>
        public static void TrySet(int squareSize, int clueCount, ValidValues validValues)
        {
            TrySetSubGridSize(squareSize);
            TrySetClueCount(clueCount);
            TrySetValidValues(validValues);
        }

        private static void TrySetClueCount(int value)
        {
            if (GridValidator.IsClueCountInvalid(value))
                throw new ArgumentException($"Clue count must be at least {Constants.MIN_CLUE_COUNT}");

            ClueCount = value;
        }

        private static void TrySetSubGridSize(int value)
        {
            if (GridValidator.IsSubGridSizeInvalid(value))
                throw new ArgumentException($"SubGrid size must be at least {Constants.MIN_SUBGRID_SIZE}");

            SubGridSize = value;
        }

        private static void TrySetValidValues(ValidValues newValues)
        {
            if (ValueValidator.AreNullOrEmpty(newValues))
                throw new ArgumentException("Values cannot be null or empty.", nameof(newValues));

            if (ValueValidator.AreNotValid(newValues))
                throw new ArgumentException("The provided values are not valid for Sudoku.");

            ValidValues = newValues;
        }
    }
}