using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Linalg.Tests
{
    [TestClass()]
    public class RationalTests
    {
        [TestMethod()]
        public void TestDivisionByZeroFails()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() => new Rational(1, 0));
        }

        [TestMethod()]
        public void TestSimplifies()
        {
            // Arrange

            // Act
            Rational actual = new Rational(2, 4);

            // Assert
            Assert.AreEqual(actual.Nom, 1);
            Assert.AreEqual(actual.Den, 2);
        }

        [TestMethod()]
        public void TestAdd()
        {
            // Arrange
            Rational a = new Rational(1, 2);
            Rational b = new Rational(2, 3);

            // Act
            Rational actual = a + b;

            // Assert
            Assert.AreEqual(actual.Nom, 7);
            Assert.AreEqual(actual.Den, 6);
        }

        [TestMethod()]
        public void TestSub()
        {
            // Arrange
            Rational a = new Rational(1, 2);
            Rational b = new Rational(2, 3);

            // Act
            Rational actual = a - b;

            // Assert
            Assert.AreEqual(actual.Nom, -1);
            Assert.AreEqual(actual.Den, 6);
        }

        [TestMethod()]
        public void TestMul()
        {
            // Arrange
            Rational a = new Rational(1, 2);
            Rational b = new Rational(2, 3);

            // Act
            Rational actual = a * b;

            // Assert
            Assert.AreEqual(actual.Nom, 1);
            Assert.AreEqual(actual.Den, 3);
        }

        [TestMethod()]
        public void TestDiv()
        {
            // Arrange
            Rational a = new Rational(1, 2);
            Rational b = new Rational(2, 3);

            // Act
            Rational actual = a / b;

            // Assert
            Assert.AreEqual(actual.Nom, 3);
            Assert.AreEqual(actual.Den, 4);
        }

        [TestMethod()]
        public void TestSqrt()
        {
            // Arrange
            Rational a = new Rational(4, 25);

            // Act
            Rational actual = a.Sqrt();

            // Assert
            Assert.AreEqual(actual.Nom, 2);
            Assert.AreEqual(actual.Den, 5);
        }

        [TestMethod()]
        public void TestInverse()
        {
            // Arrange
            Rational a = new Rational(3, 7);

            // Act
            Rational actual = a.Inverse();

            // Assert
            Assert.AreEqual(actual.Nom, 7);
            Assert.AreEqual(actual.Den, 3);
        }
    }
}