using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bank;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.bank = new BankVault();
            this.item = new Item("Gosho", "Chasha");
        }

        [Test]
        public void AddItem_NonExitCellExc()
        {
            Assert.Throws<ArgumentException>(() => this.bank.AddItem("A11", this.item));
        }

        [Test]
        public void AddItem_NonEmptyCellExc()
        {
            this.bank.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() => this.bank.AddItem("A1", this.item));
        }

        [Test]
        public void AddItem_ItemInCellExc()
        {
            this.bank.AddItem("A1", this.item);
            Assert.Throws<InvalidOperationException>(() => this.bank.AddItem("A2", this.item));
        }

        [Test]
        public void AddItem_Work()
        {

            string expectedResult = $"Item:{this.item.ItemId} saved successfully!";
            string actualResult = this.bank.AddItem("A1", this.item);



            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_NonExistCellExc()
        {
            Assert.Throws<ArgumentException>(() => this.bank.RemoveItem("A11",this.item));
        }

        [Test]
        public void Remove_NonExistItemInCellExc()
        {
            Assert.Throws<ArgumentException>(() => this.bank.RemoveItem("A1",this.item));
        }

        [Test]
        public void Remove_Work()
        {
            this.bank.AddItem("A1",this.item);

            string expectedResult = $"Remove item:{this.item.ItemId} successfully!";
            string actualResult = this.bank.RemoveItem("A1",this.item);

            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void Constructor_Work()
        {
            Assert.IsTrue(this.bank.VaultCells != null);
        }
    }
}