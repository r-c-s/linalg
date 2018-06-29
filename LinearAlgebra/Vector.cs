using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linalg
{
    public partial class Vector
    {
        private readonly Rational[] vector;
        public int Length { get; } = 0;

        public Vector(int n) 
            : this(GetNewVector(n))
        {
        }

        public Vector(IEnumerable<Rational> vector) {
            this.vector = vector.ToArray();
            Length = this.vector.Length;
        }

        public Rational this[int i]
        {
            get { return vector[i]; }
        }

        public IEnumerator GetEnumerator()
        {
            return vector.GetEnumerator();
        }

        public Vector Add(Vector that)
        {
            AssertLength(this, that, "Cannot add vectors of different dimensions");

            return new Vector(vector.Zip(that.vector, (a, b) => a + b));
        }

        public Vector Sub(Vector that)
        {
            AssertLength(this, that, "Cannot subtract vectors of different dimensions");

            return new Vector(vector.Zip(that.vector, (a, b) => a - b));
        }

        public Vector Mul(Rational scalar)
        {
            return new Vector(vector.Select(r => r * scalar));
        }

        public Vector Div(Rational scalar)
        {
            return new Vector(vector.Select(r => r / scalar));
        }

        public Rational DotProd(Vector that)
        {
            AssertLength(this, that, "Cannot compute dot product of vectors of different dimensions");
            
            return vector.Zip(that.vector, (a, b) => a * b)
                .Aggregate(Rational.ZERO, (result, next) => result.Add(next));
        }

        public Vector Normalize()
        {
            return this / Norm();
        }

        public Rational Norm()
        {
            return DotProd(this).Sqrt();
        }

        private static Rational[] GetNewVector(int n)
        {
            Rational[] vector = new Rational[n];
            for (int i = 0; i < n; i++)
            {
                vector[i] = Rational.ZERO;
            }
            return vector;
        }

        private static void AssertLength(Vector a, Vector b, String message)
        {
            if (a.Length != b.Length)
                throw new ArgumentException(message);
        }
    }
}
