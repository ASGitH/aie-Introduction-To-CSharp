using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Text Entry
            Console.SetWindowSize(100, 50);
            bool IsScreenClosed = false;
            while (!IsScreenClosed)
            {
                Console.WriteLine("Type something in chat...");
                string ChatString = Console.ReadLine();
                // Chat Filter
                ChatFilter(ChatString);
                Console.SetCursorPosition(75, Console.CursorTop);
                Console.WriteLine(ChatString);
            }
        }
        // Chat Filter
        static void ChatFilter(string _string)
        {
            var DemonetizedWords = new List<string> { "ass", "asshole", "bastard", "bitch", "crap", "damn", "fuck", "goddamn", "hell", "holy shit", "motherfucker", "shit", "son of a bitch" };

            for (int i = 0; i < 13; i++)
            {
                if (_string == DemonetizedWords[i])
                {
                    Console.WriteLine("Hey, thats a naughty word -_-");
                }
                else
                {
                    Console.WriteLine("( =");
                }
            }
        }
    }
}
