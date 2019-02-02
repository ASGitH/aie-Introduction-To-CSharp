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

        // Return the sum of two vectors
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

        // Return the difference between two vectors
        public static Vector3 operator -(Vector3 LHS, Vector3 RHS)
        {
            Vector3 Difference = new Vector3
            {
                x = LHS.x - RHS.x,
                y = LHS.y - RHS.y,
                z = LHS.z - LHS.z
            };
            System.Console.WriteLine($"x: {Difference.x}, y: {Difference.y}, z: {Difference.z}");
            return Difference;
        }

        // Return the magnitude of a vector
        public float Magnitude()
        {
            // a^2
            float xSqr = x * x;
            // b^2
            float ySqr = y * y;
            // c^2
            float zSqr = z * z;
            // d^2
            float cSqr = xSqr + ySqr + zSqr;
            // Square root of c
            return (float)Math.Sqrt(cSqr);
        }

        // Return the normalized form of a vector
        public Vector3 Normalize()
        {
            float NormalizeMagnitude = Magnitude();
            x /= NormalizeMagnitude;
            y /= NormalizeMagnitude;
            z /= NormalizeMagnitude;
            System.Console.WriteLine($"Normalized Vector - x:{x}, y:{y}, z:{z}");
            return this;
        }

        // Return the dot product of two vectors
        public float DotProduct (Vector3 RHS)
        {
            Vector3 DotProductVector3 = new Vector3
            {
                x = this.x * RHS.x,
                y = this.y * RHS.y,
                z = this.z * RHS.z
        };
            float DotProductXYZ = DotProductVector3.x + DotProductVector3.y + DotProductVector3.z;
            return DotProductXYZ;
        }
    }
}
