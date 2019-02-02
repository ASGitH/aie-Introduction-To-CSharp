using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILogger
    {
        void Log(string message, int severity);
            // This method prints a string to the log.
            // The severity indicates how serioud the log message is

        string Message
        {
            get;
            set;
        }
    }

    // Reference: ILoggable
    public interface ILoggable
    {
        void Log();

        string Name
        {
            get;
            set;
        }
    }
}
