using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Custom_Equatable_Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 V2SJ = new Vector2();
            Vector2 V2A = new Vector2();

            System.Console.WriteLine("Is V2A equal to V2SJ? {0}", V2A.Equals(V2SJ));
            Console.ReadLine();
        }
    }
}