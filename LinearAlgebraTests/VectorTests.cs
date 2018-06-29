using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Linalg.Tests
{
    [TestClass()]
    public class VectorTests
    {
        [TestMethod()]
        public void TestAdd()
        {
            // Arrange
            Vector a = V(1, 2, 3);
            Vector b = V(3, 4, 5);

            // Act
            Vector actual = a + b;

            // Assert
            Assert.AreEqual(actual, V(4, 6, 8));
        }

        [TestMethod()]
        public void TestAddFails()
        {
            // Arrange
            Vector a = V(1, 2, 3);
            Vector b = V(3, 4, 5, 6);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => a + b);
        }

        [TestMethod()]
        public void TestSub()
        {
            // Arrange
            Vector a = V(1, 2, 3);
            Vector b = V(3, 4, 5);

            // Act
            Vector actual = a - b;

            // Assert
            Assert.AreEqual(actual, V(-2, -2, -2));
        }

        [TestMethod()]
        public void TestSubFails()
        {
            // Arrange
            Vector a = V(1, 2, 3);
            Vector b = V(3, 4, 5, 6);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => a - b);
        }

        [TestMethod()]
        public void TestMul()
        {
            // Arrange
            Vector a = V(1, 2, 3);
            Rational scalar = new Rational(3);

            // Act
            Vector actual = a * scalar;

            // Assert
            Assert.AreEqual(actual, V(3, 6, 9));
        }

        [TestMethod()]
        public void TestDiv()
        {
            // Arrange
            Vector a = V(3, 6, 9);
            Rational scalar = new Rational(3);

            // Act
            Vector actual = a / scalar;

            // Assert
            Assert.AreEqual(actual, V(1, 2, 3));
        }

        [TestMethod()]
        public void TestDotProd()
        {
            // Arrange
            Vector a = V(3, 6, 9);
            Vector b = V(1, 2, 3);

            // Act
            Rational actual = a * b;

            // Assert
            Assert.AreEqual(actual, new Rational(42));
        }

        [TestMethod()]
        public void TestDotProdFails()
        {
            // Arrange
            Vector a = V(3, 6, 9);
            Vector b = V(1, 2, 3, 4);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => a * b);
        }

        [TestMethod()]
        public void TestNormalize()
        {
            // Arrange
            Vector a = V(3, 6, 9);

            // Act
            Vector actual = a.Normalize();

            // Assert
            Assert.AreEqual(actual.Norm(), Rational.ONE);
        }

        [TestMethod()]
        public void TestNorm()
        {
            // Arrange
            Vector a = V(3, 6, 9);

            // Act
            Rational actual = a.Norm();

            // Assert
            Assert.AreEqual(actual, new Rational(11));
        }

        private static Vector V(params long[] nominators)
        {
            return new Vector(nominators.Select(nom => new Rational(nom)).ToList());
        }
    }
}