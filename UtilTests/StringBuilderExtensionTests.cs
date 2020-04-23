using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace UtilTests
{
	[TestClass]
	public class StringBuilderExtensionTests
	{
		[TestMethod]
		public void ContainsTest()
		{
			StringBuilder builder = new StringBuilder("Now is the time for all good men to come to the aid of the party.");
			Assert.IsTrue(builder.Contains("Now is the"));
			Assert.IsTrue(builder.Contains("for all good men"));
			Assert.IsTrue(builder.Contains("aid of the party."));
			Assert.IsFalse(builder.Contains("Hello"));
		}
	}
}
