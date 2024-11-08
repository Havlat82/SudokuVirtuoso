using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Represents a position in the sudoku grid.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The row number of the position in the grid.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// The column number of the position in the grid.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// The sequence number of the position in the grid.
        /// </summary>
        public int Index => Row * Rules.GridSize + Column;

        /// <summary>
        /// The sequence number of the position in the inner grid.
        /// </summary>
        public int SubGridIndex => SubGridRow * Rules.SubGridSize + SubGridColumn;

        /// <summary>
        /// The row number of the position in the inner grid.
        /// </summary>
        public int SubGridRow => Row / Rules.SubGridSize;

        /// <summary>
        /// The column number of the position in the inner grid.
        /// </summary>
        public int SubGridColumn => Column / Rules.SubGridSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="row">The row of the new position.</param>
        /// <param name="column">The column of the new position.</param>
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Returns a string representation of the <see cref="Position"/> class
        /// </summary>
        /// <returns>A string representation of the <see cref="Position"/> class.</returns>
        public override string ToString()
        {
            return $"Position in sudoku grid: [(Row: {Row}, Column: {Column}, Index: {Index}) - Inner grid position: (SubGridIndex: {SubGridIndex}, SubGridRow: {SubGridRow}, SubGridColumn: {SubGridColumn})]";
        }
    }
}
