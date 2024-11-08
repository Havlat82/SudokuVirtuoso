using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SudokuVirtuoso.Core
{
    /// <summary>
    /// Provides methods for shuffling values in a secure and random manner.
    /// </summary>
    public static class ValueShuffler
    {
        /// <summary>
        /// Gets a new HashSet with the valid values in random order.
        /// </summary>
        /// <returns>A new HashSet with randomized valid values.</returns>
        public static HashSet<int> GetShuffledValues(HashSet<int> values)
        {
            // Create a new array to avoid modifying the original set
            var valueArray = values.ToArray();

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

        private static int GetRandomIndexInArray(RNGCryptoServiceProvider random, byte[] randomBytes, int index)
        {
            random.GetBytes(randomBytes);
            // Convert the randomBytes to an integer in the range 0 to index
            return BitConverter.ToInt32(randomBytes, 0) % (index + 1);
        }

        private static void SwapValuesInArray(int[] intArray, int index1, int index2)
        {
            int temp = intArray[index1];
            intArray[index1] = intArray[index2];
            intArray[index2] = temp;
        }
    }
}