using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Represents a set of valid values for a sudoku puzzle.
    /// </summary>
    public sealed class ValidValues : IEquatable<ValidValues>
    {
        /// <summary>
        /// Gets the minimum value in the set.
        /// </summary>
        public int Min => _values.Min();

        /// <summary>
        /// Gets the maximum value in the set.
        /// </summary>
        public int Max => _values.Max();

        /// <summary>
        /// Gets a read-only view of the valid values.
        /// </summary>
        /// <returns>A read-only set of valid values.</returns>
        public HashSet<int> Get() => _values;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidValues"/> class.
        /// </summary>
        /// <param name="min">The HashSet of valid values.</param>
        /// <param name="max">The HashSet of valid values.</param>
        /// <exception cref="ArgumentException">Thrown when values in range between min and max are invalid.</exception>
        public ValidValues(int min, int max)
        {
            _values = new HashSet<int>(Enumerable.Range(min, max));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidValues"/> class.
        /// </summary>
        /// <param name="newValues">The HashSet of valid values.</param>
        /// <exception cref="ArgumentException">Thrown when values are null, empty, or invalid.</exception>
        public ValidValues(HashSet<int> newValues)
        {
            _values = newValues;
        }

        #endregion Constructors

        #region IEquatable<ValidValues> Members

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(ValidValues other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return _values.SetEquals(other._values);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is ValidValues other && Equals(other);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return _values.GetHashCode();
        }

        #endregion IEquatable<ValidValues> Members

        #region Operators

        /// <summary>
        /// Determines whether two ValidValues instances are equal.
        /// </summary>
        /// <param name="left">The left ValidValues instance to compare.</param>
        /// <param name="right">The right ValidValues instance to compare.</param>
        /// <returns>True if the instances are equal, false otherwise.</returns>
        public static bool operator ==(ValidValues left, ValidValues right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two ValidValues instances are not equal.
        /// </summary>
        /// <param name="left">The left ValidValues instance to compare.</param>
        /// <param name="right">The right ValidValues instance to compare.</param>
        /// <returns>True if the instances are not equal, false otherwise.</returns>
        public static bool operator !=(ValidValues left, ValidValues right)
        {
            return !left.Equals(right);
        }

        #endregion Operators

        private readonly HashSet<int> _values;
    }
}