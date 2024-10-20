using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Defines the interface for Sudoku solvers.
    /// </summary>
    public interface ISudokuSolver
    {
        /// <summary>
        /// Solves the given Sudoku puzzle.
        /// </summary>
        /// <param name="sudokuGrid">The Sudoku puzzle to solve.</param>
        /// <returns>True if the puzzle is solvable, false otherwise.</returns>
        bool SolvePuzzle(int[,] sudokuGrid);
      
        /// <summary>
        /// Generates a new Sudoku puzzle.
        /// </summary>
        /// <returns>A 2D array representing the generated Sudoku puzzle.</returns>
        int[,] GeneratePuzzle();        
    }
}
