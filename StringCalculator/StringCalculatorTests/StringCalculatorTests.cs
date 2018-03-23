using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests {
	[TestClass()]
	public class StringCalculatorTests {
		[TestMethod()]
		public void AddTest_2Plus2() {
			//arrange 3
			StringCalculator calculator = new StringCalculator();
			int expected = 4;
			string numbers = "2,2";

			//act 2
			int actual = calculator.Add(numbers);

			//assert 1
			Assert.AreEqual(expected, actual);

			//conclude 4
		}

		[TestMethod()]
		public void AddTest_EmptyString() {
			//arrange 3
			StringCalculator calculator = new StringCalculator();
			int expected = 0;
			string numbers = "";

			//act 2
			int actual = calculator.Add(numbers);

			//assert 1
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void AddTest_3Plus4() {
			//arrange 3
			StringCalculator calculator = new StringCalculator();
			int expected = 7;
			string numbers = "3,4";

			//act 2
			int actual = calculator.Add(numbers);

			//assert 1
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void AddTest_ThreeNumbers() {
			//arrange
			StringCalculator calculator = new StringCalculator();
			int expected = 10;
			string numbers = "3,4,3";

			//act
			int actual = calculator.Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void AddTest_NewLine() {
			//arrange
			StringCalculator calculator = new StringCalculator();
			int expected = 10;
			string numbers = "3,4\n3";

			//act
			int actual = calculator.Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void AddTest_DifferentDelimiters() {
			//arrange
			StringCalculator calculator = new StringCalculator();
			int expected = 20;
			string numbers = "// \n4 3 8 5";

			//act
			int actual = calculator.Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		[ExpectedException(typeof(NegativeNumberException))]
		public void AddTest_NegativeNumber_ExpectEx() {
			//arrange
			StringCalculator calculator = new StringCalculator();
			string numbers = "//!\n-4!1!-3";

			//act
			int actual = calculator.Add(numbers);
		}

		[TestMethod()]
		public void AddTest_IgnoreNumberGreaterThan1000() {
			//arrange
			StringCalculator calculator = new StringCalculator();
			int expected = 2;
			string numbers = "2,1001";

			//act
			int actual = calculator.Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void AddTest_DelimitersLongerThanOneChar() {
			//arrange
			StringCalculator calculator = new StringCalculator();
			int expected = 10;
			string numbers = "//[!!!]\n4!!!5!!!1";

			//act
			int actual = calculator.Add(numbers);

			//assert
			Assert.AreEqual(expected, actual);
		}
	}
}