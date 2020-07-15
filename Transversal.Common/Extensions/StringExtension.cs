using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Transversal.Common.Extensions
{
    public static partial class StringExtensions
    {
        public static DateTime? GetSirosDateTime(this string sDate)
        {
            if (string.IsNullOrEmpty(sDate))
                return null;

            return DateTime.ParseExact(sDate, "dd/MM/yyyy", new CultureInfo("en-US"));
        }
    }
}
