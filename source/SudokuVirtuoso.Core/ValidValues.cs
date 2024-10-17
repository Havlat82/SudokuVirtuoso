using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Collections;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Represents a set of valid values for a Sudoku puzzle.
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
            var newValues = new HashSet<int>(Enumerable.Range(min, max));

            if (ValueValidator.AreNotValid(newValues))
                throw new ArgumentException("The provided values are not valid for Sudoku.");

            _values = newValues;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidValues"/> class.
        /// </summary>
        /// <param name="newValues">The HashSet of valid values.</param>
        /// <exception cref="ArgumentException">Thrown when values are null, empty, or invalid.</exception>
        public ValidValues(HashSet<int> newValues)
        {
            if (ValueValidator.AreNullOrEmpty(newValues))
                throw new ArgumentException("Values cannot be null or empty.", nameof(newValues));

            if (ValueValidator.AreNotValid(newValues))
                throw new ArgumentException("The provided values are not valid for Sudoku.");

            _values = newValues;
        }

        #endregion

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

        #endregion

        #region Operators

        public static bool operator ==(ValidValues left, ValidValues right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValidValues left, ValidValues right)
        {
            return !left.Equals(right);
        }

        #endregion

        private readonly HashSet<int> _values;
    }
}