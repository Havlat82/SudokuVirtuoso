using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Defines the interface for sudoku solvers.
    /// </summary>
    public interface ISudokuSolver
    {
        /// <summary>
        /// Solves the given Sudoku puzzle.
        /// </summary>
        /// <param name="sudokuGrid">The sudoku grid to solve.</param>
        /// <returns>True if the grid is solvable, false otherwise.</returns>
        bool SolvePuzzle(int[,] sudokuGrid);
      
        /// <summary>
        /// Generates a new sudoku puzzle.
        /// </summary>
        /// <returns>A 2D array representing the generated sudoku grid.</returns>
        int[,] GeneratePuzzle();        
    }
}
