using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    /// <summary>
    /// Holds data about a Sudoku position
    /// </summary>
    public class Position
    {
        public int Row { get; set; }

        public int Column { get; set; }
        public int Index { get; set; }
        public int SubGridIndex { get; set; }
        public int SubGridRow { get; set; }
        public int SubGridColumn { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
            Index = row * 9 + column;
            SubGridRow = row % 3;
            SubGridColumn = column % 3;
            SubGridIndex = (SubGridRow * 3) + SubGridColumn;
        }

        public Position(int index)
        {
            //TODO implement Row and Column

        }

        public static List<Position> GetPositionsInSubGrid(int subGridIndex)
        {
            if (subGridIndex < 0 || subGridIndex > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(subGridIndex), "Subgrid index must be between 0 and 8 inclusive.");
            }

            List<Position> positions = new List<Position>();
            int si = subGridIndex;
            //int subGridRow = subGridIndex / 3;
            //int subGridColumn = subGridIndex % 3;

            //int startRow = subGridRow * 3;
            //int startColumn = subGridColumn * 3;

            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row * 3 < 9; row++)               
                {
                    var p = new Position(row, col);
                    if (p.SubGridIndex == si)
                        positions.Add(p);

                    si++;
                }
            }

            return positions;
        }

        public override string ToString()
        {
            return $"Position: [{Row} : {Column}; Index: {Index}; (SubGridIndex: {SubGridIndex}, SubRow {SubGridRow} :  SubColumn {SubGridColumn})]";
        }
    }
}
