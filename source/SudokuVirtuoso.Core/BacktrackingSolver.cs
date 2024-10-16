using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    public class BacktrackingSolver : SudokuSolver
    {
        // možná je dám do samostatný třídy
        private HashSet<int>[] _rowValues;
        private HashSet<int>[] _columnValues;
        private HashSet<int>[] _squareValues;

        public BacktrackingSolver(Rules rules) : base(rules)
        {
            CreateValueSets();
        }

        public override int[,] GeneratePuzzle()
        {
            
            var grid = CreateGridWithValidValues();
            // hide cells
            return grid;
        }

        public override bool SolvePuzzle(int[,] sudokuGrid)
        {
            if (!CanBeSolved(sudokuGrid))
                return false;

            return FillGrid(sudokuGrid);
        }

        // možná je dám do samostatný třídy
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

        private int[,] CreateGridWithValidValues()
        {
            var grid = new int[_rules.GridSize, _rules.GridSize];

            _ = FillGrid(grid);

            return grid;
        }
        private bool FillGrid(int[,] grid)
        {
            for (var row = 0; row < _rules.GridSize; row++)
                for (var col = 0; col < _rules.GridSize; col++)
                {
                    if (grid[row, col] == Rules.EMPTY_CELL_VALUE)
                    {
                        var sgi = ((row / _rules.SquareSize) * _rules.SquareSize) + (col / _rules.SquareSize);
                        var numbers = _rules.ValidValues;//  todo randomizace .OrderBy(x => _random.Next()).ToList(); bude v SudokuHelper

                        foreach (var value in numbers)
                        {
                            if (!IsValueInPosition(value, row, col, sgi))
                            {
                                AddValueInPositionToValueSets(row, col, sgi, value);
                                grid[row, col] = value;

                                if (FillGrid(grid))
                                    return true;

                                // If we couldn't complete the grid with this value, backtrack
                                RemoveValueFromPositionSets(row, col, sgi, value);
                                grid[row, col] = 0;
                            }
                        }

                        return false; // Trigger backtracking
                    }
                }

            return true;
        }

        public bool CanBeSolved(int[,] grid)
        {
            for (var row = 0; row < _rules.GridSize; row++)
                for (var col = 0; col < _rules.GridSize; col++)
                    if (grid[row, col] != Rules.EMPTY_CELL_VALUE)
                    {
                        var sgi = ((row / _rules.SquareSize) * _rules.SquareSize) + (col / _rules.SquareSize);
                        var value = grid[row, col];

                        if (IsValueInPosition(value, row, col, sgi))
                            return false; // We've found a duplicate
                        else
                            AddValueInPositionToValueSets(row, col, sgi, value);
                    }

            return true;
        }

        private bool IsValueInPosition(int value, int r, int c, int sgi)
        {
            var valueIsInRow = _rowValues[r].Contains(value);
            var valueIsInColumn = _columnValues[c].Contains(value);
            var valueIsInSquare = _squareValues[sgi].Contains(value);

            return (valueIsInRow || valueIsInColumn || valueIsInSquare);
        }

        // možná je dám do samostatný třídy
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
    }
}
