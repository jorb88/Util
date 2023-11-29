using System;
using System.IO;

namespace Util
{
	public class Logger
	{
		public static string LogFile { get; set; } = UserInfo.HomePath + @"\Documents\Log.log";
		public static void Log(params object[] objs)
		{
			string rep = string.Empty;
			foreach (object obj in objs)
			{
				if (obj == null) return;
				rep += obj.ToString() + " ";
			}
			rep = rep.TrimEnd();

			using (StreamWriter log = new StreamWriter(LogFile, true))
			{
				log.WriteLine(DateTime.Now.ToModernDateString() + " " +
					DateTime.Now.To24HourTime() + " " + rep);
			}
		}
		public static void ClearLogFile()
		{
			if (!File.Exists(LogFile)) return;
			File.Delete(LogFile);
		}
	}
}
