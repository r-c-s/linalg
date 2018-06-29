using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linalg.Tests
{
    [TestClass()]
    public class ParallelMatrixMultiplicatorTests
    {
        [TestMethod()]
        public void TestMultiplyNonSquare()
        {
            // Arrange
            UnsafeMatrix<long> A = Utils.RandomMatrix(50, 75);
            UnsafeMatrix<long> B = Utils.RandomMatrix(75, 50);

            // Act
            UnsafeMatrix<long> actual = new ParallelMatrixMultiplicator()
                .Multiply<long>(A, B, 25);

            // Assert
            Assert.AreEqual(actual, A * B);
        }

        [TestMethod()]
        public void TestMultiplySquare()
        {
            // Arrange
            UnsafeMatrix<long> A = Utils.RandomMatrix(50, 50);
            UnsafeMatrix<long> B = Utils.RandomMatrix(50, 50);

            // Act
            UnsafeMatrix<long> actual = new ParallelMatrixMultiplicator()
                .Multiply<long>(A, B, 10);

            // Assert
            Assert.AreEqual(actual, A * B);
        }
    }
}