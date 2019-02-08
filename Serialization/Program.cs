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
            Reflection reflection = new Reflection { workingDir = System.IO.Directory.GetCurrentDirectory(), dllFileName = "/BinaryFormatterLib.dll", extClass = "BinaryFormatterLib.BinaryFormatter", extMethod = "GetTheZucc" };
            reflection._Reflection(null);   // In the _Reflection parameter, this would be the extMethod's other parameters.
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
    }
}
