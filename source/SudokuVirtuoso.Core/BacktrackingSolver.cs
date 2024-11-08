using System;
using System.Collections.Generic;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Implements a backtracking algorithm to solve and generate sudoku puzzles.
    /// </summary>
    public class BacktrackingSolver : SudokuSolver
    {
        private WrittenValues _writtenValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="BacktrackingSolver"/> class.
        /// </summary>
        /// <param name="puzzleType">The puzzle type that defines the rules for the sudoku puzzle.</param>
        public BacktrackingSolver(PuzzleType puzzleType) : base(puzzleType)
        {
            _writtenValues = new WrittenValues();
        }

        /// <summary>
        /// Generates a new sudoku puzzle.
        /// </summary>
        /// <returns>A 2D array representing the generated Sudoku puzzle.</returns>
        public override int[,] GeneratePuzzle()// bude generovat třídu Puzzle, změnit v rozhraní
        {
            var grid = CreateGridWithValidValues();
            // hide cells
            return grid;
        }

        private int[,] CreateGridWithValidValues()
        {
            var grid = new int[Rules.GridSize, Rules.GridSize];

            _ = FillGrid(grid, FillingType.Generate);

            return grid;
        }

        /// <summary>
        /// Solves the given sudoku puzzle.
        /// </summary>
        /// <param name="sudokuGrid">The sudoku grid to solve.</param>
        /// <returns>True if the puzzle is solvable, false otherwise.</returns>
        public override bool SolvePuzzle(int[,] sudokuGrid)// bude řešit třídu Puzzle změnit v abstrakcích
        {
            if (IsGridSolvable(sudokuGrid)) // tuhle podmínku dám asi jinam -> udělat třídu Sheet, která zapozdří grid
                return false;

            return FillGrid(sudokuGrid, FillingType.Solve);
        }

        /// <summary>
        /// Checks if the given sudoku grid can be solved.
        /// </summary>
        /// <param name="grid">The Sudoku grid to check.</param>
        /// <returns>True if the grid can be solved, false otherwise.</returns>
        public bool IsGridSolvable(int[,] grid)
        {
            for (var row = 0; row < Rules.GridSize; row++)
            {
                for (var column = 0; column < Rules.GridSize; column++)
                {
                    var position = new Position(row, column);

                    if (IsValueWrittenAtPositionInGrid(position, grid))
                    {
                        
                        var value = grid[row, column];

                        if (_writtenValues.IsValueAtPosition(value, position))
                            return true; // We've found a duplicate

                        _writtenValues.AddValueAtPositionToWrittenValues(value, position);
                    }
                }
            }

            return false;
        }

        private bool IsValueWrittenAtPositionInGrid(Position position, int[,] grid)
        {
            return grid[position.Row, position.Column] != Constants.EMPTY_CELL_VALUE;
        }

        private bool IsPositionEmpty(Position position, int[,] grid) => !IsValueWrittenAtPositionInGrid(position, grid);
        

        
        private bool FillGrid(int[,] grid, FillingType fillingType)
        {
            // TODO: předělat na iterativní způsob

            var values = Rules.ValidValues.Get();

            for (var row = 0; row < Rules.GridSize; row++)
            {
                for (var column = 0; column < Rules.GridSize; column++)
                {
                    var position = new Position(row, column);

                    if (IsPositionEmpty(position, grid))
                    {
                        if (fillingType == FillingType.Generate) 
                            values = ValueShuffler.GetShuffledValues(values);

                        return HasSolution(grid, fillingType, values, position);
                    }
                }
            }

            return true;
        }

        private bool HasSolution(int[,] grid, FillingType fillingType, HashSet<int> values, Position position)
        {
            foreach (var value in values)
            {
                if (_writtenValues.IsNotValueAtPosition(value, position))
                {
                    WriteValueAtPositionToGrid(value, position, grid);

                    if (FillGrid(grid, fillingType))
                        return true;

                    // If we couldn't complete the grid with this value, backtrack
                    RemoveValueAtPositionFromGrid(value, position, grid);
                }
            }

            return false; // Trigger backtracking
        }

        private void WriteValueAtPositionToGrid(int value, Position position, int[,] grid)
        {
            _writtenValues.AddValueAtPositionToWrittenValues(value, position);
            grid[position.Row, position.Column] = value;
        }

        private void RemoveValueAtPositionFromGrid(int value, Position position, int[,] grid)
        {
            _writtenValues.RemoveValueAtPositionFromWrittenValues(value, position);
            grid[position.Row, position.Column] = Constants.EMPTY_CELL_VALUE;
        }
    }
}