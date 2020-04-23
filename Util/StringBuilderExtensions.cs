using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
	public static class StringBuilderExtensions
	{
		public static bool Contains(this StringBuilder builder, string pattern)
		{
			for (int i = 0; i < builder.Length - pattern.Length + 1; i++)
			{
				if (MatchAt(i, builder, pattern)) return true;
			}
			return false;
		}
		private static bool MatchAt(int i, StringBuilder builder, string pattern)
		{
			for (int j = 0; j < pattern.Length; j++)
			{
				if (builder[i+j] != pattern[j]) return false;
			}
			return true;
		}
	}
}
