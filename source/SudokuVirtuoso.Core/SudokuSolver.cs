using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Provides an abstract base class for Sudoku solvers.
    /// </summary>
    public abstract class SudokuSolver : ISudokuSolver
    {
        /// <summary>
        /// Generates a new Sudoku puzzle.
        /// </summary>
        /// <returns>A 2D array representing the generated Sudoku puzzle.</returns>
        public abstract int[,] GeneratePuzzle();

        /// <summary>
        /// Solves the given Sudoku puzzle.
        /// </summary>
        /// <param name="sudokuGrid">The Sudoku puzzle to solve.</param>
        /// <returns>True if the puzzle is solvable, false otherwise.</returns>
        public abstract bool SolvePuzzle(int[,] sudokuGrid);
        
        /// <summary>
        /// The rules defining the Sudoku puzzle structure.
        /// </summary>
        protected Rules _rules;

        /// <summary>
        /// Initializes a new instance of the SudokuSolver class.
        /// </summary>
        /// <param name="rules">The rules defining the Sudoku puzzle structure.</param>
        protected SudokuSolver(Rules rules)
        {
            _rules = rules;
        }
    }
}