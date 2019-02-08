using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // This first section cache's the various strings we'll be using
            // this helps demonstrate that the classes & methods can all
            // be entirely data driven.
            string workingDir = System.IO.Directory.GetCurrentDirectory();
            string dllFileName = "/ExternalLib.dll";
            string extClass = "ExternalLib.MyExternalClass";
            string extMethod = "TestHelloWorld";

            // First load the external assembly
            Assembly assembly = Assembly.LoadFile(workingDir + dllFileName);

            // Get the type of the desired class (including the namespace)
            Type type = assembly.GetType(extClass);

            // Get the supporting method info so we can execute a method
            MethodInfo methodInfo = type.GetMethod(extMethod);

            // Create an instance of the desired object
            Object obj = Activator.CreateInstance(type);

            // And invoke the method
            // methodInfo.Invoke(obj, null);
            // Console.ReadLine();

            // Open Room.txt
            // string path = @"C:\Users\s189074\source\repos\Introduction-to-CSharp\Reflection\Room.txt";
            string[] path = System.IO.File.ReadAllLines(@"C:\Users\s189074\source\repos\Introduction-to-CSharp\Reflection\Room.txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of Room.txt = ");
            foreach (string line in path)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine(line);
            }
            System.Console.WriteLine(path[12]);
            System.Console.WriteLine(path.Length - 1);  // How many lines are in the txt document

            // Read Room.txt and find the number of blocks and input that into a integer
            int NumberOfBlocks = 0;

            for(int i = 0; i < path.Length; i++)
            {
                if (path[i].Contains("numberofblocks="))
                {
                    string LastFragment = path[i].Split('=').Last();
                    NumberOfBlocks = Int32.Parse(LastFragment);
                }
            }
            Console.WriteLine($"Number of blocks: " + NumberOfBlocks);
            Console.ReadLine();
            //foreach (string line in File.ReadLines(path))
            //{
            //    if (line.Contains("numberofblocks="))
            //    {
            //        string LastFragment = line.Split('=').Last();
            //        NumberOfBlocks = Int32.Parse(LastFragment);
            //    }
            //}
            //Console.WriteLine($"Number of blocks: " + NumberOfBlocks);

            //// Make an integer array and the size will be based on the number of blocks avaliable
            //int[] _NumberOfBlocks = new int[NumberOfBlocks];
            ////for (int i = 0; i < _NumberOfBlocks.Length; i++)
            ////{
            ////    // string DefaultValue = i.ToString();
            ////}
            //System.Console.WriteLine($"_Number of blocks: " + _NumberOfBlocks.Length);

            //// Read Room.txt and find the size of the room and input that into two integers
            //int Rows = 0;   // -,-,-,-,-
            //int Columns = 0;    // |,
            //                    // |,
            //                    // |,
            //                    // |,
            //                    // |

            //foreach (string line in File.ReadLines(path))
            //{
            //    if (line.Contains("roomsize="))
            //    {
            //        string LastFragment = line.Split('=').Last();
            //        // Left side of the comma
            //        string _LastFragment = LastFragment.Split(',').First();
            //        Columns = Int32.Parse(_LastFragment);
            //        // Right side of the comma
            //        string __LastFragment = LastFragment.Split(',').Last();
            //        Rows = Int32.Parse(__LastFragment);
            //    }
            //}
            //Console.WriteLine($"Room columns: " + Columns);
            //Console.WriteLine($"Room rows: " + Rows);

            //// Make an two dimensional integer array and the size will be based on the number of columns & rows avaliable
            //int[,] _ColumnsAnd_Rows = new int[Columns, Rows];
            //System.Console.WriteLine($"_Room columns: " + _ColumnsAnd_Rows.GetLength(0));
            //System.Console.WriteLine($"_Room rows: " + _ColumnsAnd_Rows.GetLength(1));

            //Wall wall = new Wall();
            //wall._Wall(_NumberOfBlocks, path);

            //Door door = new Door();
            //door._Door(_NumberOfBlocks, path);

            //Walkable walkable = new Walkable();
            //walkable._Walkable(_NumberOfBlocks, path);

            //// Make a double for loop and starting off with the first value, convert it to int and then aplly it to _ColumnsAnd_Rows
            //Console.WriteLine(path.ElementAt(5));

            //Console.ReadLine();
        }
    }

    // Number of blocks = 4
    // In the example, the number of blocks that there are 4, thats not the size of it but if wall = 0, then
    // numberOfBlocks[0] = wall.

    // In the array, if 0, then display wall.
    class Wall
    {
        public string Name = "Wall";
        private int Value = 0;

        public void _Wall(int[] _NOB, string Path)
        {
            string _Path = Path;

            foreach (string line in File.ReadLines(_Path))
            {
                if (line.Contains("wall="))
                {
                    string LastFragment = line.Split('=').Last();
                    Value = Int32.Parse(LastFragment);
                }
            }
            _NOB[0] = Value;
        }
    }
    class Door
    {
        public string Name = "Door";
        private int Value = 0;
        public void _Door(int[] _NOB, string Path)
        {
            string _Path = Path;

            foreach (string line in File.ReadLines(_Path))
            {
                if (line.Contains("door="))
                {
                    string LastFragment = line.Split('=').Last();
                    Value = Int32.Parse(LastFragment);
                }
            }
            _NOB[1] = Value;
        }
    }
    class Walkable
    {
        public string Name = "Walkable";
        private int Value = 0;
        public void _Walkable(int[] _NOB, string Path)
        {
            string _Path = Path;

            foreach (string line in File.ReadLines(_Path))
            {
                if (line.Contains("walkable="))
                {
                    string LastFragment = line.Split('=').Last();
                    Value = Int32.Parse(LastFragment);
                }
            }
            _NOB[2] = Value;
        }
    }
}
