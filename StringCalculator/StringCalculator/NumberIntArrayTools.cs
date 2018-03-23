using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator {
	public static class NumberIntArrayTools {
		/// <summary>
		/// Takes an array of integers represented as strings and turns it into the sum of the integers
		/// as long as they aren't above the given limit.
		/// </summary>
		/// <param name="numbersArrayString">The string array of numbers to convert into an int sum.</param>
		/// <param name="limit">The greatest number an integer can be before being removed from the sum.</param>
		/// <returns>Returns the sum of the integer string elements in the given list.</returns>
		public static int GetIntSumFromStringArrayNumbersWithNumberCeiling(string[] numbersArrayString, int limit) {
			int[] numbersArrayInt = ConvertStringArrayToIntArray(numbersArrayString);
			numbersArrayInt = RemoveNumbersGreaterThan(limit, numbersArrayInt);

			CheckIntArrayForNegativeNumbers(numbersArrayInt);
			return AddNumbersInIntArray(numbersArrayInt);
		}

		/// <summary>
		/// Converts an array of integers represented as strings into an int array.
		/// </summary>
		/// <param name="stringArray">The string array to convert to an int array.</param>
		/// <returns>Returns the converted int array.</returns>
		private static int[] ConvertStringArrayToIntArray(string[] stringArray) {
			return Array.ConvertAll(stringArray, n => Int32.Parse(n));
		}

		/// <summary>
		/// Removes (sets to 0) all numbers greater than a given amount from an int array.
		/// </summary>
		/// <param name="limit">The limit for how high numbers in the array can be before being removed.</param>
		/// <param name="array">The int array to remove numbers from.</param>
		/// <returns></returns>
		private static int[] RemoveNumbersGreaterThan(int limit, int[] array) {
			for (int i = 0; i < array.Count(); i++) {
				if (array[i] > limit) {
					array[i] = 0;
				}
			}
			return array;
		}

		/// <summary>
		/// Throws NegativeNumberException if a given int array contains any negative numbers.
		/// The exception contains a formatted list of all negative numbers in the array.
		/// </summary>
		/// <param name="array">The array to be checked for negative numbers.</param>
		private static void CheckIntArrayForNegativeNumbers(int[] array) {
			List<int> negativeNumbers = new List<int>();
			foreach (int number in array) {
				if (number < 0) {
					negativeNumbers.Add(number);
				}
			}
			if (negativeNumbers.Count > 0) {
				string negativeNumbersFormatted = String.Join(",", negativeNumbers);
				throw new NegativeNumberException("Negative not allowed. Negatives: " + negativeNumbersFormatted);
			}
		}

		/// <summary>
		/// Adds numbers in an int array together and returns the sum.
		/// </summary>
		/// <param name="array"></param>
		/// <returns>The sum of all numbers in the int array.</returns>
		private static int AddNumbersInIntArray(int[] array) {
			int result = 0;
			foreach (int number in array) {
				result += number;
			}
			return result;
		}
	}
}
