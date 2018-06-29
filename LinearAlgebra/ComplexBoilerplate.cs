
namespace Linalg
{
    public sealed partial class Complex
    {
        public object Clone()
        {
            return new Complex((Rational) Real.Clone(), (Rational) Imag.Clone());
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Complex))
                return false;

            Complex that = (Complex)obj;

            return Real == that.Real
                && Imag == that.Imag;
        }

        public override int GetHashCode()
        {
            int result = 17;
            result += 31 * result + Real.GetHashCode();
            result += 31 * result + Imag.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}",
                Real != Rational.ZERO ? Real.ToString() : "",
                Imag != Rational.ZERO 
                    ? (Imag > Rational.ZERO && Real != Rational.ZERO ? "+" : "") 
                        + (Imag == Rational.ONE ? "" : Imag == Rational.ONE.Neg() ? "-" : Imag.ToString())
                        + "i" 
                    : "");
        }

        public static bool operator ==(Complex a, Complex b) =>
            a.Equals(b);

        public static bool operator !=(Complex a, Complex b) =>
            !a.Equals(b);

        public static Complex operator +(Complex a, Complex b) =>
            a.Add(b);

        public static Complex operator -(Complex a, Complex b) =>
            a.Sub(b);

        public static Complex operator *(Complex a, Complex b) =>
            a.Mul(b);

        public static Complex operator /(Complex a, Complex b) =>
            a.Div(b);
    }
}