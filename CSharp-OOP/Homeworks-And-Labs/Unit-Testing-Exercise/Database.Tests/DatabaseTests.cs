using System;
using NUnit.Framework;

namespace Test
{
    using Database;
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [Test]
        public void DateBaseCantAddMoreThan16InregersArray()
        {
            //Arrange
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 };
            this.database = new Database(arr);
            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(7));
        }

        [Test]
        public void DateBaseCannotRemoveElementFromEmptyArray()
        {
            // Arrange
            this.database = new Database();
            // Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnArray()
        {
            //Arrange
            this.database = new Database();

            //Act - Assert
            Assert.That(database.Fetch() is int[]);
        }

        [Test]
        public void DataBaseCannotStoreMoreThe16IntegersArray()
        {
            //Arrange - Act - Assert
            Assert.Throws<InvalidOperationException>(() => new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7));
        }

        [Test]
        public void CheckIfAddMethodWorkCorrectly()
        {
            //Arrange
            this.database = new Database(1, 2, 3);

            //Act
            this.database.Add(4);

            //Assert
            Assert.AreEqual(4, this.database.Count);
        }

        [Test]
        public void CheckIfRemoveMethodWorkCorrectly()
        {
            //Arrange
            this.database = new Database(1, 2, 3);

            //Act
            this.database.Remove();

            //Assert
            Assert.AreEqual(2, this.database.Count);
        }
    }
}