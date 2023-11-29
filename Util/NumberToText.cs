namespace Util
{
	public static class NumberToText
	{
		public static string ToText(this byte number) { return ToText((long)number); }
		public static string ToText(this short number) { return ToText((long)number); }
		public static string ToText(this int number) { return ToText((long)number); }
		public static string ToText(this long number)
		{
			if (number < 0)
			{
				if (number == long.MinValue) return LongMinSpecialCase();
				number = number * -1;
				return "minus " + DoConversion(number);
			}
			return DoConversion(number);
		}
//		private string ToText(ulong number) // Not CLS compliant but can support if necessary
		private static string DoConversion(long number)
		{ 
			if ((number >= 0) && (number < 20))
			{
				string[] text = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
					"eleven", "twelve","thirteen", "forteen", "fifteen", "sixteen", "seventeen", "eighteen", "ninteen" };
				int ix = (int)number;
				return text[ix];
			}
			if ((number >= 20) && (number < 100))
			{
				string[] text = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninty" };
				int ix = ((int)number - 20) / 10;
				int tens = (ix + 2) * 10;
				int units = (int)number - tens;
				if (units == 0) return text[ix];
				return text[ix] + " " + units.ToText();
			}
			if ((number >= 100) && (number < 1000))
			{
				return Encode(number, 100, "hundred");
			}
			if ((number >= 1000) && (number < 1000000))
			{
				return Encode(number, 1000, "thousand");
			}
			if ((number >= 1000000) && (number < 1000000000))
			{
				return Encode(number, 1000000, "million");
			}
			if ((number >= 1000000000L) && (number < 1000000000000L))
			{
				return Encode(number, 1000000000L, "billion");
			}
			if ((number >= 1000000000000L) && (number < 1000000000000000L))
			{
				return Encode(number, 1000000000000L, "trillion");
			}
			if ((number >= 1000000000000000L) && (number < 1000000000000000000L))
			{
				return Encode(number, 1000000000000000L, "quadrillion");
			}
			if ((number >= 1000000000000000000L) && (number <= long.MaxValue))
			{
				return Encode(number, 1000000000000000000L, "quintillion");
			}
			return string.Empty;
		}
		private static string LongMinSpecialCase()
		{
			// cannot fall through to positive because of 2's complement arithmetic.
			string text = "minus nine quintillion ";
			text += "two hundred twenty three quadrillion ";
			text += "three hundred seventy two trillion ";
			text += "thirty six billion ";
			text += "eight hundred fifty four million ";
			text += "seven hundred seventy five thousand ";
			text += "eight hundred eight";
			return text;
		}
		private static string Encode(long number, long divisor, string rangeName)
		{
			long units = number / divisor;
			long range = units * divisor;
			long subRange = number - range;
			string temp = units.ToText() + " " + rangeName;
			if (subRange == 0) return temp;
			return temp + " " + subRange.ToText();
		}
	}
}
