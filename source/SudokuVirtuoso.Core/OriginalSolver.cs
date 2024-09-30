using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuVirtuoso.Core
{
    public class OriginalSolver : SudokuSolver
    {
        public OriginalSolver(Rules rules) : base(rules)
        {
        }

        public override int[,] GeneratePuzzle()
        {
            var grid = CreateGridWithValidValues();
            return grid;
        }

        private int[,] CreateGridWithValidValues()
        {
            var grid = new int[_rules.GridSize, _rules.GridSize];

            FillGrid(grid);

            return grid;
        }

        private bool FillGrid(int[,] sheet, int row = 0, int column = 0)
        {
            if (column == _rules.GridSize)
            {
                row++;
                column = 0;
            }
            if (row == _rules.GridSize)
                return true; // We've filled the entire grid successfully

            var subGridIndex = ((row / 3) * 3) + (column / 3);
            var numbers = Enumerable.Range(1, 9).OrderBy(x => _random.Next()).ToList();

            foreach (var value in numbers)
            {
                if (!IsValueInPosition(value, row, column, subGridIndex))
                {
                    AddValueInPositionToValueSets(row, column, subGridIndex, value);
                    sheet[row, column] = value;

                    if (FillGrid(sheet, row, column + 1))
                        return true;

                    // If we couldn't complete the grid with this value, backtrack
                    RemoveValueFromPositionSets(row, column, subGridIndex, value);
                    sheet[row, column] = 0;
                }
            }

            return false; // Trigger backtracking
        }

        private bool IsValueInPosition(int value, int r, int c, int sgi)
        {
            var valueIsInRow = _rowValues[r].Contains(value);
            var valueIsInColumn = _columnValues[c].Contains(value);
            var valueIsInSquare = _squareValues[sgi].Contains(value);

            return (valueIsInRow || valueIsInColumn || valueIsInSquare);
        }

        private void AddValueInPositionToValueSets(int row, int col, int sgi, int value)
        {
            _rowValues[row].Add(value);
            _columnValues[col].Add(value);
            _squareValues[sgi].Add(value);
        }

        private void RemoveValueFromPositionSets(int row, int col, int sgi, int value)
        {
            _rowValues[row].Remove(value);
            _columnValues[col].Remove(value);
            _squareValues[sgi].Remove(value);
        }

        public override bool SolvePuzzle(int[,] sudokuGrid)
        {
            throw new NotImplementedException();
        }
    }
}