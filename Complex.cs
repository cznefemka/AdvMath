using System.Linq.Expressions;
using System.Numerics;
namespace AdvMath
{
    public struct Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static Complex operator +(Complex a, double scalar) => new Complex(a.Real + scalar, a.Imaginary);
        public static Complex operator +(double scalar, Complex a) => a + scalar;
        public static Complex operator +(Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        public static Complex operator ++(Complex a) => new Complex(a.Real + 1, a.Imaginary + 1);
        public static Complex operator -(Complex a, double scalar) => new Complex(a.Real - scalar, a.Imaginary);
        public static Complex operator -(double scalar, Complex a) => new Complex(scalar - a.Real, -a.Imaginary);
        public static Complex operator -(Complex a, Complex b) => new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        public static Complex operator --(Complex a) => new Complex(a.Real - 1, a.Imaginary - 1);
        public static Complex operator *(Complex a, double scalar) => new Complex(a.Real * scalar, a.Imaginary * scalar);
        public static Complex operator *(double scalar, Complex a) => a * scalar;                             
        public static Complex operator *(Complex a, Complex b) => new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
        public static Complex operator /(Complex a, Complex b) => new Complex((a.Real * b.Real + a.Imaginary * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary), (a.Imaginary * b.Real - a.Real * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary));
        public static Complex operator /(Complex a, double scalar) => new Complex(a.Real / scalar, a.Imaginary / scalar);
        public static Complex operator /(double scalar, Complex a) => new Complex(scalar / a.Real, -scalar / a.Imaginary);
    }   
}