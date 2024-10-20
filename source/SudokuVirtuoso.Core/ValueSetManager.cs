using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Manages sets of values for rows, columns, and squares in a Sudoku puzzle.
    /// </summary>
    public sealed class ValueSetManager
    {
        /// <summary>
        /// Initializes a new instance of the ValueSetManager class.
        /// </summary>
        /// <param name="rules">The rules defining the Sudoku puzzle structure.</param>
        public ValueSetManager(Rules rules)
        {
            CreateNewValueSets(rules);
        }

        /// <summary>
        /// Creates the new value sets for rows, columns, and squares based on the given rules.
        /// </summary>
        /// <param name="rules">The rules defining the Sudoku puzzle structure.</param>
        public void CreateNewValueSets(Rules rules)
        {
            _rowValues = new HashSet<int>[rules.GridSize];
            _columnValues = new HashSet<int>[rules.GridSize];
            _squareValues = new HashSet<int>[rules.GridSize];

            for (int i = 0; i < rules.GridSize; i++)
            {
                _rowValues[i] = new HashSet<int>();
                _columnValues[i] = new HashSet<int>();
                _squareValues[i] = new HashSet<int>();
            }
        }

        /// <summary>
        /// Adds a value to the corresponding row, column, and square sets.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="col">The column index.</param>
        /// <param name="sgi">The square group index.</param>
        /// <param name="value">The value to add.</param>
        public void AddValueInPositionToValueSets(int row, int col, int sgi, int value)
        {
            _rowValues[row].Add(value);
            _columnValues[col].Add(value);
            _squareValues[sgi].Add(value);
        }

        /// <summary>
        /// Removes a value from the corresponding row, column, and square sets.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="col">The column index.</param>
        /// <param name="sgi">The square group index.</param>
        /// <param name="value">The value to remove.</param>
        public void RemoveValueInPositionFromSets(int row, int col, int sgi, int value)
        {
            _rowValues[row].Remove(value);
            _columnValues[col].Remove(value);
            _squareValues[sgi].Remove(value);
        }

        /// <summary>
        /// Checks if a value is present in the specified row.
        /// </summary>
        /// <param name="row">The row index to check.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the value is in the row, false otherwise.</returns>
        public bool IsValueInRow(int row, int value)
        {
            return _rowValues[row].Contains(value);
        }

        /// <summary>
        /// Checks if a value is present in the specified column.
        /// </summary>
        /// <param name="col">The column index to check.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the value is in the column, false otherwise.</returns>
        public bool IsValueInColumn(int col, int value)
        {
            return _columnValues[col].Contains(value);
        }

        /// <summary>
        /// Checks if a value is present in the specified square.
        /// </summary>
        /// <param name="sgi">The square group index to check.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the value is in the square, false otherwise.</returns>
        public bool IsValueInSquare(int sgi, int value)
        {
            return _squareValues[sgi].Contains(value);
        }

        private HashSet<int>[] _rowValues;
        private HashSet<int>[] _columnValues;
        private HashSet<int>[] _squareValues;
    }
}