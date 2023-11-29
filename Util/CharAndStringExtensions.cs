using System;
using System.Text;
using System.Security.Cryptography;

namespace Util
{
	public static class CharAndStringExtensions
	{
		public static string Encrypt(this string plainText)
		{
			StringBuilder sb = new StringBuilder();
			using (SHA256 hash = SHA256Managed.Create())
			{
				Encoding encoding = Encoding.UTF8;
				Byte[] result = hash.ComputeHash(encoding.GetBytes(plainText));
				foreach (Byte b in result) sb.Append(b.ToString("x2"));
			}
			return sb.ToString().Substring(0, 48);
		}
		public static bool IsNullOrEmpty(this string text)
		{
			if (text == null) return true;
			if (text == string.Empty) return true;
			return false;
		}
		public static string EmptyIfNull(this string text)
		{
			if (text == null) return string.Empty;
			return text;
		}
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
		public static bool IsUpperCaseAlphabetic(this string text)
		{
			foreach (char c in text)
				if (!c.IsUpperCaseAlphabetic()) return false;
			return true;
		}
		public static bool IsAlphabetic(this char c)
		{
			return (((c >= 'A') && (c <= 'Z')) || ((c >= 'a') && (c <= 'z')));
		}
		public static bool IsUpperCaseAlphabetic(this char c)
		{
			return ((c >= 'A') && (c <= 'Z'));
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
		public static bool ContainsAlphabetics(this string text)
		{
			foreach (char c in text)
			{
				if (c.IsAlphabetic()) return true;
			}
			return false;
		}
		public static bool ContainsNumerics(this string text)
		{
			foreach (char c in text)
			{
				if (c.IsNumeric()) return true;
			}
			return false;
		}
		public static bool ContainsSymbols(this string text)
		{
			foreach (char c in text)
			{
				if (!c.IsAlphabetic() && !c.IsNumeric()) return true;
			}
			return false;
		}
		public static string Shorten(this string text, int length)
		{
			if (text.Length < length) return text;
			text = text.Substring(0, length - 3);
			text += "...";
			return text;
		}
		public static string CapWords(this string text)
		{
			string capped = string.Empty;
			bool capNext = true;
			for (int i = 0; i < text.Length; i++)
			{
				if (capNext) capped += text[i];
				else capped += text.ToLower()[i];
				capNext = false;
				char c = text[i];
				if ((c == ' ') || (c == '-') || (c == '(') || (c == '/') || (c == '\'')) capNext = true;
			}
			return capped;
		}
		public static string Anglicize(this string text)
		{
			if (text == null) return string.Empty;
			if (text.Contains("&quot;")) text = text.Replace("&quot;", "'");
			if (text.Contains("&#039;")) text = text.Replace("&#039;", "'");
			if (text.Contains("&amp;amp;")) text = text.Replace("&amp;amp;", "&");
			if (text.Contains("&amp;")) text = text.Replace("&amp;", "&");
			if (text.Contains("Ã¨")) text = text.Replace("Ã¨", "e");
			if (text.Contains("Ã…")) text = text.Replace("Ã…", "A");
			if (text.Contains("Ã©")) text = text.Replace("Ã©", "e");
			if (text.Contains("ã´")) text = text.Replace("ã´", "o");
			if (text.Contains("Ã¡")) text = text.Replace("Ã¡", "a");
			if (text.Contains("Ã´")) text = text.Replace("Ã´", "o");
			if (text.Contains("Ã£")) text = text.Replace("Ã£", "a");
			if (text.Contains("Ãº")) text = text.Replace("Ãº", "u");
			if (text.Contains("Ã³")) text = text.Replace("Ã³", "o");
			if (text.Contains("â€˜")) text = text.Replace("â€˜", "'");
			if (text.Contains("â€“")) text = text.Replace("â€“", "-");
			if (text.Contains("Ã¶")) text = text.Replace("Ã¶", "o");
			if (text.Contains("Ã°")) text = text.Replace("Ã°", "d");
			if (text.Contains("Ã°")) text = text.Replace("Ã°", "a");
			if (text.Contains("Ã¦")) text = text.Replace("Ã¦", "ae");
			if (text.Contains("Ã½j")) text = text.Replace("Ã½j", "y");
			if (text.Contains("&#39;")) text = text.Replace("&#39;", "'");
			if (text.Contains("ÃŸ")) text = text.Replace("ÃŸ", "ss");
			if (text.Contains("Ã¼")) text = text.Replace("Ã¼", "u");
			if (text.Contains("Ã¤")) text = text.Replace("Ã¤", "a");
			if (text.Contains("Ã¸")) text = text.Replace("Ã¸", "o");
			if (text.Contains("Å‚")) text = text.Replace("Å‚", "l");
			if (text.Contains("È©")) text = text.Replace("È©", "e");
			if (text.Contains("Ã–")) text = text.Replace("Ã–", "O");
			if (text.Contains("Ã¥")) text = text.Replace("Ã¥", "a");
			if (text.Contains("Ä·")) text = text.Replace("Ä·", "hk");
			if (text.Contains("Å¾")) text = text.Replace("Å¾", "z");
			if (text.Contains("Å¡")) text = text.Replace("Å¡", "s");
			if (text.Contains("Ä—")) text = text.Replace("Ä—", "e");
			if (text.Contains("Å«")) text = text.Replace("Å«", "u");
			if (text.Contains("Å ")) text = text.Replace("Å ", "S");
			if (text.Contains("Å™")) text = text.Replace("Å™", "r");
			if (text.Contains("Åˆ")) text = text.Replace("Åˆ", "n");
			if (text.Contains("ÄŒ")) text = text.Replace("ÄŒ", "C");
			if (text.Contains("Ä›")) text = text.Replace("Ä›", "e");
			if (text.Contains("Ä")) text = text.Replace("Ä", "c");
			if (text.Contains("Å¯")) text = text.Replace("Å¯", "u");
			if (text.Contains("Å„")) text = text.Replace("Å„", "n");
			if (text.Contains("Ã„")) text = text.Replace("Ã„", "A");
			if (text.Contains("Ä™")) text = text.Replace("Ä™", "e");
			if (text.Contains("Å»")) text = text.Replace("Å»", "Z");
			if (text.Contains("â€™")) text = text.Replace("â€™","'");
			if (text.Contains("Ã­"))
			{
				string temp = string.Empty;
				for (int i = 0; i < text.Length; i++)
				{
					if (((int)text[i] == 195) && ((int)text[i + 1] == 173))
					{
						temp += "i";
						i++;
					}
					else temp += text[i];
				}
				text = temp;
			}
			return text;
		}
	}
}
