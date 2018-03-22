using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator {
	class Program {
		static void Main(string[] args) {
			char delimiter = ';';

			string numbers = "//;\n2;2;2";
			//Regex.Split();

			Match match = Regex.Match(numbers, @"\/\/[^\s]\n");
			if (match.Success) {
				//set delimiter
				delimiter = match.Value[2];
				numbers = numbers.Substring(4);
			}
			string[] arr = numbers.Split(delimiter, '\n');
			Console.WriteLine(numbers);
			foreach (string s in arr) {
				Console.WriteLine(s);
			}
			Console.WriteLine("Printed out.");
			Console.ReadKey();
		}
	}
}
