using System;
using System.Linq;

namespace Linalg
{
    public interface IArithmetical<T>
    {
        T Add(T t);
        T Sub(T t);
        T Mul(T t);
        T Div(T t);
    }

    public class Utils
    {
        private static readonly Random r = new Random();

        public static long Lcm(long a, long b)
        {
            if (Math.Abs(a) == Math.Abs(b))
                return Math.Abs(a);

            return Math.Abs(a * b) / Gcd(a, b);
        }

        public static long Gcd(long a, long b)
        {
            if (a % b == 0)
                return b;

            return Gcd(b, a % b);
        }

        public static Vector RandomVector(int length, int maxNom, int maxDen)
        {
            return new Vector(Enumerable.Range(0, length).Select(i => RandomRational(maxNom, maxDen)));
        }

        public static Rational RandomRational(int maxNom, int maxDen)
        {
            return new Rational(r.Next(-maxNom, maxNom), r.Next(1, maxDen)); 
        }

        public static Complex RandomComplex(int maxNom, int maxDen)
        {
            return new Complex(
                RandomRational(maxNom, maxDen), 
                RandomRational(maxNom, maxDen));
        }

        public static SafeMatrix<T> RandomMatrix<T>(int rows, int columns, Func<int, int, T> factory)
            where T : IArithmetical<T>
        {
            T[,] matrixData = new T[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    matrixData[i, j] = factory(9, 9);
            return new SafeMatrix<T>(matrixData);
        }

        public static UnsafeMatrix<long> RandomMatrix(int rows, int columns)
        {
            Random random = new Random();
            long[,] data = new long[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    data[i, j] = random.Next(-10, 10);
            return new UnsafeMatrix<long>(data);
        }
    }
}