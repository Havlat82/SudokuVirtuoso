using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    internal class SudokuGridObsolote
    {
        //public readonly List<int> DefaultValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //private HashSet<int> _setOfAllowedValues { get; set; } = new HashSet<int>();
        //private HashSet<Position> _hiddenCells;

        //#region position validation (according the rules)

        //public static bool IsPositionValid(int[,] sheet, Position position, int num)
        //{
        //    return !ExistsInRow(sheet, position, num)
        //        && !ExistsInColumn(sheet, position, num)
        //        && !ExistsInSubGrid(sheet, position, num);
        //}

        //private static bool ExistsInRow(int[,] sheet, Position position, int num)
        //    => SameNumbersInRow(sheet, position, num) > 0;

        //private static int SameNumbersInRow(int[,] sheet, Position position, int num)
        //{
        //    var count = 0;

        //    for (int c = 0; c < GRID_SIZE; c++)
        //        if (sheet[position.Row, c] == num)
        //            count++;

        //    return count;
        //}

        //private static bool ExistsInColumn(int[,] sheet, Position position, int num)
        //    => SameNumbersInColumn(sheet, position, num) > 0;

        //private static int SameNumbersInColumn(int[,] sheet, Position position, int num)
        //{
        //    var count = 0;

        //    for (int r = 0; r < GRID_SIZE; r++)
        //        if (sheet[r, position.Column] == num)
        //            count++;

        //    return count;
        //}

        //private static bool ExistsInSubGrid(int[,] sheet, Position position, int num)
        //    => SameNumbersInSubGrid(sheet, position, num) > 0;

        //private static int SameNumbersInSubGrid(int[,] sheet, Position position, int num)
        //{
        //    var count = 0;

        //    var subSquareStartRow = (position.Row / SUBGRID_SIZE) * SUBGRID_SIZE;
        //    var subSquareStartColumn = position.Column - (position.Column % SUBGRID_SIZE);

        //    for (int r = subSquareStartRow; r < (subSquareStartRow + SUBGRID_SIZE); r++)
        //    {
        //        for (int c = subSquareStartColumn; c < (subSquareStartColumn + SUBGRID_SIZE); c++)
        //        {
        //            if (sheet[r, c] == num)
        //                count++;
        //        }
        //    }

        //    return count;
        //}

        //#endregion

        //public Company DeepCopy()
        //{
        //    var newInstance = (Company)this.MemberwiseClone();
        //    newCompany.Details = new CompanyDetails(this.Details.Name);
        //    return newCompany;
        //}

        //public SudokuGrid(int[,] sheet)
        //{
        //    var result = TrySetSheet(sheet);
        //}

        //public void Hide(Random rnd)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        var hidedInRow = rnd.Next(4, 7);
        //        var toHide = new List<int>();

        //        for (int h = 0; h <= hidedInRow; h++)
        //        {
        //            int rand = rnd.Next(0, 9);
        //            while (toHide.Contains(rand))
        //                rand = rnd.Next(0, 9);
        //            toHide.Add(rand);
        //        }
        //        foreach (var item in toHide)
        //        {
        //            _sheet[i, item] = 0;
        //        }
        //    }
        //}

        //private void FillSets()
        //{
        //    _rowValues = new HashSet<int>[GRID_SIZE];
        //    _columnValues = new HashSet<int>[GRID_SIZE];
        //    _squareValues = new HashSet<int>[GRID_SIZE];

        //    for (int i = 0; i < GRID_SIZE; i++)
        //    {
        //        _rowValues[i] = new HashSet<int>(DefaultValues);
        //        _columnValues[i] = new HashSet<int>(DefaultValues);
        //        _squareValues[i] = new HashSet<int>(DefaultValues);
        //    }
        //}

        //private void RemoveValueFromSets(Position position, int numValue)
        //{
        //    _rowValues[position.Row].Remove(numValue);
        //    _columnValues[position.Column].Remove(numValue);
        //    _squareValues[position.SubGridIndex].Remove(numValue);
        //}

        //private HashSet<int> GetAllowedValues(Position position)
        //{
        //    var newSet = _rowValues[position.Row].Intersect(_columnValues[position.Column])
        //                                         .Intersect(_squareValues[position.SubGridIndex]);

        //    return newSet.ToHashSet();
        //}

        //public int[,] GenerateSheetError()
        //{
        //    var sheet = new int[GRID_SIZE, GRID_SIZE];
        //    //var random = new Random();

        //    FillSets();

        //    for (var r = 0; r < GRID_SIZE; r++)
        //        for (var c = 0; c < GRID_SIZE; c++)
        //        {
        //            var position = new Position(r, c);
        //            var validNumberFound = false;
        //            var attempt = 0;

        //            _setOfAllowedValues = GetAllowedValues(position);
        //            //_setOfAllowedValues.ToList().Shuffle();
        //            var list = _setOfAllowedValues.ToList();

        //            while (!validNumberFound)
        //            {
        //                if (attempt == list.Count)
        //                    break;

        //                var numValue = list[attempt];

        //                if (IsPositionValid(sheet, position, numValue))
        //                {
        //                    sheet[r, c] = numValue;
        //                    validNumberFound = true;
        //                    RemoveValueFromSets(position, sheet[r, c]);

        //                }

        //                attempt++;
        //            }

        //        }

        //    return sheet;
        //}

        //public int[,] GetSheet()
        //{
        //    return _sheet;
        //}

        //public HashSet<Position> GetHiddenCells()
        //{
        //    return _hiddenCells;
        //}

        //public bool TrySetSheet(int[,] newSheet)
        //{
        //    if (!IsSheetValid(newSheet))
        //        return false;

        //    _sheet = newSheet;
        //    return true;
        //}

        //private bool TryFindEmptyCell(int[,] sheet, out Position position)
        //{
        //    for (int row = 0; row < GRID_SIZE; row++)
        //    {
        //        for (int col = 0; col < GRID_SIZE; col++)
        //        {
        //            if (sheet[row, col] == EMPTY_CELL)
        //            {
        //                position = new Position(row, col);
        //                return true;
        //            }
        //        }
        //    }
        //    position = default;
        //    return false;
        //}

        //public bool IsValidSudoku(char[][] board)
        //{
        //    var rowValues = new HashSet<char>[9];
        //    var colValues = new HashSet<char>[9];
        //    var boxValues = new HashSet<char>[9];

        //    for (int i = 0; i < 9; i++)
        //    {
        //        rowValues[i] = new HashSet<char>();
        //        colValues[i] = new HashSet<char>();
        //        boxValues[i] = new HashSet<char>();
        //    }

        //    for (int row = 0; row < board.Length; row++)
        //    {
        //        for (int col = 0; col < board[row].Length; col++)
        //        {
        //            char cell = board[row][col];

        //            if (cell == '.') continue;

        //            int boxIndex = ((row / 3) * 3) + (col / 3);

        //            if (rowValues[row].Contains(cell)
        //                || colValues[col].Contains(cell)
        //                || boxValues[boxIndex].Contains(cell)
        //               )
        //            {
        //                return false;
        //            }

        //            rowValues[row].Add(cell);
        //            colValues[col].Add(cell);
        //            boxValues[boxIndex].Add(cell);
        //        }
        //    }

        //    return true;
        //}

        //for (int row = 0; row < GRID_SIZE; row++)
        //{
        //    for (int col = 0; col < GRID_SIZE; col++)
        //    {
        //        var cellValue = sheet[row, col];
        //        if (cellValue != EMPTY_CELL
        //                      && (cellValue < MIN_VALUE || cellValue > MAX_VALUE))
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}
