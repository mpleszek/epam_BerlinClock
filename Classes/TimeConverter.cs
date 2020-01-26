using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IBerlinClockStrategy _strategy;

        //private static int hourMultiplier = 5;
        //private static int minutesMultiplier = 5;
        //private static int secondsMultiplier = 2;

        //private static char LightOff = 'O';

        //private static String hourTopPattern = "RRRR";
        //private static String hourBottomPattern = "RRRR";
        //private static String minutesTopPattern = "YYRYYRYYRYY";
        //private static String minutesBottomPattern = "YYYY";
        //private static String secondsPattern = "Y";

        public TimeConverter (IBerlinClockStrategy strategy )
        {
            _strategy = strategy;
        }


        public string convertTime(string aTime)
        {
            if (!_strategy.Validator.Validate(aTime))
                throw new ArgumentException("Wrong format! HH:MM:SS time format expected with 24:00:00 value allowed");

            
            StringBuilder berlinClock = new StringBuilder();

            String[] timeElements = aTime.Split(':');

            try
            {
                berlinClock.Append(ConvertSeconds(int.Parse(timeElements[2])));
                berlinClock.Append(ConvertHours(int.Parse(timeElements[0])));
                berlinClock.Append(ConvertMinutes(int.Parse(timeElements[1])));
            }
            catch (Exception e)
            {
                _strategy.Logger.LogException(e);
                throw; 
            }

            return berlinClock.ToString();
            
        }

        private String ConvertSeconds(int seconds)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.Append(CreateRow(_strategy.SecondsPattern, 1 - (seconds % _strategy.SecondsDivider), true));
            return retVal.ToString();
        }

        private String ConvertMinutes(int minutes)
        {
            StringBuilder retVal = new StringBuilder();

            retVal.Append(CreateRow(_strategy.MinutesTopPattern, minutes / _strategy.MinutesDivider, true));
            retVal.Append(CreateRow(_strategy.MinutesBottomPattern, minutes % _strategy.MinutesDivider, false));

            return retVal.ToString();
        }

        private String ConvertHours(int hours)
        {
            StringBuilder retVal = new StringBuilder();

            retVal.Append(CreateRow(_strategy.HoursTopPattern, hours / _strategy.HoursDivider, true));
            retVal.Append(CreateRow(_strategy.HoursBottomPattern, hours % _strategy.HoursDivider, true));

            return retVal.ToString();
        }

        private String CreateRow(String pattern, int count, bool newline)
        {
            var aStringBuilder = new StringBuilder(pattern);
            aStringBuilder.Remove(count, pattern.Length - count);
            aStringBuilder.Append(_strategy.LightOff, pattern.Length - count);
            if (newline)
                aStringBuilder.Append("\r\n");
            return aStringBuilder.ToString();
        }
    }

}
