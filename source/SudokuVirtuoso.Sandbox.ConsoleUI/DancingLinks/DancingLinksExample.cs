using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.ConsoleUI.DancingLinks
{
    public class DancingLinksExample
    {
        public void Execute()
        {
            SudokuDLX sudoku = new SudokuDLX();

            Console.WriteLine("Generating a new Sudoku puzzle:");
            int[,] generatedPuzzle = sudoku.Generate();
            SudokuHelper.PrintGrid(generatedPuzzle);

            Console.WriteLine("Solving the generated puzzle:");
            int[,] solvedPuzzle = sudoku.Solve(generatedPuzzle);
            SudokuHelper.PrintGrid(solvedPuzzle);
        }
    }
}
