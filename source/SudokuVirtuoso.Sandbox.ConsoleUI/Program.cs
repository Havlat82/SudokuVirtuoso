using SudokuVirtuoso.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.ConsoleUI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var rules = Rules.Create("Classic9x9Easy", new ValidValues(1, 9));

            var solver = new BacktrackingSolver(rules);

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

            // Arrange
            //int[,] invalidPuzzle = {
            //    {5,3,0,0,7,0,0,0,0},
            //    {5,0,0,1,9,5,0,0,0}, // Note the duplicate 5 in the second row
            //    {0,9,8,0,0,0,0,6,0},
            //    {8,0,0,0,6,0,0,0,3},
            //    {4,0,0,8,0,3,0,0,1},
            //    {7,0,0,0,2,0,0,0,6},
            //    {0,6,0,0,0,0,2,8,0},
            //    {0,0,0,4,1,9,0,0,5},
            //    {0,0,0,0,8,0,0,7,9}
            //};

            // Act
            bool solved = solver.SolvePuzzle(puzzle);
            SudokuHelper.PrintGrid(puzzle);

            Console.ReadLine();
        }

        private bool SolveIterative(int[,] sheet, Rules rules)
        {
            var stack = new Stack<Position>();
            var currentPosition = new Position(0, 0);

            while (true)
            {
                if (currentPosition.Row == rules.GridSize)
                {
                    return true; // Puzzle solved
                }

                if (sheet[currentPosition.Row, currentPosition.Column] != Rules.EMPTY_CELL_VALUE)
                {
                    //currentPosition = GetNextPosition(currentPosition);
                    continue;
                }

                bool foundValidNumber = false;
                int startNum = sheet[currentPosition.Row, currentPosition.Column] + 1;

                //for (int num = startNum; num <= Rules.MAX_VALUE; num++)
                //{
                //    if (SudokuGrid.IsPositionValid(sheet, currentPosition, num))
                //    {
                //        sheet[currentPosition.Row, currentPosition.Column] = num;

                //        stack.Push(currentPosition);
                //        currentPosition = GetNextPosition(currentPosition, rules);
                //        foundValidNumber = true;
                //        break;
                //    }
                //}

                if (!foundValidNumber)
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    sheet[currentPosition.Row, currentPosition.Column] = Rules.EMPTY_CELL_VALUE;
                    currentPosition = stack.Pop();
                }
            }
        }
    }
}