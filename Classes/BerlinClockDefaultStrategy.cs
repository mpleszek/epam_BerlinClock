using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public class BerlinClockDefaultStrategy : IBerlinClockStrategy
    {

        private static int hoursDivider = 5;
        private static int minutesDivider = 5;
        private static int secondsDivider = 2;

        private static char lightOff = 'O';

        private static String hourTopPattern = "RRRR";
        private static String hourBottomPattern = "RRRR";
        private static String minutesTopPattern = "YYRYYRYYRYY";
        private static String minutesBottomPattern = "YYYY";
        private static String secondsPattern = "Y";

        public int HoursDivider { get => hoursDivider; }
        public int MinutesDivider { get => minutesDivider;  }
        public int SecondsDivider { get => secondsDivider; }
        public string HoursTopPattern { get => hourTopPattern;  }
        public string HoursBottomPattern { get => hourBottomPattern; }
        public string MinutesTopPattern { get => minutesTopPattern;  }
        public string MinutesBottomPattern { get => minutesBottomPattern;  }
        public string SecondsPattern { get => secondsPattern; }
        public char LightOff { get => lightOff;  }

        public ILogger Logger { get => new ErrorLogger(); }

        public ITimeValidator Validator { get => new BerlinClockTimeValidator(); }
    }
}
