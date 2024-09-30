using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    public class SudokuGrid
    {
        //public const int GRID_SIZE = 9;
        //public const int SUBGRID_SIZE = 3;
        //public const int MIN_VALUE = 1;
        //public const int MAX_VALUE = 9;
        //public const int EMPTY_CELL = 0;

        //private int[,] _sheet;

        private HashSet<int>[] _rowValues;
        private HashSet<int>[] _columnValues;
        private HashSet<int>[] _squareValues;

        private Random _random = new Random();
        private Rules _rules;

        public SudokuGrid(Rules rules)
        {
            _rules = rules;
            //_sheet = new int[_rules.GridSize, _rules.GridSize];
            CreateValueSets();
            //_hiddenCells = new HashSet<Position>();
        }

        public int[,] CreateGridWithValidValues()
        {
            var grid = new int[_rules.GridSize, _rules.GridSize];

            FillGrid(grid);

            return grid;
        }

        public int[,] SolveGrid(int[,] grid)
        {
            FillGrid(grid);

            return grid;
        }

        private void CreateValueSets()
        {
            _rowValues = new HashSet<int>[_rules.GridSize];
            _columnValues = new HashSet<int>[_rules.GridSize];
            _squareValues = new HashSet<int>[_rules.GridSize];

            for (int i = 0; i < _rules.GridSize; i++)
            {
                _rowValues[i] = new HashSet<int>();
                _columnValues[i] = new HashSet<int>();
                _squareValues[i] = new HashSet<int>();
            }
        }


        private bool IsValueInPosition(int value, int r, int c, int sgi)
        {
            var valueIsInRow = _rowValues[r].Contains(value);
            var valueIsInColumn = _columnValues[c].Contains(value);
            var valueIsInSquare = _squareValues[sgi].Contains(value);

            return (valueIsInRow || valueIsInColumn || valueIsInSquare);
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

        private void RemoveValueFromPositionSets(int row, int col, int sgi, int value)
        {
            _rowValues[row].Remove(value);
            _columnValues[col].Remove(value);
            _squareValues[sgi].Remove(value);
        }

        private void AddValueInPositionToValueSets(int row, int col, int sgi, int value)
        {
            _rowValues[row].Add(value);
            _columnValues[col].Add(value);
            _squareValues[sgi].Add(value);
        }
    }
}