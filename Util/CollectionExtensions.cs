using System.Collections.Generic;

namespace Util
{
	public static class CollectionExtensions
	{
		public static void RemoveLast(this List<string> list)
		{
			int end = list.Count - 1;
			if (end < 0) return;
			list.RemoveAt(end);
		}
	}
}
