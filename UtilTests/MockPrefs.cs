using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace UtilTests
{
	[Serializable]
	public class MockPrefs : IPreferenceData
	{
		public string TestString { get; set; } = "Mock test string";
		public int TestInt { get; set; } = 0;
		public DateTime TestDateTime { get; set; } = new DateTime(0);
	}
}
