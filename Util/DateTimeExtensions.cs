using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
	public static class DateTimeExtensions
	{
		public static string ToModernDateTimeString(this DateTime dateTime)
		{
			return ToModernDateString(dateTime) + " " + To24HourTime(dateTime);
		}
		public static string ToModernDateString(this DateTime date)
		{
			string year = date.Year.ToString();
			string month = date.Month.ToString();
			if (month.Length < 2) month = "0" + month;
			string day = date.Day.ToString();
			if (day.Length < 2) day = "0" + day;
			return string.Format("{0}/{1}/{2}", year, month, day);
		}
		public static string To24HourTime(this DateTime datetime)
		{
			string time = datetime.ToLongTimeString();
			int ix = time.IndexOf(":");
			string hr = time.Substring(0, ix + 1);
			string minsec = time.Substring(ix + 1);
			if (time.EndsWith(" AM"))
			{
				time = time.Replace(" AM", String.Empty);
				minsec = time.Substring(ix + 1);
				if (hr == "12:") return "00:" + minsec;
				if (hr.Length == 2) return "0" + hr + minsec;
				else return hr + minsec;
			}
			time = time.Replace(" PM", String.Empty);
			minsec = time.Substring(ix + 1);
			if (time.StartsWith("12:")) return time;
			string[] vals = {  "1:",  "2:",  "3:",  "4:",  "5:",  "6:",  "7:",  "8:",  "9:", "10:", "11:" };
			string[] subs = { "13:", "14:", "15:", "16:", "17:", "18:", "19:", "20:", "21:", "22:", "23:" };
			for (int i = 0; i < vals.Length; i++)
			{
				if (hr == vals[i])
				{
					hr = hr.Replace(vals[i], subs[i]);
					return hr + minsec;
				}
			}
			return "00:00:00";
		}
		public static string ToHoursAndMinutes(this double hours)
		{
			int h = (int)hours;
			var m = hours - h;
			int min = (int)(m * 60 + .5);
			string hs = h.ToString();
			if (hs.Length < 2) hs = " " + hs;
			string hm = min.ToString();
			if (hm.Length < 2) hm = "0" + hm;
			return hs + ":" + hm;
		}
	}
}
