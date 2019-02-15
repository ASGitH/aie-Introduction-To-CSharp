using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Entity StefanieJoosten = new Entity { Name = "Stefanie Joosten", CurrentHealth = 100.0f, MaxHealth = 999.99f, Gold = 999999.99f, IsRare = true };
            StefanieJoosten.displayStatistics();
            Reflection reflection = new Reflection { workingDir = System.IO.Directory.GetCurrentDirectory(), dllFileName = "/BinaryFormatterLib.dll", extClass = "BinaryFormatterLib.BinaryFormatter", extMethod = "GetTheZucc" };
            reflection._Reflection(StefanieJoosten.displayStatistics());   // In the _Reflection parameter, this would be the extMethod's other parameters.
            Console.ReadLine();
        }
    }

    class Entity
    {
        // Name
        public string Name { get; set; }
        // Health
        public float CurrentHealth { get; set; }
        public float MaxHealth { get; set; }
        // Gold
        public float Gold { get; set; }
        // Rarity
        public bool IsRare { get; set; }
        // String array that stores all the lines
        public void displayStatistics(string[] Array)
        {
            string[] Statistics = new string[] { System.Console.WriteLine("sfs"),};
            Statistics.ElementAt(0) = System.Console.WriteLine($"Name: " + Name);

            System.Console.WriteLine($"CurrentHealth: " + CurrentHealth);
            System.Console.WriteLine($"MaxHealth: " + MaxHealth);
            System.Console.WriteLine($"Gold: " + Gold);
            System.Console.WriteLine($"IsRare: " + IsRare);
        }
    }
}
