using System;
using System.Collections.Generic;
using System.Text;

namespace Transversal.Common.Extensions
{
    public static partial class DateTimeExtensions
    {
        public static string GetSirosDateString(this DateTime? dt)
        {
            if (!dt.HasValue)
                return null;

            return dt.Value.ToString("yyyyMMdd");
        }

        public static string GetSirosDateString(this DateTime dt)
        {
            return dt.ToString("yyyyMMdd");
        }
    }
}
