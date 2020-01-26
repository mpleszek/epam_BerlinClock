using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public interface IBerlinClockStrategy
    {
        int HoursDivider { get; }
        int MinutesDivider { get; }
        int SecondsDivider { get; }
        char LightOff { get; }
        String HoursTopPattern { get; }
        String HoursBottomPattern { get; }
        String MinutesTopPattern { get; }
        String MinutesBottomPattern { get; }
        String SecondsPattern { get; }
        ILogger Logger { get; }
        ITimeValidator Validator { get ;}
    }
}
