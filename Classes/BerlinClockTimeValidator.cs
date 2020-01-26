using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BerlinClock
{
    class BerlinClockTimeValidator : ITimeValidator
    {
        public bool Validate(string time)
        {
             
            if (time.Equals("24:00:00"))
                return true;

            DateTime dummy;
            return DateTime.TryParseExact(time, "HH:mm:ss",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None,
                                          out dummy);

        }
    }
}
