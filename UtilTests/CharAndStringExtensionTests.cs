using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilTests
{
	[TestClass]
	public class CharAndStringExtensionTests
	{
		[TestMethod]
		public void char_IsNumericTest()
		{
			for (char x = 'a'; x <= 'z'; x++)
				Assert.IsFalse(x.IsNumeric());
			for (char x = 'A'; x <= 'Z'; x++)
				Assert.IsFalse(x.IsNumeric());
			for (char x = '0'; x <= '9'; x++)
				Assert.IsTrue(x.IsNumeric());
			for (char x = (char)0; x <= '\u0020'; x++)
				Assert.IsFalse(x.IsNumeric());
		}
		[TestMethod]
		public void string_IsNumericTest()
		{
			string x = "The quick brown fox jumped over the lazy dog";
			Assert.IsFalse(x.IsNumeric());
			x = "123";
			Assert.IsTrue(x.IsNumeric());
			x = "123.45";
			Assert.IsFalse(x.IsNumeric());
			x = "999999999999";
			Assert.IsTrue(x.IsNumeric());
		}
		[TestMethod]
		public void char_IsNumericAllowingDecimalPointTest()
		{
			char x = '.';
			Assert.IsTrue(x.IsNumericAllowingDecimalPoint());
			for (x = 'a'; x <= 'z'; x++)
				Assert.IsFalse(x.IsNumericAllowingDecimalPoint());
			for (x = 'A'; x <= 'Z'; x++)
				Assert.IsFalse(x.IsNumericAllowingDecimalPoint());
			for (x = '0'; x <= '9'; x++)
				Assert.IsTrue(x.IsNumericAllowingDecimalPoint());
			for (x = (char)0; x <= '\u0020'; x++)
				Assert.IsFalse(x.IsNumericAllowingDecimalPoint());
		}
		[TestMethod]
		public void string_IsNumericAllowingDecimalPointTest()
		{
			string x = "The quick brown fox jumped over the lazy dog";
			Assert.IsFalse(x.IsNumericAllowingDecimalPoint());
			x = "123";
			Assert.IsTrue(x.IsNumericAllowingDecimalPoint());
			x = "123.45";
			Assert.IsTrue(x.IsNumericAllowingDecimalPoint());
			x = "999999999999";
			Assert.IsTrue(x.IsNumericAllowingDecimalPoint());
		}
		[TestMethod]
		public void char_IsAlphabeticTest()
		{
			for (char x = 'a'; x <= 'z'; x++)
				Assert.IsTrue(x.IsAlphabetic());
			for (char x = 'A'; x <= 'Z'; x++)
				Assert.IsTrue(x.IsAlphabetic());
			for (char x = '0'; x <= '9'; x++)
				Assert.IsFalse(x.IsAlphabetic());
			for (char x = (char)0; x < (char)0x20; x++)
				Assert.IsFalse(x.IsAlphabetic());
		}
		[TestMethod]
		public void string_IsAlphabeticTest()
		{
			string x = "The quick brown fox jumped over the lazy dog";
			Assert.IsFalse(x.IsAlphabetic());
			x = "123";
			Assert.IsFalse(x.IsAlphabetic());
			x = "123.45";
			Assert.IsFalse(x.IsAlphabetic());
			x = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Assert.IsTrue(x.IsAlphabetic());
		}
		[TestMethod]
		public void char_IsAlphabeticAllowingSpacesTest()
		{
			for (char x = 'a'; x <= 'z'; x++)
				Assert.IsTrue(x.IsAlphabeticAllowingSpaces());
			for (char x = 'A'; x <= 'Z'; x++)
				Assert.IsTrue(x.IsAlphabeticAllowingSpaces());
			for (char x = '0'; x <= '9'; x++)
				Assert.IsFalse(x.IsAlphabeticAllowingSpaces());
			for (char x = (char)0; x < (char)0x20; x++)
				Assert.IsFalse(x.IsAlphabeticAllowingSpaces());
		}
		[TestMethod]
		public void string_IsAlphabeticAllowingSpacesTest()
		{
			string x = "The quick brown fox jumped over the lazy dog";
			Assert.IsTrue(x.IsAlphabeticAllowingSpaces());
			x = "123";
			Assert.IsFalse(x.IsAlphabeticAllowingSpaces());
			x = "123.45";
			Assert.IsFalse(x.IsAlphabeticAllowingSpaces());
			x = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Assert.IsTrue(x.IsAlphabeticAllowingSpaces());
		}
	}
}
