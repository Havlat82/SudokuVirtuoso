using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Encapsulates the arrays of sets of values ​​written into a row, column, and inner square in sudoku grid.
    /// </summary>
    public sealed class WrittenValues
    {
        /// <summary>
        /// Initializes a new instance of the WrittenValues class.
        /// </summary>      
        public WrittenValues()
        {
            CreateNewValueSets();
        }

        /// <summary>
        /// Creates the new value sets for rows, columns, and inner squares based on the given rules.
        /// </summary>
        public void CreateNewValueSets()
        {
            _rowValues = new HashSet<int>[Rules.GridSize];
            _columnValues = new HashSet<int>[Rules.GridSize];
            _squareValues = new HashSet<int>[Rules.GridSize];

            for (int i = 0; i < Rules.GridSize; i++)
            {
                _rowValues[i] = new HashSet<int>();
                _columnValues[i] = new HashSet<int>();
                _squareValues[i] = new HashSet<int>();
            }
        }

        /// <summary>
        /// Adds a given value to value sets for given position. 
        /// </summary>
        /// <param name="position">The position that determines the sets to add the value to.</param>
        /// <param name="value">The value to add.</param>
        public void AddValueAtPositionToWrittenValues(int value, Position position)
        {
            _rowValues[position.Row].Add(value);
            _columnValues[position.Column].Add(value);
            _squareValues[position.SubGridIndex].Add(value);
        }

        /// <summary>
        /// Removes a given value from value sets for given position. 
        /// </summary>
        /// <param name="position">The position that determines the sets to remove the value from.</param>
        /// <param name="value">The value to remove.</param>
        public void RemoveValueAtPositionFromWrittenValues(int value, Position position)
        {
            _rowValues[position.Row].Remove(value);
            _columnValues[position.Column].Remove(value);
            _squareValues[position.SubGridIndex].Remove(value);
        }

        /// <summary>
        /// Checks if a given value in given position is written in the corresponding row, column or square sets.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="position">The position to check</param>
        /// <returns>True if the value is in the set for the given position, false otherwise.</returns>
        public bool IsValueAtPosition(int value, Position position)
        {
            var IsInRow = _rowValues[position.Row].Contains(value);
            var IsInColumn = _columnValues[position.Column].Contains(value);
            var IsInSquare = _squareValues[position.SubGridIndex].Contains(value);

            return (IsInRow || IsInColumn || IsInSquare);
        }

        /// <summary>
        /// Checks if a given value in given position is not written in the corresponding row, column or square set.
        /// For better clarity. People can overlook negation sign "!" in conditions.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="position">The position to check</param>
        /// <returns>True if the value is not in the set for the given position, false otherwise.</returns>
        public bool IsNotValueAtPosition(int value, Position position) => !IsValueAtPosition(value, position);
        
        private HashSet<int>[] _rowValues;
        private HashSet<int>[] _columnValues;
        private HashSet<int>[] _squareValues;
    }
}