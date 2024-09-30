using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    public abstract class SudokuSolver : ISudokuSolver
    {

        public abstract int[,] GeneratePuzzle();
        public abstract bool SolvePuzzle(int[,] sudokuGrid);

        protected HashSet<int>[] _rowValues;
        protected HashSet<int>[] _columnValues;
        protected HashSet<int>[] _squareValues;

        protected Random _random = new Random();
        protected Rules _rules;

        protected SudokuSolver(Rules rules) 
        { 
            _rules = rules;

            CreateValueSets();
        }

        protected void CreateValueSets()
        {
            _rowValues = new HashSet<int>[_rules.GridSize];
            _columnValues = new HashSet<int>[_rules.GridSize];
            _squareValues = new HashSet<int>[_rules.GridSize];

            for (int i = 0; i < _rules.GridSize; i++)
            {
                _rowValues[i] = new HashSet<int>();
                _columnValues[i] = new HashSet<int>();
                _squareValues[i] = new HashSet<int>();
            }
        }
    }
}
