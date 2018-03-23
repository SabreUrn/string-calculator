using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator {
	public class StringCalculator {

		public int Add(string numbers) {
			string[] numbersArray = SetupStringArray(numbers);

			if (StringArrayIsEmpty(numbersArray)) {
				return 0;
			}

			int[] numbersArrayInt = ConvertStringArrayToIntArray(numbersArray);
			numbersArrayInt = RemoveNumbersGreaterThan(1000, numbersArrayInt);

			//numbersArrayInt = numbersArrayInt.Select(n => { if (n > 1000) n = 0; return n; }).ToArray();

			CheckStringArrayForNegativeNumbers(numbersArrayInt);
			int result = AddNumbersInIntArray(numbersArrayInt);
			return result;
		}

		/// <summary>
		/// Converts a string of numbers separated by a delimiter into a string array of each number.
		/// The first line of the string can optionally set the delimiter (by default ",") with the format "//.\n" where . is any character
		/// </summary>
		/// <param name="numbers">The string of numbers to convert to array.</param>
		/// <returns>Returns a string array of numbers represented as text.</returns>
		private string[] SetupStringArray(string numbers) {
			string delimiter = ",";

			Match match = Regex.Match(numbers, @"\/\/.+\n"); //checks for "//*\n" where * is any length of any character
			if (match.Success) {
				Match matchDelimiter = Regex.Match(numbers, @"(?<=\/\/).+(?=\n)"); //first () is a positive lookbehind to see if // is behind our match. second () is a positive lookahead to see if "\n" is in front of our match. grabs only the delimiter
				delimiter = matchDelimiter.Value;
				delimiter = HandleDelimiterMultipleCharSyntax(delimiter);
				numbers = numbers.Substring(match.Value.Length);
			}
			string[] numbersArray = numbers.Split(new string[] { delimiter, "\n" }, StringSplitOptions.RemoveEmptyEntries);

			return numbersArray;
		}

		private string HandleDelimiterMultipleCharSyntax(string delimiter) {
			if(delimiter.Length > 1) {
				delimiter = delimiter.Substring(1, delimiter.Length - 2);
			}
			return delimiter;
		}

		/// <summary>
		/// Checks if a string array contains either no elements or if it only contains empty elements.
		/// </summary>
		/// <param name="array">The string array to check.</param>
		/// <returns>Returns true if the string array is empty or if all elements are empty. Returns false otherwise.</returns>
		private bool StringArrayIsEmpty(string[] array) {
			if(array == null) {
				return true;
			}
			if(array.Length == 0) {
				return true;
			}

			foreach(string s in array) {
				if(!String.IsNullOrWhiteSpace(s)) {
					return false;
				} else {
					return true;
				}
			}

			return false;
		}

		private int[] ConvertStringArrayToIntArray(string[] stringArray) {
			return Array.ConvertAll(stringArray, n => Int32.Parse(n));
		}

		private int[] RemoveNumbersGreaterThan(int limit, int[] array) {
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
		private void CheckStringArrayForNegativeNumbers(int[] array) {
			List<int> negativeNumbers = new List<int>();
			foreach(int number in array) {
				if(number < 0) {
					negativeNumbers.Add(number);
				}
			}
			if(negativeNumbers.Count > 0) {
				string negativeNumbersFormatted = String.Join(",", negativeNumbers);
				throw new NegativeNumberException("Negative not allowed. Negatives: " + negativeNumbersFormatted);
			}
		}

		/// <summary>
		/// Adds numbers in an int array together and returns the sum.
		/// </summary>
		/// <param name="array"></param>
		/// <returns>The sum of all numbers in the int array.</returns>
		private int AddNumbersInIntArray(int[] array) {
			int result = 0;
			foreach(int number in array) {
				result += number;
			}
			return result;
		}
	}
}
