using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using System;

namespace UtilTests
{
	[TestClass]
	public class NumberToTextTests
	{
		[TestMethod]
		public void ZeroTest()
		{
			Assert.AreEqual("zero", 0.ToText());
		}
		[TestMethod]
		public void OneToNinteenTest()
		{
			Assert.AreEqual("one", 1.ToText());
			Assert.AreEqual("two", 2.ToText());
			Assert.AreEqual("three", 3.ToText());
			Assert.AreEqual("four", 4.ToText());
			Assert.AreEqual("five", 5.ToText());
			Assert.AreEqual("six", 6.ToText());
			Assert.AreEqual("seven", 7.ToText());
			Assert.AreEqual("eight", 8.ToText());
			Assert.AreEqual("nine", 9.ToText());
			Assert.AreEqual("ten", 10.ToText());
			Assert.AreEqual("eleven", 11.ToText());
			Assert.AreEqual("twelve", 12.ToText());
			Assert.AreEqual("thirteen", 13.ToText());
			Assert.AreEqual("forteen", 14.ToText());
			Assert.AreEqual("fifteen", 15.ToText());
			Assert.AreEqual("sixteen", 16.ToText());
			Assert.AreEqual("seventeen", 17.ToText());
			Assert.AreEqual("eighteen", 18.ToText());
			Assert.AreEqual("ninteen", 19.ToText());
		}
		[TestMethod]
		public void MinusTest()
		{
			Assert.AreEqual("minus one", (-1).ToText());
			Assert.AreEqual("minus ninteen", (-19).ToText());
			Assert.AreEqual("minus ten", (-10).ToText());
		}
		//[TestMethod]
		//[ExpectedException(typeof(ArgumentException))]
		//public void NumberTooBigTest()
		//{
		//	long number = 999999999999999999L + 1;
		//	string text = number.ToText();
		//}
		//[TestMethod]
		//[ExpectedException(typeof(ArgumentException))]
		//public void NumberTooSmallTest()
		//{
		//	long number = -999999999999999999L - 1;
		//	string text = number.ToText();
		//}
		[TestMethod]
		public void TwentyToNintyNineTest()
		{
			Assert.AreEqual("twenty", 20.ToText());
			Assert.AreEqual("thirty", 30.ToText());
			Assert.AreEqual("forty", 40.ToText());
			Assert.AreEqual("fifty", 50.ToText());
			Assert.AreEqual("sixty", 60.ToText());
			Assert.AreEqual("seventy", 70.ToText());
			Assert.AreEqual("eighty", 80.ToText());
			Assert.AreEqual("ninty", 90.ToText());

			Assert.AreEqual("ninty nine", 99.ToText());
			Assert.AreEqual("seventy five", 75.ToText());
			Assert.AreEqual("eighty one", 81.ToText());
			Assert.AreEqual("minus fifty six", (-56).ToText());
			Assert.AreEqual("minus forty four", (-44).ToText());
		}
		[TestMethod]
		public void OneHundredToNineHundredNintyNineTest()
		{
			Assert.AreEqual("one hundred", 100.ToText());
			Assert.AreEqual("two hundred", 200.ToText());
			Assert.AreEqual("three hundred", 300.ToText());
			Assert.AreEqual("four hundred", 400.ToText());
			Assert.AreEqual("five hundred", 500.ToText());
			Assert.AreEqual("six hundred", 600.ToText());
			Assert.AreEqual("seven hundred", 700.ToText());
			Assert.AreEqual("eight hundred", 800.ToText());
			Assert.AreEqual("nine hundred", 900.ToText());
			Assert.AreEqual("nine hundred ninty nine", 999.ToText());
			Assert.AreEqual("seven hundred fifty five", 755.ToText());
			Assert.AreEqual("two hundred fifty six", 256.ToText());
			Assert.AreEqual("minus three hundred fifty", (-350).ToText());
			Assert.AreEqual("minus eight hundred sixteen", (-816).ToText());
		}
		[TestMethod]
		public void OneThousandTo999999Test()
		{
			Assert.AreEqual("one thousand", 1000.ToText());
			Assert.AreEqual("two thousand", 2000.ToText());
			Assert.AreEqual("nine thousand", 9000.ToText());
			Assert.AreEqual("nine hundred ninty nine thousand nine hundred ninty nine", 999999.ToText());
			Assert.AreEqual("three thousand four hundred twenty one", 3421.ToText());
			Assert.AreEqual("seventy thousand sixty six", 70066.ToText());
			Assert.AreEqual("five hundred thousand three hundred eighty nine", 500389.ToText());
			Assert.AreEqual("minus sixty thousand seventy seven", (-60077).ToText());
		}
		[TestMethod]
		public void RangeTest()
		{
			Assert.AreEqual("one million", 1000000L.ToText());
			Assert.AreEqual("one billion", 1000000000L.ToText());
			Assert.AreEqual("one trillion", 1000000000000L.ToText());
			Assert.AreEqual("one quadrillion", 1000000000000000L.ToText());
			Assert.AreEqual("one quintillion", 1000000000000000000L.ToText());
		}
		[TestMethod]
		public void QuadrillionTest()
		{
			string expected = "nine hundred ninty nine quadrillion ";
			expected += "nine hundred ninty nine trillion ";
			expected += "nine hundred ninty nine billion ";
			expected += "nine hundred ninty nine million ";
			expected += "nine hundred ninty nine thousand ";
			expected += "nine hundred ninty nine";
			Assert.AreEqual(expected, 999999999999999999L.ToText());
			expected = "minus " + expected;
			Assert.AreEqual(expected, (-999999999999999999L).ToText());
		}
		[TestMethod]
		public void LongMaxTest()
		{
			string expected = "nine quintillion ";
			expected += "two hundred twenty three quadrillion ";
			expected += "three hundred seventy two trillion ";
			expected += "thirty six billion ";
			expected += "eight hundred fifty four million ";
			expected += "seven hundred seventy five thousand ";
			expected += "eight hundred seven";
			Assert.AreEqual(expected, long.MaxValue.ToText());
		}
		[TestMethod]
		public void LongMinTest()
		{
			string expected = "minus nine quintillion ";
			expected += "two hundred twenty three quadrillion ";
			expected += "three hundred seventy two trillion ";
			expected += "thirty six billion ";
			expected += "eight hundred fifty four million ";
			expected += "seven hundred seventy five thousand ";
			expected += "eight hundred eight";
			Assert.AreEqual(expected, long.MinValue.ToText());
		}
		[TestMethod]
		public void LongMinPlus1Test()
		{
			string expected = "minus nine quintillion ";
			expected += "two hundred twenty three quadrillion ";
			expected += "three hundred seventy two trillion ";
			expected += "thirty six billion ";
			expected += "eight hundred fifty four million ";
			expected += "seven hundred seventy five thousand ";
			expected += "eight hundred seven";
			long number = long.MinValue + 1;
			Assert.AreEqual(expected, number.ToText());
		}
	}
}

