using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
              // ---------------------------- //
             // -----***** Player *****----- //
            // ---------------------------- //
            // ***-- Initialize Players here --***
            Player One = new Player { Health = 100.0f };
            Player Two = new Player { Health = 100.0f };
            Player Three = new Player { Health = 100.0f };
            Player Four = new Player { Health = 100.0f };
            // ***-----------------------------***

            // ***-- Set Player's Names here --***
            One.PlayerName = "Alexis";
            Two.PlayerName = "Rey";
            Three.PlayerName = "Saul";
            Four.PlayerName = "Stefanie Joosten";
            // ***-----------------------------***

            // ***-- Set Player's Frag Count here --***
            One.Frags = 10;
            Two.Frags = 28;
            Three.Frags = 18;
            Four.Frags = 45;
            // ***----------------------------------***

            // ***-- Set Player's Death Count here --***
            One.Deaths = 3;
            Two.Deaths = 15;
            Three.Deaths = 5;
            Four.Deaths = 0;
            // ***-----------------------------------***

            // ***-- Set Player's Total Damage here --***
            One.TotalDamage(22.0f);
            Two.TotalDamage(25.0f);
            Three.TotalDamage(50.0f);
            Four.TotalDamage(0.0f);
            // ***------------------------------------***

            // Here, display the name, frag count, death count, total damage, and score all together
            One.OverallStatistics();
            Two.OverallStatistics();
            Three.OverallStatistics();
            Four.OverallStatistics();

              // ------------------------------------------ //
             // -----***** Vector3 (rudimentary) *****---- //
            // ------------------------------------------ //
            Vector3 V3One = new Vector3
            {
                x = 3.0f,
                y = 5.0f,
                z = 8.0f
            };
            Vector3 V3Two = new Vector3
            {
                x = 2.0f,
                y = 7.0f,
                z = 1.0f
            };
            // Return the sum of two vectors
            System.Console.WriteLine("// Return the sum of two vectors");
            Vector3 V3Three = V3One + V3Two;
            
            // Return the difference between two vectors
            System.Console.WriteLine("\n// Return the difference between two vectors");
            Vector3 V3Four = V3One - V3Two;
            
            // Return the magnitude of a vector
            System.Console.WriteLine("\n// Return the magnitude of a vector");
            System.Console.WriteLine($"Magnitude: {V3Three.Magnitude()}");
            
            // Return the normalized form of a vector
            System.Console.WriteLine("\n// Return the normalized form of a vector"); 
            V3One.Normalize();

            // Return the dot product of two vectors
            System.Console.WriteLine("\n// Return the dot product of two vectors");
            Vector3 V3Five = new Vector3
            {
                x = 3.0f,
                y = 5.0f,
                z = 8.0f
            };
            Vector3 V3Six = new Vector3
            {
                x = 2.0f,
                y = 7.0f,
                z = 1.0f
            };
            System.Console.WriteLine($"Dot Product: {V3Five.DotProduct(V3Six)}");

              // -------------------------------------- //
             // -----***** Finite Game State *****---- //
            // -------------------------------------- //
            //System.Console.WriteLine("");
            System.Console.ReadLine();
        }   
    }
}
