using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Transversal.Common.Extensions
{
    public static partial class StringExtensions
    {
        public static string ToBDSirosDate(this string sDate)
        {
            if (string.IsNullOrEmpty(sDate))
                return null;
            var tp2 = sDate.Replace("-", "");
            return tp2;
        }
        public static string ToAppSirosDate(this string sDate)
        {
            if (string.IsNullOrEmpty(sDate))
                return null;

            return DateTime.ParseExact(sDate, "dd/MM/yyyy", new CultureInfo("en-US")).ToString("yyyy-MM-dd");
        }
    }
}
