using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator {
	public static class NumberStringArrayTools {
		/// <summary>
		/// Converts a string of numbers separated by a delimiter into a string array of each number.
		/// The first line of the string can optionally set the delimiter (by default ",") with the format "//.\n" where . is any character
		/// </summary>
		/// <param name="numbers">The string of numbers to convert to array.</param>
		/// <returns>Returns a string array of numbers represented as text.</returns>
		public static string[] SetupStringArrayFromStringWithNumbers(string numbers) {
			string delimiter = ",";

			List<string> delimiterList = new List<string>();
			Match match = Regex.Match(numbers, RegexPatterns.DelimiterFullMatch());
			if (match.Success) {
				Match matchDelimiter = Regex.Match(numbers, RegexPatterns.DelimiterOnlyMatch()); //first () is a positive lookbehind to see if // is behind our match. second () is a positive lookahead to see if "\n" is in front of our match. grabs only the delimiter

				foreach(Match m in Regex.Matches(matchDelimiter.Value, @"\[.+?\]")) {
					delimiterList.Add(HandleDelimiterMultipleCharSyntax(m.Value));
				}
				if(delimiterList.Count == 0) {
					delimiter = matchDelimiter.Value;
					delimiterList.Add(HandleDelimiterMultipleCharSyntax(delimiter));
				}

				//delimiter = matchDelimiter.Value;
				//delimiter = HandleDelimiterMultipleCharSyntax(delimiter);
				numbers = numbers.Substring(match.Value.Length);
			}
			if(delimiterList.Count == 0) {
				delimiterList.Add(HandleDelimiterMultipleCharSyntax(delimiter));
			}
			delimiterList.Add("\n");

			string[] delimiterArray = delimiterList.ToArray();
			string[] numbersArray = numbers.Split(delimiterList.ToArray(), StringSplitOptions.RemoveEmptyEntries);

			return numbersArray;
		}

		/// <summary>
		/// Scrubs the square brackets from either side of a multi-char delimiter.
		/// </summary>
		/// <param name="delimiter">The delimiter to scrub.</param>
		/// <returns>Returns the scrubbed delimiter.</returns>
		private static string HandleDelimiterMultipleCharSyntax(string delimiter) {
			//for each [] delimiter block match, strip [] from delimiter and add to list

			if (delimiter.StartsWith("[") && delimiter.EndsWith("]")) {
				delimiter = delimiter.Substring(1, delimiter.Length - 2);
			}
			//we don't know how many elements our enumerable has, so we use a list instead of an array
			return delimiter;
		}

		/// <summary>
		/// Checks if a string array contains either no elements or if it only contains empty elements.
		/// </summary>
		/// <param name="array">The string array to check.</param>
		/// <returns>Returns true if the string array is empty or if all elements are empty. Returns false otherwise.</returns>
		public static bool StringArrayIsEmpty(string[] array) {
			if (array == null) {
				return true;
			}
			if (array.Length == 0) {
				return true;
			}

			foreach (string s in array) {
				if (!String.IsNullOrWhiteSpace(s)) {
					return false;
				}
			}
			return true;
		}
	}
}
