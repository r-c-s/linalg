using System;

namespace Linalg
{ 
    public sealed partial class Rational
    {        
        public object Clone()
        {
            return new Rational(Nom, Den);
        }

        public int CompareTo(Rational that)
        {
            if (Nom == that.Nom && Den == that.Den)
                return 0;
            long lcm = Utils.Lcm(Den, that.Den);
            return Math.Sign(Nom * (lcm / Den) - that.Nom * (lcm / that.Den));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rational))
                return false;

            Rational that = (Rational) obj;

            return Nom == that.Nom
                && Den == that.Den;
        }

        public override int GetHashCode()
        {
            int result = 17;
            result += 31 * result + Nom.GetHashCode();
            result += 31 * result + Den.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            if (Nom == 0) return "0";
            if (Den == 1) return Nom.ToString();
            return $"{Nom}/{Den}";
        }

        public static bool operator ==(Rational a, Rational b) =>
            a.Equals(b);

        public static bool operator !=(Rational a, Rational b) =>
            !a.Equals(b);

        public static Rational operator +(Rational a, Rational b) =>
            a.Add(b);

        public static Rational operator -(Rational a, Rational b) =>
            a.Sub(b);

        public static Rational operator *(Rational a, Rational b) =>
            a.Mul(b);

        public static Rational operator /(Rational a, Rational b) =>
            a.Div(b);

        public static bool operator <(Rational a, Rational b) =>
            a.CompareTo(b) < 0;

        public static bool operator >(Rational a, Rational b) =>
            a.CompareTo(b) > 0;

        public static bool operator <=(Rational a, Rational b) =>
            a.CompareTo(b) <= 0;

        public static bool operator >=(Rational a, Rational b) =>
            a.CompareTo(b) >= 0;

        public static explicit operator Complex(Rational a) =>
            new Complex(a);

        public static explicit operator double(Rational a) =>
            a.Nom / (double) a.Den;
    }
}