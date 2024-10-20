using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    public abstract class SudokuSolver : ISudokuSolver
    {
        public abstract int[,] GeneratePuzzle();

        public abstract bool SolvePuzzle(int[,] sudokuGrid);

        protected Rules _rules;

        protected SudokuSolver(Rules rules)
        {
            _rules = rules;
        }
    }
}