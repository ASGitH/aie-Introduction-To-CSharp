using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Custom_Equatable_Structs
{
    struct Vector2
    {
        public float x;
        public float y;

        public static Vector2 One()
        {
            Vector2 Vec = new Vector2();
            Vec.x = Vec.y = 1.0f;
            return Vec;
        }

        // Return the sum of two vectors
        public static Vector2 operator +(Vector2 LHS, Vector2 RHS)
        {
            Vector2 Sum = new Vector2
            {
                x = LHS.x + RHS.x,
                y = LHS.y + RHS.y,
            };
            System.Console.WriteLine($"x: {Sum.x}, y: {Sum.y}");
            return Sum;
        }

        // Return the difference between two vectors
        public static Vector2 operator -(Vector2 LHS, Vector2 RHS)
        {
            Vector2 Difference = new Vector2
            {
                x = LHS.x - RHS.x,
                y = LHS.y - RHS.y,
            };
            System.Console.WriteLine($"x: {Difference.x}, y: {Difference.y}");
            return Difference;
        }
    }
}
