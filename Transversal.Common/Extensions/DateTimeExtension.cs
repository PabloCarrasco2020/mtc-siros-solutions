using System;
using System.Collections.Generic;
using System.Text;

namespace Transversal.Common.Extensions
{
    public static partial class DateTimeExtensions
    {
        public static string GetSirosDate(this DateTime? dt)
        {
            if (!dt.HasValue)
                return null;

            return dt.Value.ToString("YYYYMMDD");
        }

        public static string GetSirosDate(this DateTime dt)
        {
            return dt.ToString("YYYYMMDD");
        }
    }
}
