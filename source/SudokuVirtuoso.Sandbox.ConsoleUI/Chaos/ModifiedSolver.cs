using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuVirtuoso.Core
{
    //public class ModifiedSolver : SudokuSolver
    //{
    //    public ModifiedSolver(Rules rules) : base(rules)
    //    {
    //    }

    //    public override int[,] GeneratePuzzle()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool SolvePuzzle(int[,] sudokuGrid)
    //    {
    //        if (AreErrorsInGrid(sudokuGrid))
    //            return false;
    //        return SolveSudoku(sudokuGrid);
    //    }

    //    private bool AreErrorsInGrid(int[,] grid)
    //    {
    //        for (var row = 0; row < _rules.GridSize; row++)
    //            for (var col = 0; col < _rules.GridSize; col++)
    //                for (var value = _rules.MinValue; value <= _rules.MaxValue; value++)
    //                    if (IsErrorInPosition(grid, row, col, value))
    //                        return true;
    //        return false;
    //    }

    //    private bool SolveSudoku(int[,] grid)
    //    {
    //        for (var row = 0; row < _rules.GridSize; row++)
    //            for (var col = 0; col < _rules.GridSize; col++)
    //            {
    //                if (grid[row, col] == Rules.EMPTY_CELL_VALUE)
    //                {
    //                    for (var value = _rules.MinValue; value <= _rules.MaxValue; value++)
    //                    {
    //                        if (ValueCouldBeWritten(grid, row, col, value))
    //                        {
    //                            grid[row, col] = value;
    //                            if (SolveSudoku(grid))
    //                                return true;

    //                            grid[row, col] = Rules.EMPTY_CELL_VALUE;
    //                        }
    //                    }
    //                    return false;
    //                }
    //            }

    //        return true;
    //    }

    //    private int GetValueCountInRow(int[,] grid, int value, int row)
    //    {
    //        var count = 0;

    //        for (var col = 0; col < _rules.GridSize; col++)
    //        {
    //            if (grid[row, col] == value)
    //                count++;
    //        }

    //        return count;
    //    }

    //    private int GetValueCountInColumn(int[,] grid, int value, int column)
    //    {
    //        var count = 0;

    //        for (var row = 0; row < _rules.GridSize; row++)
    //        {
    //            if (grid[row, column] == value)
    //                count++;
    //        }

    //        return count;
    //    }

    //    private int GetValueCountInSquare(int[,] grid, int value, int row, int column)
    //    {
    //        var count = 0;

    //        for (var i = 0; i < _rules.SquareSize; i++)
    //        {
    //            var squareRow = GetSquareRow(row, i);
    //            var squareCol = GetSquareColumn(column, i);

    //            if (grid[squareRow, squareCol] == value)
    //                count++;
    //        }

    //        return count;
    //    }

    //    private int GetSquareRow(int row, int index)
    //    {
    //        return row - (row % _rules.SquareSize) + (index / _rules.SquareSize);
    //    }

    //    private int GetSquareColumn(int column, int index)
    //    {
    //        return column - (column % _rules.SquareSize) + (index % _rules.SquareSize);
    //    }

    //    private bool IsErrorInRow(int[,] grid, int row, int value)
    //    {
    //        return GetValueCountInRow(grid, value, row) > Rules.ALLOWED_COUNT;
    //    }

    //    private bool IsErrorInColumn(int[,] grid, int row, int value)
    //    {
    //        return GetValueCountInColumn(grid, value, row) > Rules.ALLOWED_COUNT;
    //    }

    //    private bool IsErrorInSquare(int[,] grid, int row, int col, int value)
    //    {
    //        return GetValueCountInSquare(grid, value, row, col) > Rules.ALLOWED_COUNT;
    //    }

    //    private bool ValueCouldBeWritten(int[,] grid, int row, int col, int value)
    //    {
    //        var errorInRow = IsErrorInRow(grid, row, value);
    //        var errorInColumn = IsErrorInColumn(grid, col, value);
    //        var errorInSquare = IsErrorInSquare(grid, row, col, value);

    //        if (errorInRow || errorInColumn || errorInSquare)
    //            return false;

    //        return true;
    //    }

    //    private bool IsErrorInPosition(int[,] grid, int row, int col, int value)
    //    {
    //        return !ValueCouldBeWritten(grid, row, col, value);
    //    }
    //}
}