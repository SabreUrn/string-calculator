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

			for (int i = 0; i < numbersArrayInt.Count(); i++) {
				if(numbersArrayInt[i] > 1000) {
					numbersArrayInt[i] = 0;
				}
			}
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
			char delimiter = ',';
			Match match = Regex.Match(numbers, @"\/\/.{1}\n"); //checks for "//.\n" where . is any single character
			if(match.Success) {
				delimiter = match.Value[2];
				numbers = numbers.Substring(4); //4 is the index where regular strings will start
			}
			string[] numbersArray = numbers.Split(delimiter, '\n');

			return numbersArray;
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
