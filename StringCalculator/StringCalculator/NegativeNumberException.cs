using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator {
	public class NegativeNumberException : Exception {
		public NegativeNumberException() {
		}

		public NegativeNumberException(string message)
		: base(message) {
		}

		public NegativeNumberException(string message, Exception inner)
		: base(message, inner) {
		}
	}
}
