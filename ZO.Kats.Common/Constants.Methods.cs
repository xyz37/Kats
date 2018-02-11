using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Common
{
	partial class Constants
	{
				/// <summary>
		/// Gets the interface date.
		/// </summary>
		/// <param name="dateTime">The date time.</param>
		/// <returns></returns>
		public static string GetInterfaceDate(this DateTime dateTime)
		{
			return dateTime.ToString(INTERFACE_DATE_FORMAT);
		}

		/// <summary>
		/// Gets the specified interface date time.
		/// </summary>
		/// <param name="interfaceDateTime">The interface date time.</param>
		/// <returns></returns>
		public static DateTime ParseInterfaceDate(this string interfaceDateTime)
		{
			return DateTime.ParseExact(interfaceDateTime, INTERFACE_DATE_FORMAT, null);
		}

		/// <summary>
		/// Parses the interface date string.
		/// </summary>
		/// <param name="interfaceDateTime">The interface date time.</param>
		/// <param name="formatString">The format string.</param>
		/// <returns></returns>
		public static string ParseInterfaceDateString(this string interfaceDateTime, string formatString = "yyyy-MM-dd")
		{
			return DateTime.ParseExact(interfaceDateTime, INTERFACE_DATE_FORMAT, null).ToString(formatString);
		}
	}
}
