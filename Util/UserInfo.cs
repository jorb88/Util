using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
	public static class UserInfo
	{
		public static string HomePath
		{
			get
			{
				var pf = Environment.OSVersion.Platform;
				if ((pf == PlatformID.Unix) || (pf == PlatformID.MacOSX))
					return Environment.GetEnvironmentVariable("HOME");
				return Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
			}
		}
	}
}
