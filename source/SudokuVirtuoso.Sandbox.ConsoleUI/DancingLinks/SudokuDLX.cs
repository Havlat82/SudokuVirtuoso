using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.ConsoleUI.DancingLinks
{
    public class SudokuDLX
    {
        /*
         * příklad imlementace algoritmu Donalda Knutha - Dancing Links
         * bohužel je tam někde chyba. pravděpodobně v rekurzi.
         * potřebuje polidštit a zjednodušit
         */

        private const int Size = 9;  // Size of the Sudoku grid
        private const int BoxSize = 3;  // Size of each 3x3 box in the grid
        private const int MinClues = 17;  // Minimum number of clues for a unique Sudoku
        private static Random random = new Random();

        // Node in the Dancing Links structure
        private class DancingNode
        {
            public DancingNode L, R, U, D;  // Left, Right, Up, Down pointers
            public ColumnNode C;  // Column header
            public int RowID;  // Identifier for the row (used in Sudoku solving)

            // Hook this node horizontally into the list
            public DancingNode Hook()
            {
                L.R = this;
                R.L = this;
                return this;
            }

            // Remove this node horizontally from the list
            public DancingNode Unhook()
            {
                L.R = R;
                R.L = L;
                return this;
            }

            public DancingNode() : this(null) { }

            public DancingNode(ColumnNode c)
            {
                L = R = U = D = this;
                C = c;
            }
        }

        // Special node representing a column in the Dancing Links structure
        private class ColumnNode : DancingNode
        {
            public int Size;  // Number of nodes in this column
            public string Name;  // Name of the constraint this column represents

            public ColumnNode(string n) : base()
            {
                Size = 0;
                Name = n;
                C = this;
            }

            // Cover (remove) this column and all rows with a 1 in this column
            public void Cover()
            {
                Unhook();
                for (DancingNode i = D; i != this; i = i.D)
                {
                    for (DancingNode j = i.R; j != i; j = j.R)
                    {
                        j.Unhook();
                        j.C.Size--;
                    }
                }
            }

            // Uncover (restore) this column and all affected rows
            public void Uncover()
            {
                for (DancingNode i = U; i != this; i = i.U)
                {
                    for (DancingNode j = i.L; j != i; j = j.L)
                    {
                        j.C.Size++;
                        j.Hook();
                    }
                }
                Hook();
            }
        }

        private ColumnNode header;  // Header node for the Dancing Links structure
        private List<DancingNode> answer;  // List to store the current solution

        // Recursive search function implementing Algorithm X
        private void Search(int k)
        {
            if (header.R == header)
            {
                SolutionFound(answer);
                return;
            }

            // Choose the column with the smallest size (optimization)
            ColumnNode c = (ColumnNode)header.R;
            for (ColumnNode j = (ColumnNode)header.R; j != header; j = (ColumnNode)j.R)
            {
                if (j.Size < c.Size) c = j;
            }

            c.Cover();

            for (DancingNode r = c.D; r != c; r = r.D)
            {
                answer.Add(r);

                for (DancingNode j = r.R; j != r; j = j.R)
                {
                    j.C.Cover();
                }

                Search(k + 1);

                r = answer[answer.Count - 1];
                answer.RemoveAt(answer.Count - 1);

                c = r.C;
                for (DancingNode j = r.L; j != r; j = j.L)
                {
                    j.C.Uncover();
                }
            }
            c.Uncover();
        }

        // Process a found solution
        private void SolutionFound(List<DancingNode> answer)
        {
            foreach (var n in answer)
            {
                int[] decoded = DecodeRowID(n.RowID);
                int digit = decoded[0];
                int row = decoded[1];
                int col = decoded[2];
                grid[row, col] = digit;
            }
            solutionFound = true;
        }

        private int[,] grid = new int[Size, Size];  // The Sudoku grid
        private bool solutionFound = false;  // Flag to indicate if a solution was found

        // Solve a given Sudoku puzzle
        public int[,] Solve(int[,] puzzle)
        {
            grid = (int[,])puzzle.Clone();
            solutionFound = false;
            answer = new List<DancingNode>();
            header = CreateDLXBoard(grid);
            Search(0);
            return solutionFound ? grid : null;
        }

        // Generate a new Sudoku puzzle
        public int[,] Generate()
        {
            grid = new int[Size, Size];
            solutionFound = false;
            answer = new List<DancingNode>();
            header = CreateDLXBoard(grid);
            Search(0);

            if (!solutionFound)
                throw new InvalidOperationException("Failed to generate a valid Sudoku grid.");

            RemoveCells();
            return grid;
        }

        // Remove cells from the grid to create a puzzle
        private void RemoveCells()
        {
            List<Tuple<int, int>> cells = new List<Tuple<int, int>>();
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    cells.Add(Tuple.Create(i, j));

            cells = cells.OrderBy(x => random.Next()).ToList();

            foreach (var cell in cells)
            {
                int temp = grid[cell.Item1, cell.Item2];
                grid[cell.Item1, cell.Item2] = 0;

                int[,] copy = (int[,])grid.Clone();
                if (CountSolutions(copy) != 1)
                {
                    grid[cell.Item1, cell.Item2] = temp;
                }

                if (cells.Count(c => grid[c.Item1, c.Item2] != 0) == MinClues)
                    break;
            }
        }

        // Count the number of solutions for a given puzzle
        private int CountSolutions(int[,] puzzle)
        {
            int count = 0;
            grid = (int[,])puzzle.Clone();
            solutionFound = false;
            answer = new List<DancingNode>();
            header = CreateDLXBoard(grid);
            Search(0, ref count, 2);
            return count;
        }

        // Modified search function to count solutions
        private void Search(int k, ref int count, int limit)
        {
            if (header.R == header)
            {
                count++;
                return;
            }

            if (count >= limit) return;

            ColumnNode c = (ColumnNode)header.R;
            for (ColumnNode j = (ColumnNode)header.R; j != header; j = (ColumnNode)j.R)
            {
                if (j.Size < c.Size) c = j;
            }

            c.Cover();

            for (DancingNode r = c.D; r != c; r = r.D)
            {
                answer.Add(r);

                for (DancingNode j = r.R; j != r; j = j.R)
                {
                    j.C.Cover();
                }

                Search(k + 1, ref count, limit);

                r = answer[answer.Count - 1];
                answer.RemoveAt(answer.Count - 1);

                c = r.C;
                for (DancingNode j = r.L; j != r; j = j.L)
                {
                    j.C.Uncover();
                }

                if (count >= limit) break;
            }
            c.Uncover();
        }

        // Create the Dancing Links board for the given Sudoku grid
        private ColumnNode CreateDLXBoard(int[,] grid)
        {
            ColumnNode headerNode = new ColumnNode("header");
            List<ColumnNode> columnNodes = new List<ColumnNode>();

            // Create column nodes for each constraint
            for (int i = 0; i < Size * Size; i++)
                columnNodes.Add(new ColumnNode($"rc{i}"));  // Cell constraints
            for (int i = 0; i < Size * Size; i++)
                columnNodes.Add(new ColumnNode($"rn{i}"));  // Row constraints
            for (int i = 0; i < Size * Size; i++)
                columnNodes.Add(new ColumnNode($"cn{i}"));  // Column constraints
            for (int i = 0; i < Size * Size; i++)
                columnNodes.Add(new ColumnNode($"bn{i}"));  // Box constraints

            foreach (var column in columnNodes)
                headerNode.R.L.R = column.Hook();

            // Add a node for each possible digit placement
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    for (int n = 1; n <= Size; n++)
                    {
                        if (grid[r, c] == 0 || grid[r, c] == n)
                        {
                            DancingNode node = new DancingNode(columnNodes[r * Size + c]);
                            node.RowID = EncodeRowID(n, r, c);
                            for (int j = 1; j < 4; j++)
                            {
                                int index = Size * Size * j + Size * r + c;
                                if (j == 1) index = Size * Size * j + Size * r + n - 1;
                                if (j == 2) index = Size * Size * j + Size * c + n - 1;
                                if (j == 3) index = Size * Size * j + Size * (r / BoxSize * BoxSize + c / BoxSize) + n - 1;
                                new DancingNode(columnNodes[index]).Hook().L = node.Hook().L;
                            }
                        }
                    }
                }
            }

            return headerNode;
        }

        // Encode row, column, and digit into a single integer
        private int EncodeRowID(int digit, int row, int col)
        {
            return digit + row * 10 + col * 100;
        }

        // Decode a RowID back into digit, row, and column
        private int[] DecodeRowID(int rowID)
        {
            return new int[] { rowID % 10, (rowID / 10) % 10, rowID / 100 };
        }


    }

}
