using System;
using System.Globalization;

namespace DealSe.Utils.Common
{
    public class DateTimeUtilities
    {
        public static DateTime? TryParseStringToDate(string d1)
        {
            DateTime objDateTime;
            string[] formats = { "dd-MM-yyyy","dd/MM/yyyy", "MM/dd/yyyy", "d/M/yyyy", "M/d/yyyy","yyyy-MM-dd" };
            if (DateTime.TryParseExact(d1, formats, new CultureInfo("en-AU"), DateTimeStyles.None, out objDateTime))
            {
                return objDateTime;
            }
            else
            {
                return null;
            }
        }
    }
}
