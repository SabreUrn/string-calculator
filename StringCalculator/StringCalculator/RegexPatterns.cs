using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator {
	public static class RegexPatterns {
		/// <summary>
		/// Checks for "//.+\n" where .+ is a length of 1 or more of any character
		/// </summary>
		/// <returns>Returns one or more characters surrounded by "//" and "\n" respectively.</returns>
		public static string DelimiterFullMatch() {
			return @"\/\/.+\n";
		}

		/// <summary>
		/// @"(?&lt=\/\/).+(?=\n)" returned.
		/// Positive lookbehind checks if // is behind our match.
		/// Positive lookahead checks if "\n" is in front of our match.
		/// </summary>
		/// <returns>Returns a delimiter surrounded by "//" and "\n" respectively.
		/// Square brackets of multi-char delimiters are included.</returns>
		public static string DelimiterOnlyMatch() {
			return @"(?<=\/\/).+(?=\n)";
		}

		public static string DelimiterSingleMatch() {
			return @"\[.+?\]";
		}
	}
}
