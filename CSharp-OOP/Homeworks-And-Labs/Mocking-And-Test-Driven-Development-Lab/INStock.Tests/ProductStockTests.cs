namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using INStock.Contracts;

    [TestFixture]
    public class ProductStockTests
    {
        private ProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock(new List<IProduct>());
        }

        [Test]
        public void ProductStockConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(this.productStock);
        }


        [Test]
        [TestCase("Gun")]
        [TestCase("Milk")]
        public void GivenProductStockWhenAddThenShouldAddProductInStock(string lable)
        {
            // Assert
            IProduct product = new Product(lable, 200, 5);
            this.productStock.Add(product);

            // Act
            string expectedProduct = lable;
            string actualProduct = this.productStock.Products.FirstOrDefault(p => p.Label == lable).Label;
            int expectedCount = 1;
            int actualCount = this.productStock.Count;

            // Assert
            Assert.AreEqual(expectedProduct, actualProduct);
            Assert.AreEqual(expectedCount, actualCount);


        }

        [Test]
        public void GivenProductStockWhenAddThenShouldThrowExceptionIfProductExist()
        {
            // Assert
            IProduct product = new Product("Gun", 200, 5);
            this.productStock.Add(product);

            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => this.productStock.Add(product));
        }

        [Test]
        public void ProductStockContainsShoulReturnTrueIfGivenProductExist()
        {
            IProduct product = new Product("Gun", 200, 5);
            this.productStock.Add(product);

            Assert.IsTrue(this.productStock.Contains(product));

        }

        [Test]
        public void ProductStockContainsShoulReturnFalseIfGivenProductNotExist()
        {
            IProduct product = new Product("Gun", 200, 5);

            Assert.IsFalse(this.productStock.Contains(product));

        }

        [Test]
        public void ProductStockFindShouldReturnProductOfGivenIndex()
        {
            this.productStock.Add(new Product("Gun", 20, 3));
            this.productStock.Add(new Product("Milk", 2, 30));
            this.productStock.Add(new Product("Honey", 10, 5));

            string expectedResult = "Honey";
            string actualResult = this.productStock.Find(2).Label;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ProductStockFindShouldThrowExceptionIfGivenIndexIsInvalid()
        {
            this.productStock.Add(new Product("Gun", 20, 3));
            this.productStock.Add(new Product("Milk", 2, 30));
            this.productStock.Add(new Product("Honey", 10, 5));

            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(3));
        }

        [Test]
        public void ProductStockFindByLableShoulReturnProduckWithGivenLable()
        {
            // Assert
            IProduct product = new Product("Egg", 0.25m, 10);

            // Act
            this.productStock.Add(product);
            IProduct actualProduct = this.productStock.FindByLabel("Egg");

            // Assert
            Assert.That(actualProduct, Is.EqualTo(product));
        }

        [Test]
        public void ProductStockFindByLableShoulThrowExceptionIfProductWithGivenLableNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel("Egg"));
        }

        [Test]
        public void ProductStockFindAllInPriceRangeShouldWorkCorrectly()
        {
            Product gun = new Product("Gun", 50, 3);
            Product milk = new Product("Milk", 2, 30);
            Product honey = new Product("Honey", 10, 30);
            Product shoes = new Product("Shoes", 120, 5);

            this.productStock.Add(gun);
            this.productStock.Add(milk);
            this.productStock.Add(honey);
            this.productStock.Add(shoes);

            List<IProduct> expectedResult =
                new List<IProduct> { shoes, gun };

            List<IProduct> actualResult = this.productStock.FindAllInPriceRange(50, 200).ToList();

            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [Test]
        public void ProductStockFindAllInPriceRangeShouldReturnEmptyCollectionIfNoElemetsInGivePriceRange()
        {
            this.productStock.Add(new Product("Gun", 50, 3));
            this.productStock.Add(new Product("Milk", 30, 30));

            List<IProduct> actualResult = this.productStock.FindAllInPriceRange(100, 70).ToList();

            Assert.IsTrue(actualResult.Count == 0);

        }

        [Test]
        public void ProductStockFindAllByPriceShouldWorkCorrectly()
        {
            Product gun = new Product("Gun", 50, 3);
            Product milk = new Product("Milk", 30, 5);
            Product honey = new Product("Honey", 30, 3);

            this.productStock.Add(gun);
            this.productStock.Add(milk);
            this.productStock.Add(honey);

            List<IProduct> expectedResult =
                new List<IProduct> { milk, honey };

            List<IProduct> actualResult = this.productStock.FindAllByPrice(30).ToList();

            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [Test]
        public void ProductStockFindAllByPriceShouldReturnEmptyCollectionIfNoElemetsInGivePriceRange()
        {
            this.productStock.Add(new Product("Gun", 50, 3));
            this.productStock.Add(new Product("Milk", 30, 30));

            List<IProduct> actualResult = this.productStock.FindAllByPrice(10).ToList();

            Assert.IsTrue(actualResult.Count == 0);

        }

        [Test]
        public void ProductStockFindMostExpensiveProductsShouldWorkCorrectly()
        {
            Product gun = new Product("Gun", 50, 3);
            Product milk = new Product("Milk", 100, 30);
            Product honey = new Product("Honey", 200, 30);

            this.productStock.Add(gun);
            this.productStock.Add(milk);
            this.productStock.Add(honey);

            List<IProduct> expectedResult =
                new List<IProduct> { honey, milk };

            List<IProduct> actualResult =
                this.productStock.FindMostExpensiveProducts(2).ToList();

            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [Test]
        public void ProductStockFindAllByQuantityShouldWorkCorrectly()
        {
            this.productStock.Add(new Product("Gun", 50, 3));
            this.productStock.Add(new Product("Milk", 100, 30));
            this.productStock.Add(new Product("Honey", 200, 30));

            int expectedResultWithFoundElements = 2;
            int actualResultWithFoundElements = this.productStock.FindAllByQuantity(30).ToList().Count;

            int expectedResultWithNoFoundElements = 0;
            int actualResultWithNoFoundElements = this.productStock.FindAllByQuantity(50).ToList().Count;

            Assert.AreEqual(expectedResultWithFoundElements, actualResultWithFoundElements);
            Assert.AreEqual(expectedResultWithNoFoundElements, actualResultWithNoFoundElements);
        }

        [Test]
        public void ProductStockGetEnumeratorShouldWorkCorrectly()
        {
            this.productStock.Add(new Product("Gun", 50, 3));
            this.productStock.Add(new Product("Milk", 100, 30));
            this.productStock.Add(new Product("Honey", 200, 30));

            int expectedResult = 3;
            int actualResult = this.productStock.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ProductStockIndexerShouldWorkCorrectly()
        {
            Product gun = new Product("Gun", 50, 3);
            Product milk = new Product("Milk", 100, 30);
            Product honey = new Product("Honey", 200, 30);

            this.productStock.Add(gun);
            this.productStock.Add(milk);
            this.productStock.Add(honey);

            Product expectedProduct = gun;
            Product actualProduct = (Product)this.productStock[0];

            Assert.AreEqual(expectedProduct, actualProduct);
        }
    }
}
