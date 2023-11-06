using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimInterConstruct
{
    public interface IComparer<T> where T : struct
    {
        int Compare(T x, T y);
    }

    public struct ComplexNumber : IComparer<ComplexNumber>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public int Compare(ComplexNumber x, ComplexNumber y)
        {
            // Сравнение комплексных чисел по их модулю
            double modX = Math.Sqrt(x.Real * x.Real + x.Imaginary * x.Imaginary);
            double modY = Math.Sqrt(y.Real * y.Real + y.Imaginary * y.Imaginary);

            if (modX < modY)
                return -1;
            else if (modX > modY)
                return 1;
            else
                return 0;
        }
    }

    public struct RationalNumber : IComparer<RationalNumber>
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Compare(RationalNumber x, RationalNumber y)
        {
            // Сравнение рациональных чисел
            double valueX = (double)x.Numerator / x.Denominator;
            double valueY = (double)y.Numerator / y.Denominator;

            if (valueX < valueY)
                return -1;
            else if (valueX > valueY)
                return 1;
            else
                return 0;
        }
    }
}
