using System.Drawing;

namespace Util
{
	public static class WinFormsExtensions
	{
		public static Color Average(this Color color1, Color color2)
		{
			int r = (color1.R + color2.R) / 2;
			int g = (color1.G + color2.G) / 2;
			int b = (color1.B + color2.B) / 2;
			return Color.FromArgb(r, g, b);
		}
	}
}
