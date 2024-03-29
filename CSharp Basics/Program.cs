﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Text Entry
            Console.SetWindowSize(75, 25);
            bool IsScreenClosed = false;
            while (!IsScreenClosed)
            {
                Console.WriteLine("Type something in chat...");
                string ChatString = Console.ReadLine();
                Console.SetCursorPosition(50, Console.CursorTop);
                // Chat Filter
                ChatFilter(ChatString);
                // Chat commands: For example, the user types ! or /addCURSEWORD ______
                // this adds the word to the filter so when you type it, the filter blurs it out.
                // In order to use a command, the user will type command.(This is where the user will choose between different commands).
                // Ex: Chat.ChatFilter.AddSwearWord("_____");
            }
        }
        // Chat Filter
        static void ChatFilter(string _string)
        {
            string[] DemonetizedWords = { "ass", "asshole", "bastard", "bitch", "crap", "damn", "fuck", "goddamn", "hell", "holy shit", "motherfucker", "shit", "son of a bitch" };

            // Take _string, and make the whole _string undercase
            string LowerCaseString;
            LowerCaseString = _string.ToLower();

            for (int j = 0; j < DemonetizedWords.Length; j++)
            {
                int CensoredCharacterlength =  DemonetizedWords[j].Length;
                string CensoredCharacter = new string('*', CensoredCharacterlength);
                LowerCaseString = Regex.Replace(LowerCaseString, DemonetizedWords.ElementAt(j), CensoredCharacter);
            }
            Console.WriteLine(LowerCaseString);
        }
    }
}
