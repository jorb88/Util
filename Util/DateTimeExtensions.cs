using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
	public static class DateTimeExtensions
	{
		public static string ToModernDateString(this DateTime date)
		{
			string year = date.Year.ToString();
			string month = date.Month.ToString();
			if (month.Length < 2) month = "0" + month;
			string day = date.Day.ToString();
			if (day.Length < 2) day = "0" + day;
			return string.Format("{0}/{1}/{2}", year, month, day);
		}
	}
}
