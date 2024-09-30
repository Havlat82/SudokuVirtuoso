using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    class IntWrapper : IEquatable<IntWrapper>
    {
        public int Value { get; set; }

        public bool Equals(IntWrapper other) => other != null && Value == other.Value;

        public override bool Equals(object obj) => obj is IntWrapper wrapper && Equals(wrapper);

        public override int GetHashCode() => HashCode.Combine(Value);
        
    }
}
