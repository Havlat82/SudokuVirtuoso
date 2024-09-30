using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    public class Program
    {
        private static void WriteSample()
        {
            //var pa = Position.GetPositionsInSubGrid(0);

            //for (int i = 0; i < pa.Count; i++)
            //    System.Console.WriteLine(pa[i].ToString());
            //System.Console.ReadLine();
        }

        private static void Main(string[] args)
        {
            var sudokuGrid = new SudokuGrid(Rules.Create("Classic9x9Easy"));
            var grid = sudokuGrid.CreateGridWithValidValues();
            SudokuHelper.PrintGrid(grid);
            Console.ReadLine();
            // Arrange
            int[,] puzzle = {
                {5,3,0,0,7,0,0,0,0},
                {6,0,0,1,9,5,0,0,0},
                {0,9,8,0,0,0,0,6,0},
                {8,0,0,0,6,0,0,0,3},
                {4,0,0,8,0,3,0,0,1},
                {7,0,0,0,2,0,0,0,6},
                {0,6,0,0,0,0,2,8,0},
                {0,0,0,4,1,9,0,0,5},
                {0,0,0,0,8,0,0,7,9}
            };
            SudokuHelper.PrintGrid(puzzle);
            Console.ReadLine();
            var solved = sudokuGrid.SolveGrid(puzzle);
            SudokuHelper.PrintGrid(solved);
            Console.ReadLine();
        }

       

        //private Position GetNextPosition(Position current, Rules rules)
        //{
        //    int nextColumn = (current.Column + 1) % rules.GridSize;
        //    int nextRow = current.Row + (nextColumn == 0 ? 1 : 0);
        //    return new Position(nextRow, nextColumn);
        //}

        //private bool SolveIterative(int[,] sheet, Rules rules)
        //{
        //    var stack = new Stack<Position>();
        //    var currentPosition = new Position(0, 0);

        //    while (true)
        //    {
        //        if (currentPosition.Row == rules.GridSize)
        //        {
        //            //OnSolutionFound(EventArgs.Empty);
        //            return true; // Puzzle solved
        //        }

        //        if (sheet[currentPosition.Row, currentPosition.Column] != Rules.EMPTY_CELL_VALUE)
        //        {
        //            currentPosition = GetNextPosition(currentPosition);
        //            continue;
        //        }

        //        bool foundValidNumber = false;
        //        int startNum = sheet[currentPosition.Row, currentPosition.Column] + 1;

        //        for (int num = startNum; num <= Rules.MAX_VALUE; num++)
        //        {
        //            if (SudokuGrid.IsPositionValid(sheet, currentPosition, num))
        //            {
        //                sheet[currentPosition.Row, currentPosition.Column] = num;
        //                //OnCellFilled(new SudokuEventArgs(currentPosition, num));
        //                stack.Push(currentPosition);
        //                currentPosition = GetNextPosition(currentPosition, rules);
        //                foundValidNumber = true;
        //                break;
        //            }
        //        }

        //        if (!foundValidNumber)
        //        {
        //            if (stack.Count == 0)
        //            {
        //                //OnNoSolutionFound(EventArgs.Empty);
        //                return false;
        //            }
        //            sheet[currentPosition.Row, currentPosition.Column] = Rules.EMPTY_CELL_VALUE;
        //            currentPosition = stack.Pop();
        //            //OnBacktracking(new SudokuEventArgs(currentPosition, SudokuRules.EMPTY_CELL));
        //        }
        //    }
        //}
    }
}