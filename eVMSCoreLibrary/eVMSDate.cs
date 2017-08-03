using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class eVMSDate
    {
        public static DateTime DateNow()
        {
            TimeZone dateLocal = TimeZone.CurrentTimeZone;
            DateTime dateUTC = dateLocal.ToUniversalTime(DateTime.Now);
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime zoneDate = TimeZoneInfo.ConvertTimeFromUtc(dateUTC, timeZone);

            return zoneDate;
        }
    }
}
