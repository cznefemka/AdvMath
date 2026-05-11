using System; 
namespace AdvMath
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator ++( Vector v) => new Vector(v.X + 1, v.Y + 1);
        public static Vector operator -(Vector v) => new Vector(-v.X, -v.Y);
        public static Vector operator --(Vector v) => new Vector(v.X - 1, v.Y - 1);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
        public static Vector operator *(Vector v, Vector w) => new Vector(v.X * w.X - v.Y * w.Y, v.X * w.Y + v.Y * w.X);
        public static Vector operator *(Vector v, double scalar) => new Vector(v.X * scalar, v.Y * scalar);
        public static Vector operator *(double scalar, Vector v) => v * scalar;
        public static Vector operator /(Vector v, Vector w)
        {
            double denominator = w.X * w.X + w.Y * w.Y;
            return new Vector((v.X * w.X + v.Y * w.Y) / denominator, (v.Y * w.X - v.X * w.Y) / denominator);
        }
        public static Vector operator /(Vector v, double scalar) => new Vector(v.X / scalar, v.Y / scalar);
        public static Vector operator /(double scalar, Vector v) => new Vector(scalar / v.X, scalar / v.Y);

        public double Length() => System.Math.Sqrt(X * X + Y * Y);
        public Vector Normalize() => this / Length();
        interface IEqualityComparer<T>
        {
            bool Equals(T x, T y);
            int GetHashCode(T obj);
        }
    }
}