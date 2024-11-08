using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// The implemented puzzle types
    /// </summary>
    public enum PuzzleType
    {
        /// <summary>
        /// Classic 9x9 puzzle with easy difficulty
        /// </summary>
        Classic9x9Easy,
        /// <summary> 
        /// Classic 9x9 puzzle with medium difficulty
        /// </summary>
        Classic9x9Medium,
        /// <summary>
        /// Classic 9x9 puzzle with hard difficulty
        /// </summary>
        Classic9x9Hard,
        /// <summary>
        /// Classic 9x9 puzzle with custom difficulty
        /// </summary>
        Classic9x9Custom
    }
}
