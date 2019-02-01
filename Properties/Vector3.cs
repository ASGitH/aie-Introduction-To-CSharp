using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public static Vector3 One()
        {
            Vector3 Vec = new Vector3();
            Vec.x = Vec.y = Vec.z = 1.0f;
            return Vec;
        }

        public static Vector3 operator +(Vector3 LHS, Vector3 RHS)
        {
            Vector3 Sum = new Vector3
            {
                x = LHS.x + RHS.x,
                y = LHS.y + RHS.y,
                z = LHS.z + RHS.z
            };
            System.Console.WriteLine($"x: {Sum.x}, y: {Sum.y}, z: {Sum.z}");
            return Sum;
        }

        public static Vector3 operator -(Vector3 LHS, Vector3 RHS)
        {
            Vector3 Difference = new Vector3 {
                x = LHS.x - RHS.x;
                y = LHS.y - RHS.y;
                z = LHS.z - LHS.z;
            };
        }
    }
}
