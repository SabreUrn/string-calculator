using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator {
	class Program {
		static void Main(string[] args) {

			string numbers = "2\n2\n2";
			//Regex.Split();
			numbers = Regex.Replace(numbers, "\n", ",");
			string[] arr = numbers.Split(',');
			Console.WriteLine(numbers);
			foreach (string s in arr) {
				Console.WriteLine(s);
			}
			Console.WriteLine("Printed out.");
			Console.ReadKey();
		}
	}
}
