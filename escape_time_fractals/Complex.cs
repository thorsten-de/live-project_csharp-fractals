using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace escape_time_fractals
{
    public class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public Complex(double re)
            : this(re, 0)
        {
        }
        public Complex()
            : this(0, 0)
        {
        }

        // Magnitude.
        public double Magnitude()
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }

        // Multiplication.
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(
                c1.Re * c2.Re - c1.Im * c2.Im,
                c1.Re * c2.Im + c1.Im * c2.Re);
        }

        // Return 1/c.
        public Complex Inverse()
        {
            double magnitude = Magnitude();
            return new Complex(Re / magnitude, -Im / magnitude);
        }

        // Division.
        public static Complex operator /(Complex c1, Complex c2)
        {
            return c1 * c2.Inverse();
        }

        // Unary negation.
        public static Complex operator -(Complex c1)
        {
            return new Complex(-c1.Re, -c1.Im);
        }

        // Addition.
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Re + c2.Re, c1.Im + c2.Im);
        }

        // Subtraction.
        public static Complex operator -(Complex c1, Complex c2)
        {
            return c1 + (-c2);
        }

        // Convert double to Complex.
        public static implicit operator Complex(double d)
        {
            return new Complex(d);
        }

        public override string ToString()
        {
            return string.Format("{0} + {1}i", Re, Im);
        }
    }
}
