namespace AdvMath
{
    public struct Vector
    {
        public double X { get; }
        public double Y { get; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
        public static Vector operator *(Vector v, double scalar) => new Vector(v.X * scalar, v.Y * scalar);
        public static Vector operator /(Vector v, double scalar) => new Vector(v.X / scalar, v.Y / scalar);

        public double Length() => System.Math.Sqrt(X * X + Y * Y);
        public Vector Normalize() => this / Length();
    }
}