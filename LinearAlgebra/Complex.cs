using System;

namespace Linalg
{
    public sealed partial class Complex : IArithmetical<Complex>, ICloneable
    {
        public Rational Real { get; private set; } = new Rational(0);
        public Rational Imag { get; private set; } = new Rational(0);

        public Complex()
            : this(new Rational(0))
        {
        }

        public Complex(Rational real)
            : this(real, new Rational(0))
        {
        }

        public Complex(Rational real, Rational imag)
        {
            Real = real;
            Imag = imag;
        }

        public Complex Add(Complex that)
        {
            return new Complex(
                Real + that.Real, 
                Imag + that.Imag);
        }

        public Complex Sub(Complex that)
        {
            return new Complex(
                Real - that.Real, 
                Imag - that.Imag);
        }

        public Complex Mul(Complex that)
        {
            return new Complex(
                (Real * that.Real) - (Imag * that.Imag),
                (Real * that.Imag) + (Imag * that.Real));
        }

        public Complex Div(Complex that)
        {
            Complex cj = that.ComplexConjugate();
            Complex nom = this * cj;
            Complex den = that * cj;
            return nom * new Complex(new Rational(1) / den.Real);
        }

        public Complex ComplexConjugate()
        {
            return new Complex(Real, Imag.Mul(new Rational(-1)));
        }
    }
}