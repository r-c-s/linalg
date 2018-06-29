using System.Linq;

namespace Linalg
{
    public partial class Vector
    {
        public override int GetHashCode()
        {
            return vector
                .Select(r => r.GetHashCode())
                .Aggregate(17, (result, next) => result + 31 * result + next);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
                return false;

            Vector that = (Vector) obj;

            if (Length != that.Length)
                return false;

            for (int i = 0; i < Length; i++)
                if (this[i] != that[i])
                    return false;

            return true;
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", (object[]) vector) + "]";
        }

        public static bool operator ==(Vector a, Vector b) => 
            a.Equals(b);

        public static bool operator !=(Vector a, Vector b) =>
           !a.Equals(b);

        public static Vector operator +(Vector a, Vector b) =>
            a.Add(b);

        public static Vector operator -(Vector a, Vector b) =>
            a.Sub(b);

        public static Rational operator *(Vector a, Vector b) =>
            a.DotProd(b);

        public static Vector operator *(Vector a, Rational scalar) =>
            a.Mul(scalar);

        public static Vector operator /(Vector a, Rational scalar) =>
            a.Div(scalar);

        public static explicit operator double[](Vector a) =>
            a.vector.Select(r => (double) r).ToArray();
    }
}
