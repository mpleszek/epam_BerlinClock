using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public class ErrorLogger : ILogger
    {
        public void LogException(Exception e)
        {
            //log exception 
            throw new NotImplementedException();
        }
    }
}
