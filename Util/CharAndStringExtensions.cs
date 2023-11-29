using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

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
		public static void Log(this string text)
		{
			using (StreamWriter log = new StreamWriter("log.log",true))
			{
				log.WriteLine(text);
			}	
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
			if (text.Trim().Length == 0) return false;
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
		public static bool HasNumerics(this string text)
		{
			foreach (char c in text)
			{
				if (c.IsNumeric()) return true;
			}
			return false;
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
				if (!c.IsAlphaNumeric()) return false;
			return true;
		}
		public static bool IsBlank(this string text)
		{
			foreach (char c in text)
			{
				if ((c != ' ') || (c != '\t')) return false;
			}
			return true;
		}
		public static bool HasAlphabetics(this string text)
		{
			foreach (char c in text)
			{
				if (c.IsAlphabetic()) return true;
			}
			return false;
		}
		public static bool HasSymbols(this string text)
		{
			foreach (char c in text)
			{
				if (!c.IsAlphabetic() && !c.IsNumeric()) return true;
			}
			return false;
		}
		public static string Squeeze(this string text)
		{
			text = text.Trim();
			while (text.Contains("  ")) text = text.Replace("  ", " ");
			return text;
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
			if (text.Contains("ë")) text = text.Replace("ë", "e");
			if (text.Contains("ç")) text = text.Replace("ç", "c");
			if (text.Contains("é")) text = text.Replace("é", "e");
			if (text.Contains("è")) text = text.Replace("è", "e");
			if (text.Contains("ğ")) text = text.Replace("ğ", "g");
			if (text.Contains("ş")) text = text.Replace("ş", "s");
			if (text.Contains("ö")) text = text.Replace("ö", "o");
			if (text.Contains("İ")) text = text.Replace("İ", "I");
			if (text.Contains("ə")) text = text.Replace("ə", "a");
			if (text.Contains("ü")) text = text.Replace("ü", "u");
			if (text.Contains("Ş")) text = text.Replace("Ş", "S");
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
			if (text.Contains("Ó")) text = text.Replace("Ó", "O");
			if (text.Contains("Å¯")) text = text.Replace("Å¯", "u");
			if (text.Contains("Å„")) text = text.Replace("Å„", "n");
			if (text.Contains("Ã„")) text = text.Replace("Ã„", "A");
			if (text.Contains("Ä™")) text = text.Replace("Ä™", "e");
			if (text.Contains("Å»")) text = text.Replace("Å»", "Z");
			if (text.Contains("â€™")) text = text.Replace("â€™","'");
			if (text.Contains("Ã¡")) text = text.Replace("Ã¡", "a");
			if (text.Contains("Ã±")) text = text.Replace("Ã±a", "nas");
			if (text.Contains("ï")) text = text.Replace("ï", "i");
			if (text.Contains("A¯")) text = text.Replace("A¯", "i");
			if (text.Contains("A®")) text = text.Replace("A®","i");
			if (text.Contains("Ã")) text = text.Replace("Ã", "a");
			if (text.Contains("Å‘")) text = text.Replace("Å‘", "o");
			if (text.Contains("a‰")) text = text.Replace("a‰", "E");
			if (text.Contains("aŽ")) text = text.Replace("aŽ", "I");
			if (text.Contains("Helicoptere")) text = text.Replace("Helicoptere", "Helicopter");
			if (text.Contains("a½")) text = text.Replace("a½", "y");
			if (text.Contains("Ä\u0081")) text = text.Replace("Ä\u0081", "a");
			if (text.Contains("Ä«")) text = text.Replace("Ä«", "i");
			if (text.Contains("á¸¨")) text = text.Replace("á¸¨", "H");
			if (text.Contains("Ã¶")) text = text.Replace("Ã¶","a");
			if (text.Contains("a\u0090áº¯")) text = text.Replace("a\u0090áº¯","Da");
			if (text.Contains("ÅŸ")) text = text.Replace("ÅŸ", "s");
			if (text.Contains("Å£")) text = text.Replace("Å£", "t");
			if (text.Contains("á")) text = text.Replace("á", "a");
			if (text.Contains("¸©")) text = text.Replace("¸©", "h");
			if (text.Contains("AŽ")) text = text.Replace("AŽ", "Is");
			if (text.Contains("ka½")) text = text.Replace("ka½", "e");
			if (text.Contains("aª")) text = text.Replace("aª", "e");
			if (text.Contains("a¯")) text = text.Replace("a¯", "i");
			if (text.Contains("a\u0081")) text = text.Replace("a\u0081", "A");
			if (text.Contains("a§")) text = text.Replace("a§", "c");
			if (text.Contains("a‚n")) text = text.Replace("a‚n", "An");
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
			if (text.Contains("Ã")) text = text.Replace("Ã", "A");
			if (text.Contains("Å")) text = text.Replace("Å", "A");
			if (text.Contains("ž")) text = text.Replace("ž", "z");
			if (text.Contains("Ä")) text = text.Replace("Ä", "A");
			if (text.Contains("±")) text = text.Replace("±", "t");
			if (text.Contains("a‘")) text = text.Replace("a‘", "A");
			int[] nonPrinting = { 173, 160, 144, 141, 129 };
			foreach (int i in nonPrinting)
			{
				char np = (char)i;
				if (text.Contains(np.ToString())) text = text.Replace(np.ToString(), "");
			}
			if (text.Contains("¢")) text = text.Replace("¢", "");
			if (text.Contains("a˜")) text = text.Replace("a˜", "Au");
			if (text.Contains("aµ")) text = text.Replace("aµ", "i");
			if (text.Contains("a‡")) text = text.Replace("a‡", "C");
			if (text.Contains("AŸ")) text = text.Replace("AŸ", "g");
			if (text.Contains(" 1Â° ")) text = text.Replace(" 1Â° ", " ");
			if (text.Contains("Â´")) text = text.Replace("Â´", "'");
			if (text.Contains("a¬")) text = text.Replace("a¬", "i");
			if (text.Contains("A\u008f")) text = text.Replace("A\u008f", "o");
			if (text.Contains("a¹")) text = text.Replace("a¹", "u");
			if (text.Contains("a“")) text = text.Replace("a“", "O");
			if (text.Contains("A‰")) text = text.Replace("A‰", "E");
			if (text.Contains("Aª")) text = text.Replace("Aª", "e");
			if (text.Contains("A§")) text = text.Replace("A§", "c");
			if (text.Contains("A¹")) text = text.Replace("A¹", "u");
			if (text.Contains("`")) text = text.Replace("`", "'");
			if (text.Contains("Ì§")) text = text.Replace("Ì§", "i");
			if (text.Contains("A¬")) text = text.Replace("A¬", "i");
			if (text.Contains("ÂD")) text = text.Replace("ÂD", " D");
			if (text.Contains("A†")) text = text.Replace("A†", "n");
			if (text.Contains("A“")) text = text.Replace("A“", "e");
			if (text.Contains("AŒ")) text = text.Replace("AŒ", "I");
			if (text.Contains("a†")) text = text.Replace("a†", "E");
			if (text.Contains("Âº")) text = text.Replace("Âº","o");
			if (text.Contains("Ê¼")) text = text.Replace("Ê¼", "'");
			if (text.Contains("A³")) text = text.Replace("A³", "u");
			if (text.Contains("A˜")) text = text.Replace("A˜", "O");
			if (text.Contains("a«")) text = text.Replace("a«", "e");
			if (text.Contains("A«")) text = text.Replace("A«", "e");
			if (text.Contains("A‘")) text = text.Replace("A‘", "a");
			if (text.Contains("a®")) text = text.Replace("a®", "i");
			if (text.Contains("A‡")) text = text.Replace("A‡", "c");
			if (text.Contains("Aƒ")) text = text.Replace("Aƒ", "af");
			if (text.Contains("È›")) text = text.Replace("È›", "t");
			if (text.Contains("A½")) text = text.Replace("A½", "y");
			if (text.Contains("A°")) text = text.Replace("A°", "I");
			if (text.Contains("Aš")) text = text.Replace("Aš", "U");
			if (text.Contains("aœ")) text = text.Replace("aœ", "U");
			if (text.Contains("š")) text = text.Replace("š", "s");
			if (text.Contains("Aº")) text = text.Replace("Aº", "z");
			if (text.Contains("A¼")) text = text.Replace("A¼", "z");
			if (text.Contains("A›")) text = text.Replace("A›", "s");
			if (text.Contains("a”")) text = text.Replace("a”", "A");
			if (text.Contains("Ç\u009d")) text = text.Replace("Ç\u009d", "a");
			if (text.Contains("È™")) text = text.Replace("È™", "s");
			if (text.Contains("aº¯")) text = text.Replace("aº¯", "a");
			if (text.Contains("aº")) text = text.Replace("aº", "a");
			if (text.Contains("Aa»‹")) text = text.Replace("Aa»‹", "A");
			return text;
		}
	}
}
