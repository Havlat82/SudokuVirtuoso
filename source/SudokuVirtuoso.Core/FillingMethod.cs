using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// The type of filling that should be performed
    /// </summary>
    public enum FillingType
    {
        /// <summary>
        /// Fill to solve the puzzle.
        /// </summary>
        Solve,
        /// <summary>
        /// Fill to generate the puzzle.
        /// </summary>
        Generate
    }
}
