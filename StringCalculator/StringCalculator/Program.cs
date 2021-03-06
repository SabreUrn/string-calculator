﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator {
	class Program {
		static void Main(string[] args) {
			StringCalculator c = new StringCalculator();
			string numbers = "// \n4 3 8 5";
			Console.WriteLine(c.Add(numbers));
			Console.WriteLine();

			Match match = Regex.Match(numbers, @"\/\/.{1}\n");
			Console.WriteLine(match.Success);

			string numbers2 = "3,4\n3";
			Match matchDelimiter = Regex.Match(numbers2, @"(?<=\/\/).+(?=\n)");
			Console.WriteLine(matchDelimiter.Success);
			Console.WriteLine(c.Add(numbers2));
			Console.WriteLine();

			string delimiter = "[!!!][**]";
			List<string> delimiterList = new List<string>(); //Regex.Split(delimiter, @"(?<=[\[.+\]])").ToList();
			foreach (Match m in Regex.Matches(delimiter, @"\[.+?\]")) {
				delimiterList.Add(m.Value);
			}

			Console.WriteLine(delimiterList.Count + " elements in list:");
			foreach(string s in delimiterList) {
				Console.WriteLine(s);
			}
			

			/*
			int[] arr = { 3, 6, 1, 667, 1615, 33 };
			int[] arr2 = arr.Select(n => { if (n > 1000) n = 0; return n; }).ToArray();
			foreach(int i in arr2) {
				Console.WriteLine(i);
			}
			*/

			Console.ReadKey();
			/*
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
			*/
		}
	}
}
