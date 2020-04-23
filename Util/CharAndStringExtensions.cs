using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
	public static class CharAndStringExtensions
	{
		public static bool IsNumeric(this string text)
		{
			foreach (char c in text)
				if (!c.IsNumeric()) return false;
			return true;
		}
		public static bool IsNumeric(this char c)
		{
			return (c >= '0') && (c <= '9');
		}
		public static bool IsNumericAllowingDecimalPoint(this string text)
		{
			foreach (char c in text)
				if (!c.IsNumericAllowingDecimalPoint()) return false;
			return true;
		}
		public static bool IsNumericAllowingDecimalPoint(this char c)
		{
			if (c == '.') return true;
			return (c >= '0') && (c <= '9');
		}
		public static bool IsAlphabetic(this string text)
		{
			foreach (char c in text)
				if (!c.IsAlphabetic()) return false;
			return true;
		}
		public static bool IsAlphabetic(this char c)
		{
			return (((c >= 'A') && (c <= 'Z')) || ((c >= 'a') && (c <= 'z')));
		}
		public static bool IsAlphabeticAllowingSpaces(this string text)
		{
			foreach (char c in text)
				if (!c.IsAlphabeticAllowingSpaces()) return false;
			return true;
		}
		public static bool IsAlphabeticAllowingSpaces(this char c)
		{
			if (c == '\u0020') return true;
			return (((c >= 'A') && (c <= 'Z')) || ((c >= 'a') && (c <= 'z')));
		}
		public static bool IsAlphaNumeric(this char c)
		{
			bool ret = c.IsAlphabetic() || c.IsNumeric();
			return ret;
		}
		public static bool IsAlphaNumeric(this string text)
		{
			foreach (char c in text)
				if (!text.IsAlphaNumeric()) return false;
			return true;
		}
	}
}
