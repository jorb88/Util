namespace Util
{
	public static class MathExtentions
	{
		public static int Floor(this double d)
		{
			if (d >= 0.0) return (int)d;
			d = d - .5;
			return (int)d;
		}
		public static bool Between(this double number, double minimum, double maximum)
		{
			if (number <= minimum) return false;
			if (number >= maximum) return false;
			return true;
		}
	}
}
