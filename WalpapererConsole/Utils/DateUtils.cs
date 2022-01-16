using System;

namespace Wallpepper.Utils
{
    public class DateUtils
    {
        public static string Today()
        {
            var now = DateTime.Today.Date;

            var monthSuffix = now.Month < 10 ? "0" : string.Empty;
            var daySuffix = now.Day < 10 ? "0" : string.Empty;
            
            return $"{now.Year}-{monthSuffix}{now.Month}-{daySuffix}{now.Day}";
        }
    }
}