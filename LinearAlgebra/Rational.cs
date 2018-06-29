using System;

namespace Linalg
{ 
    public sealed partial class Rational : IArithmetical<Rational>, ICloneable, IComparable<Rational>
    {
        public static readonly Rational ZERO = new Rational(0);
        public static readonly Rational ONE = new Rational(1);

        public long Nom { get; private set; } = 0;
        public long Den { get; private set; } = 1;

        public Rational() 
            : this(0)
        {
        }

        public Rational(long nom)
            : this(nom, 1)
        {
        }

        public Rational(long nom, long den)
        {
            if (den == 0)
                throw new DivideByZeroException();

            Nom = nom;
            Den = den;
            Simplify();
        }

        public Rational Add(Rational that)
        {
            long lcm = Utils.Lcm(Den, that.Den);
            long nom = Nom * (lcm / Den) + that.Nom * (lcm / that.Den);
            return new Rational(nom, lcm);
        }

        public Rational Sub(Rational that)
        {
            long lcm = Utils.Lcm(Den, that.Den);
            long nom = Nom * (lcm / Den) - that.Nom * (lcm / that.Den);
            return new Rational(nom, lcm);
        }

        public Rational Mul(Rational that)
        {
            return new Rational(Nom * that.Nom, Den * that.Den);
        }

        public Rational Div(Rational that)
        {
            return new Rational(Nom * that.Den, Den * that.Nom);
        }

        public Rational Sqrt()
        {
            return new Rational((long) Math.Sqrt(Nom), (long) Math.Sqrt(Den));
        }

        public Rational Inverse()
        {
            return new Rational(Den, Nom);
        }

        public Rational Neg()
        {
            return new Rational(-Nom, Den);
        }

        private void Simplify()
        {
            long gcd = Utils.Gcd(Nom, Den);
            Nom /= gcd;
            Den /= gcd;
            if (Den < 0)
            {
                Nom *= -1;
                Den *= -1;
            }
        }
    }
}