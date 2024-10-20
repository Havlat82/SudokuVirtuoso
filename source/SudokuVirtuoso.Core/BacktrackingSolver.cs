using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    public class BacktrackingSolver : SudokuSolver
    {
        private ValueSetManager _setManager;

        public BacktrackingSolver(Rules rules) : base(rules)
        {
            _setManager = new ValueSetManager(rules);
        }

        // bude generovat třídu sudokusheet
        public override int[,] GeneratePuzzle()
        {
            var grid = CreateGridWithValidValues();
            // hide cells
            return grid;
        }

        private int[,] CreateGridWithValidValues()
        {
            var grid = new int[_rules.GridSize, _rules.GridSize];

            _ = FillGrid(grid, true);

            return grid;
        }

        // bude řešit třídu sudokusheet změnit v abstrakcích
        public override bool SolvePuzzle(int[,] sudokuGrid)
        {
            if (!CanBeSolved(sudokuGrid))
                return false;

            return FillGrid(sudokuGrid);
        }

        public bool CanBeSolved(int[,] grid)
        {
            for (var row = 0; row < _rules.GridSize; row++)
                for (var col = 0; col < _rules.GridSize; col++)
                    if (grid[row, col] != Rules.EMPTY_CELL_VALUE)
                    {
                        var sgi = ((row / _rules.SquareSize) * _rules.SquareSize) + (col / _rules.SquareSize);
                        var value = grid[row, col];

                        if (!CanWriteValueToPosition(value, row, col, sgi))
                            return false; // We've found a duplicate
                        else
                            _setManager.AddValueInPositionToValueSets(row, col, sgi, value);
                    }

            return true;
        }

        // předělat na iterativní způsob
        private bool FillGrid(int[,] grid, bool newPuzzle = false)
        {
            var numbers = _rules.ValidValues.Get();

            for (var row = 0; row < _rules.GridSize; row++)
                for (var col = 0; col < _rules.GridSize; col++)
                {
                    if (grid[row, col] == Rules.EMPTY_CELL_VALUE)
                    {
                        var sgi = ((row / _rules.SquareSize) * _rules.SquareSize) + (col / _rules.SquareSize);

                        if (newPuzzle) // pravděpodobně změnim název
                            numbers = ValueShuffler.Shuffle(numbers);

                        foreach (var value in numbers)
                        {
                            if (CanWriteValueToPosition(value, row, col, sgi))
                            {
                                _setManager.AddValueInPositionToValueSets(row, col, sgi, value);
                                grid[row, col] = value;

                                if (FillGrid(grid, newPuzzle))
                                    return true;

                                // If we couldn't complete the grid with this value, backtrack
                                _setManager.RemoveValueInPositionFromSets(row, col, sgi, value);
                                grid[row, col] = 0;
                            }
                        }

                        return false; // Trigger backtracking
                    }
                }

            return true;
        }

        private bool CanWriteValueToPosition(int value, int r, int c, int sgi)
        {
            var IsNotInRow = !_setManager.IsValueInRow(value, r);
            var IsNotInColumn = !_setManager.IsValueInColumn(value, c);
            var IsNotInSquare = !_setManager.IsValueInSquare(value, sgi);

            return (IsNotInRow && IsNotInColumn && IsNotInSquare);
        }
    }
}