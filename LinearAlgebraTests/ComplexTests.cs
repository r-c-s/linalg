using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linalg.Tests
{
    [TestClass()]
    public class ComplexTests
    {
        [TestMethod()]
        public void TestAdd()
        {
            // Arrange
            Complex a = C(3, 4);
            Complex b = C(2, 7);

            // Act
            Complex actual = a + b;

            // Assert
            Assert.AreEqual(actual.Real, new Rational(5));
            Assert.AreEqual(actual.Imag, new Rational(11));
        }

        [TestMethod()]
        public void TestSub()
        {
            // Arrange
            Complex a = C(3, 4);
            Complex b = C(2, 7);

            // Act
            Complex actual = a - b;

            // Assert
            Assert.AreEqual(actual.Real, new Rational(1));
            Assert.AreEqual(actual.Imag, new Rational(-3));
        }

        [TestMethod()]
        public void TestMul()
        {
            // Arrange
            Complex a = C(3, 4);
            Complex b = C(2, 7);

            // Act
            Complex actual = a * b;

            // Assert
            Assert.AreEqual(actual.Real, new Rational(-22));
            Assert.AreEqual(actual.Imag, new Rational(29));
        }

        [TestMethod()]
        public void TestDiv()
        {
            // Arrange
            Complex a = C(3, 4);
            Complex b = C(2, 7);

            // Act
            Complex actual = a / b;

            // Assert
            Assert.AreEqual(actual.Real, new Rational(34, 53));
            Assert.AreEqual(actual.Imag, new Rational(-13, 53));
        }

        [TestMethod()]
        public void TestComplexConjugate()
        {
            // Arrange
            Complex target = C(3, 4);

            // Act
            Complex actual = target.ComplexConjugate();

            // Assert
            Assert.AreEqual(actual.Real, new Rational(3));
            Assert.AreEqual(actual.Imag, new Rational(-4));
        }

        private static Complex C(long real, long imag)
        {
            return new Complex(new Rational(real), new Rational(imag));
        }
    }
}