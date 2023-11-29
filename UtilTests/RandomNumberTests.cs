using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace UtilTests
{
	[TestClass]
	public class RandomNumberTests
	{
		[TestMethod]
		public void RandomNext0BaseTest()
		{
			int lo = 0;
			int hi = 12;
			int n = RandomNumber.Instance.Next(lo,hi);
			Assert.IsTrue(Between(n,lo, hi));
		}
		[TestMethod]
		public void RandomNextNon0BaseTest()
		{
			int lo = 17;
			int hi = 55;
			int n = RandomNumber.Instance.Next(lo, hi);
			Assert.IsTrue(Between(n, lo, hi));
		}
		[TestMethod]
		public void RandomNextReverseOrderTest()
		{
			int lo = 5;
			int hi = 55;
			int n = RandomNumber.Instance.Next(hi, lo);
			Assert.IsTrue(Between(n, lo, hi));
		}
		[TestMethod]
		public void RandomNextNegativeTest()
		{
			int lo = -5;
			int hi = 0;
			int n = RandomNumber.Instance.Next(hi, lo);
			Assert.IsTrue(Between(n, lo, hi));
		}
		private bool Between(int n, int lo, int hi)
		{
			if (n < lo) return false;
			if (n > hi) return false;
			return true;
		}
	}
}
