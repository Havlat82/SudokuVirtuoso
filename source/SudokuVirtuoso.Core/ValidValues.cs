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

        #region Random

        /*
         * pravděpodobně dám do samostatný třídy
         */

        /// <summary>
        /// Gets a new HashSet with the valid values in random order.
        /// </summary>
        /// <returns>A new HashSet with randomized valid values.</returns>
        public HashSet<int> GetRandom()
        {
            // Create a new array to avoid modifying the original set
            var valueArray = _values.ToArray();

            // Use a cryptographically secure random number generator for better randomness
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Implement Fisher-Yates shuffle
                for (var valueIndex = valueArray.Length - 1; valueIndex > 0; valueIndex--)
                {
                    var randomIndex = GetRandomIndexInArray(rng, new byte[4], valueIndex);
                    SwapValuesInArray(valueArray, valueIndex, randomIndex);
                }
            }

            // Return a new HashSet to maintain immutability of the original set
            return new HashSet<int>(valueArray);
        }

        private int GetRandomIndexInArray(RNGCryptoServiceProvider random, byte[] randomBytes, int index)
        {
            random.GetBytes(randomBytes);
            return BitConverter.ToInt32(randomBytes, 0) % (index + 1);
        }

        private void SwapValuesInArray(int[] intArray, int index1, int index2)
        {
            int temp = intArray[index1];
            intArray[index1] = intArray[index2];
            intArray[index2] = temp;
        }

        #endregion Random

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidValues"/> class.
        /// </summary>
        /// <param name="min">The HashSet of valid values.</param>
        /// <param name="max">The HashSet of valid values.</param>
        /// <exception cref="ArgumentException">Thrown when values in range between min and max are invalid.</exception>
        public ValidValues(int min, int max)
        {
            var newValues = new HashSet<int>(Enumerable.Range(min, max));

            if (AreNotValid(newValues))
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
            if (AreNullOrEmpty(newValues))
                throw new ArgumentException("Values cannot be null or empty.", nameof(newValues));

            if (AreNotValid(newValues))
                throw new ArgumentException("The provided values are not valid for Sudoku.");

            _values = newValues;
        }

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

        public static bool operator ==(ValidValues left, ValidValues right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValidValues left, ValidValues right)
        {
            return !left.Equals(right);
        }

        // tyhle dvě přesunu
        public static bool AreNullOrEmpty(HashSet<int> values)
        {
            if (values == null || values.Count == 0)
                return false;

            return true;
        }

        public static bool AreNotValid(HashSet<int> values)
        {
            if (values.Contains(Rules.EMPTY_CELL_VALUE))
                return true;

            return false;
        }

        private readonly HashSet<int> _values;
    }
}