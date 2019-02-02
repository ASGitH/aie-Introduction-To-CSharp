using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square();
            square.Name = "Mr Square";
            square.Log();

            Potato potato = new Potato();
            potato.Message = "I'm a potato.";
            potato.Log(potato.Message, 10);

            System.Console.ReadLine();
        }
    }

    public class Potato : ILogger
    {
        string message;

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public void Log(string Message, int severity)
        {
            System.Console.WriteLine(Message, severity);
        }
    }

    // Reference (ILoggable)
    public class Square : ILoggable
    {
        string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public void Log()
        {
            System.Console.WriteLine("My name is " + name + " and I am a square!");
        }
    }
}
