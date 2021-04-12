namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ProductConstructorShoulInitializiCorrectly()
        {
            string productLabel = "Gun";
            decimal productPrice = 325;
            int productQuantity = 3;

            Product product = new Product(productLabel,productPrice,productQuantity);

            Assert.AreEqual(productLabel,product.Label);
            Assert.AreEqual(productPrice,product.Price);
            Assert.AreEqual(productQuantity,product.Quantity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ProductConstructorShoulThrowExceptionIfLabelIsInvalid(string label)
        {
            Assert.Throws<ArgumentException>(() => new Product(label,10,10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void ProductConstructorShoulThrowExceptionIfPriceIsZeroOrNegativeNumber(decimal price)
        {
            Assert.Throws<ArgumentException>(() => new Product("Gun",price,10));
        }

        [Test]
        [TestCase(-20)]
        [TestCase(-5)]
        public void ProductConstructorShoulThrowExceptionIfQuantityIsNegative(int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product("Gun",10,quantity));
        }
    }
}