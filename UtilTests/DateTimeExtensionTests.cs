using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace UtilTests
{
	[TestClass]
	public class DateTimeExtensionTests
	{
		[TestMethod]
		public void ToModernDateStringTest()
		{
			DateTime date = new DateTime(2000, 4, 19);
			Assert.AreEqual("2000/04/19", date.ToModernDateString());
		}
	}
}
