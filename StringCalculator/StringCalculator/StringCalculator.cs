using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator {
	public class StringCalculator {
		public int Add(string numbers) {
			char delimiter = ',';

			Match match = Regex.Match(numbers, @"\/\/[^\s]\n");
			if(match.Success) {
				//set delimiter
				delimiter = match.Value[2];
				numbers = numbers.Substring(4);
			}

			string[] numbersArray = numbers.Split(delimiter, '\n');
			if (numbersArray == null || StringArrayIsEmpty(numbersArray)) {
				return 0;
			}

			List<int> negativeNumbers = new List<int>();
			foreach(string number in numbersArray) {
				if(Int32.Parse(number) < 0) {
					negativeNumbers.Add(Int32.Parse(number));
				}
			}
			if(negativeNumbers.Count > 0) {
				string negativeNumbersFormatted = "Negatives not allowed. Negatives: " + String.Join(",", negativeNumbers);
				throw new NegativeNumberException(negativeNumbersFormatted);
			}

			int result = 0;
			foreach (string number in numbersArray) {
				result += Int32.Parse(number);
			}
			return result;
		}

		private bool StringArrayIsEmpty(string[] array) {
			if(array.Length == 0) {
				return true;
			}

			foreach(string s in array) {
				if(s != "") {
					return false;
				} else {
					return true;
				}
			}

			return false;
		}
	}
}
