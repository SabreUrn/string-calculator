using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator {
	public class StringCalculator {
		public int Add(string numbers) {
			string[] numbersArray = NumberStringArrayTools.SetupStringArrayFromStringWithNumbers(numbers);

			if (NumberStringArrayTools.StringArrayIsEmpty(numbersArray)) {
				return 0;
			}

			return NumberIntArrayTools.GetIntSumFromStringArrayNumbersWithNumberCeiling(numbersArray, 1000);
		}
	}
}
