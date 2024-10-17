using SudokuVirtuoso.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    //public class SudokuGrid
    //{
    //    private HashSet<int>[] _rowValues;
    //    private HashSet<int>[] _columnValues;
    //    private HashSet<int>[] _squareValues;

    //    private Random _random = new Random();
    //    private Rules _rules;

    //    public SudokuGrid(Rules rules)
    //    {
    //        _rules = rules;
    //        CreateValueSets();            
    //    }

    //    public int[,] CreateGridWithValidValues()
    //    {
    //        var grid = new int[_rules.GridSize, _rules.GridSize];

    //        FillGrid(grid);

    //        return grid;
    //    }

    //    public bool SolveGrid(int[,] grid)
    //    {
    //        if (AreErrorsInGrid(grid)) 
    //            return false; 

    //        return SolveSudoku(grid);
    //    }

    //    private bool AreErrorsInGrid(int[,] grid)
    //    {
    //        for (var row = 0; row < _rules.GridSize; row++)
    //            for (var col = 0; col < _rules.GridSize; col++)
    //                if (grid[row, col] != Rules.EMPTY_CELL_VALUE)
    //                {
    //                    var sgi = ((row / 3) * 3) + (col / 3);
    //                    var value = grid[row, col];

    //                    if (IsValueInPosition(value, row, col, sgi))
    //                        return true;
    //                    else
    //                        AddValueInPositionToValueSets(row, col, sgi, value);

    //                }

    //        return false;
    //    }

    //    private void CreateValueSets()
    //    {
    //        _rowValues = new HashSet<int>[_rules.GridSize];
    //        _columnValues = new HashSet<int>[_rules.GridSize];
    //        _squareValues = new HashSet<int>[_rules.GridSize];

    //        for (int i = 0; i < _rules.GridSize; i++)
    //        {
    //            _rowValues[i] = new HashSet<int>();
    //            _columnValues[i] = new HashSet<int>();
    //            _squareValues[i] = new HashSet<int>();
    //        }
    //    }


    //    private bool IsValueInPosition(int value, int r, int c, int sgi)
    //    {
    //        var valueIsInRow = _rowValues[r].Contains(value);
    //        var valueIsInColumn = _columnValues[c].Contains(value);
    //        var valueIsInSquare = _squareValues[sgi].Contains(value);

    //        return (valueIsInRow || valueIsInColumn || valueIsInSquare);
    //    }

    //    private bool FillGrid(int[,] sheet, int row = 0, int column = 0)
    //    {
    //        if (column == _rules.GridSize)
    //        {
    //            row++;
    //            column = 0;
    //        }
    //        if (row == _rules.GridSize)
    //            return true; // We've filled the entire grid successfully

    //        var subGridIndex = ((row / 3) * 3) + (column / 3);
    //        var numbers = Enumerable.Range(1, 9).OrderBy(x => _random.Next()).ToList();

    //        foreach (var value in numbers)
    //        {
    //            if (!IsValueInPosition(value, row, column, subGridIndex))
    //            {
    //                AddValueInPositionToValueSets(row, column, subGridIndex, value);
    //                sheet[row, column] = value;

    //                if (FillGrid(sheet, row, column + 1))
    //                    return true;

    //                // If we couldn't complete the grid with this value, backtrack
    //                RemoveValueFromPositionSets(row, column, subGridIndex, value);
    //                sheet[row, column] = 0;
    //            }
    //        }

    //        return false; // Trigger backtracking
    //    }

    //    private void RemoveValueFromPositionSets(int row, int col, int sgi, int value)
    //    {
    //        _rowValues[row].Remove(value);
    //        _columnValues[col].Remove(value);
    //        _squareValues[sgi].Remove(value);
    //    }

    //    private void AddValueInPositionToValueSets(int row, int col, int sgi, int value)
    //    {
    //        _rowValues[row].Add(value);
    //        _columnValues[col].Add(value);
    //        _squareValues[sgi].Add(value);
    //    }

    //    public bool SolveSudoku(int[,] grid)
    //    {
    //        var min = _rules.ValidValues.Min();
    //        var max = _rules.ValidValues.Max();

    //        for (var row = 0; row < _rules.GridSize; row++)
    //            for (var col = 0; col < _rules.GridSize; col++)
    //            {
    //                if (grid[row, col] == Rules.EMPTY_CELL_VALUE)
    //                {
    //                    for (var value = min; value <= max; value++)
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

    //    private bool ValueCouldBeWritten(int[,] grid, int row, int col, int value)
    //    {
    //        for (var i = 0; i < _rules.GridSize; i++)
    //        {
    //            var squareRow = row - (row % 3) + (i / 3);
    //            var squareCol = col - (col % 3) + (i % 3);

    //            var isValueInRow = grid[row, i] == value;
    //            var isValueInColumn = grid[i, col] == value;
    //            var isValueInSquare = grid[squareRow, squareCol] == value;

    //            if (isValueInRow || isValueInColumn || isValueInSquare)
    //                return false;
    //        }

    //        return true;
    //    }
    //}
}