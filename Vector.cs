namespace AdvMath
{
    public struct Vector
    {
        public double X { get; set; } // Properties for vector components
        public double Y { get; set; } // Properties for vector components

        public Vector() // Default constructor initializes vector to (0, 0)
        {
            X = 0;
            Y = 0;
        }

        public Vector(double x) // Constructor to initialize only the X component, Y defaults to 0
        {
            X = x;
            Y = 0;
        }

        public Vector(double x, double y) // Constructor to initialize vector components
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y); // Vector addition
        public static Vector operator ++( Vector v) => new Vector(v.X + 1, v.Y + 1); // Increment both components of the vector by 1
        public static Vector operator -(Vector v) => new Vector(-v.X, -v.Y); // Negate both components of the vector
        public static Vector operator --(Vector v) => new Vector(v.X - 1, v.Y - 1); // Decrement both components of the vector by 1
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y); // Vector subtraction
        public static Vector operator *(Vector v, double scalar) => new Vector(v.X * scalar, v.Y * scalar); // Scalar multiplication
        public static Vector operator *(double scalar, Vector v) => v * scalar; // Scalar multiplication (commutative)
        public static Vector operator /(Vector v, double scalar) => new Vector(v.X / scalar, v.Y / scalar); // Scalar division
        public static Vector operator /(double scalar, Vector v) => new Vector(scalar / v.X, scalar / v.Y); // Scalar division (commutative)

        public double Length() => System.Math.Sqrt(X * X + Y * Y); // Calculate the magnitude of the vector
        public Vector Normalize() => this / Length(); // Return a unit vector in the same direction

        // Calculate the angle between two vectors in radians
        public static double AngleBetween(Vector v1, Vector v2) // Note: This method returns a vector where the X component is the angle in radians and the Y component is set to 0 for simplicity
        {
            double dotProduct = v1.X * v2.X + v1.Y * v2.Y;
            double magnitudeProduct = v1.Length() * v2.Length();
            return System.Math.Acos(dotProduct / magnitudeProduct); // Return the angle in radians
        }

        public static double AngleBetweenDegrees(Vector v1, Vector v2) => AngleBetween(v1, v2) * (180.0 / System.Math.PI); // Calculate the angle between two vectors in degrees

        public static double Angle(Vector v) => System.Math.Atan2(v.Y, v.X); // Calculate the angle of a vector in radians
        
        public static double AngleDegrees(Vector v) => Angle(v) * (180.0 / System.Math.PI); // Calculate the angle of a vector in degrees

        public static Vector RotateRad(Vector v, double angleRadians) // Rotate a vector by a specified angle in radians
        {
            double cosTheta = System.Math.Cos(angleRadians);
            double sinTheta = System.Math.Sin(angleRadians);
            return new Vector(v.X * cosTheta - v.Y * sinTheta, v.X * sinTheta + v.Y * cosTheta);
        }

        public static Vector Rotate(Vector v, double angleDegrees) // Rotate a vector by a specified angle in degrees
        {
            double angleRadians = angleDegrees * (System.Math.PI / 180.0);
            double cosTheta = System.Math.Cos(angleRadians);
            double sinTheta = System.Math.Sin(angleRadians);
            return new Vector(v.X * cosTheta - v.Y * sinTheta, v.X * sinTheta + v.Y * cosTheta);
        }

        public static double Distance(Vector v1, Vector v2) => (v1 - v2).Length(); // Calculate the distance between two vectors

        public static double CrossProduct(Vector v1, Vector v2) => v1.X * v2.Y - v1.Y * v2.X; // Calculate the cross product of two vectors

        public static double DotProduct(Vector v1, Vector v2) => v1.X * v2.X + v1.Y * v2.Y; // Calculate the dot product of two vectors

        public override string ToString() => $"({X:F4}, {Y:F4})"; // Return a string representation of the vector
    }
}