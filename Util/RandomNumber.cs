using System;

namespace Util
{
	public class RandomNumber
	{
		private static Random randomNumberGenerator;
		private static readonly Lazy<RandomNumber> instance
			= new Lazy<RandomNumber>(() => new RandomNumber());
		private RandomNumber() { randomNumberGenerator = new Random(); }
		public static RandomNumber Instance
		{
			get { return instance.Value; }
		}
		public int Next(int inclusiveLow, int inclusiveHigh)
		{
			int lo = inclusiveLow;
			int hi = inclusiveHigh;
			if (lo > hi)
			{
				lo = inclusiveHigh;
				hi = inclusiveLow;
			}
			return randomNumberGenerator.Next(lo, hi+1);
		}
	}
}
