using LinAlg;

namespace Linalg
{
    public partial class UnsafeMatrix<T>: AbstractMatrix<UnsafeMatrix<T>, T>
    {
        public UnsafeMatrix()
            : base(new T[0, 0])
        {
        }

        public UnsafeMatrix(T[,] matrix)
            : base(matrix)
        {
        }

        protected override T AddComponent(T t0, T t1) => D(t0) + D(t1);

        protected override T SubComponent(T t0, T t1) => D(t0) - D(t1);

        protected override T MulComponent(T t0, T t1) => D(t0) * D(t1);

        protected override T DivComponent(T t0, T t1) => D(t0) / D(t1);

        public static UnsafeMatrix<T> operator +(UnsafeMatrix<T> a, UnsafeMatrix<T> b) => a.Add(b);

        public static UnsafeMatrix<T> operator -(UnsafeMatrix<T> a, UnsafeMatrix<T> b) => a.Sub(b);

        public static UnsafeMatrix<T> operator *(UnsafeMatrix<T> a, UnsafeMatrix<T> b) => a.Mul(b);

        public static UnsafeMatrix<T> operator *(UnsafeMatrix<T> a, T scalar) => a.Mul(scalar);

        private static dynamic D(T t) => t as dynamic;
    }
}