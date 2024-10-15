using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    public interface ISudokuSolver
    {
        bool SolvePuzzle(int[,] sudokuGrid);
      
        int[,] GeneratePuzzle();        
    }
}
