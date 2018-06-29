using LinAlg;

namespace Linalg
{
    public partial class SafeMatrix<T>: AbstractMatrix<SafeMatrix<T>, T> where T: IArithmetical<T>
    {
        public SafeMatrix()
            : base(new T[0, 0])
        {
        }

        public SafeMatrix(T[,] matrix)
            : base(matrix)
        {
        }

        protected override T AddComponent(T t0, T t1) => t0.Add(t1);

        protected override T SubComponent(T t0, T t1) => t0.Sub(t1);

        protected override T MulComponent(T t0, T t1) => t0.Mul(t1);

        public static SafeMatrix<T> operator +(SafeMatrix<T> a, SafeMatrix<T> b) => a.Add(b);

        public static SafeMatrix<T> operator -(SafeMatrix<T> a, SafeMatrix<T> b) => a.Sub(b);

        public static SafeMatrix<T> operator *(SafeMatrix<T> a, SafeMatrix<T> b) => a.Mul(b);

        public static SafeMatrix<T> operator *(SafeMatrix<T> a, T scalar) => a.Mul(scalar);
    }
}