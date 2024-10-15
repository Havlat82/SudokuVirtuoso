using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.ConsoleUI
{
    public static class SudokuHelper
    {
        // Print the Sudoku grid
        public static void PrintGrid(int[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                    System.Console.WriteLine("------+-------+------");
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                        Console.Write("| ");
                    Console.Write(grid[i, j] == 0 ? ". " : grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
