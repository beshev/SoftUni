using NUnit.Framework;
using System.Collections.Generic;

using Chainblock.Contracts;

namespace Chainblock.Tests
{
    using Chainblock.Models;
    using System;

    [TestFixture]
    public class ChainblockTest
    {
        private IChainblock chainblock;
        private ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.transaction = new Transaction(1, TransactionStatus.Successfull, "Bank", "Me", 20);
        }

        [Test]
        public void GivenChainblock_WhenAdd_ThenTransactionAdded()
        {
            this.chainblock.Add(this.transaction);

            int expectedCount = 1;
            int actualCount = this.chainblock.Count;
            bool expedtedResult = true;
            bool actualResult = this.chainblock.Contains(this.transaction);

            Assert.AreEqual(expedtedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void GivenChainblock_WhenAdd_ThenThrowExceptionIfTransactionExist()
        {
            this.chainblock.Add(this.transaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(this.transaction));
        }

        [Test]
        public void GivenChainblock_WhenContains_ThenWorkCorrectly()
        {
            this.chainblock.Add(this.transaction);

            Assert.IsTrue(this.chainblock.Contains(1));
            Assert.IsFalse(this.chainblock.Contains(0));
        }

        [Test]
        public void GivenChainblock_WhenChangeTransactionStatus_ThenChangeCorrectly()
        {
            // Arrange
            this.chainblock.Add(this.transaction);
            this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);

            // Act
            TransactionStatus expectedResult = TransactionStatus.Failed;
            TransactionStatus actualResult = this.transaction.Status;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GivenChainblock_WhenChangeTransactionStatus_ThenThrowExceptionIfTransactionNotExist()
        {
            this.chainblock.Add(this.transaction);
            Assert.Throws<ArgumentException>
                (() => this.chainblock.ChangeTransactionStatus(0, TransactionStatus.Failed));
        }

        [Test]
        public void GivenChainblock_WhenRemove_ThenRemoveTransaction()
        {
            // Arrange
            this.chainblock.Add(this.transaction);

            // Act 
            this.chainblock.RemoveTransactionById(this.transaction.Id);
            bool expectedResult = false;
            bool actualResult = this.chainblock.Contains(this.transaction.Id);

            int expedtedCount = 0;
            int actualCount = this.chainblock.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expedtedCount, actualCount);
        }

        [Test]
        public void GivenChainblock_WhenRemove_ThenThrowExceptionIfTransactionNotExist()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.RemoveTransactionById(this.transaction.Id));
        }

        [Test]
        public void GivenChainblock_WhenGetById_ThenThrowExceptionIfTransactionNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(1));
        }

        [Test]
        public void GivenChainblock_WhenGetById_ThenReturnTransaction()
        {
            this.chainblock.Add(this.transaction);

            Assert.AreEqual(this.transaction, this.chainblock.GetById(1));
        }

        [Test]
        public void GivenChainblock_WhenGetByTransactionStatus_ThenReturnTransactions()
        {
            ITransaction transaction = new Transaction(0, TransactionStatus.Successfull, "You", "Me", 30);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(transaction);

            var expectedResult = new List<ITransaction> { transaction, this.transaction };

            Assert
                .AreEqual(expectedResult, this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull));


        }

        [Test]
        public void GivenChainblock_WhenGetByTransactionStatus_ThenThrowExceptioIfDontHaveTransaction()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GivenChainblock_WhenGetAllSendersWithTransactionStatus_ThenReturnSenders()
        {
            ITransaction fromGogo = new Transaction(0, TransactionStatus.Successfull, "Gogo", "Me", 5);
            ITransaction fromPesho = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Me", 2);
            ITransaction fromVik = new Transaction(3, TransactionStatus.Failed, "Vik", "Me", 20);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(fromGogo);
            this.chainblock.Add(fromPesho);
            this.chainblock.Add(fromVik);

            IEnumerable<string> expectedSenders = new List<string>() { "Pesho", "Gogo", "Bank" };
            IEnumerable<string> actualSenders = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expectedSenders, actualSenders);
        }

        [Test]
        public void GivenChainblock_WhenGetAllSendersWithTransactionStatus_ThenThrowExceptioNotTransactionsExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }


        [Test]
        public void GivenChainblock_WhenGetAllReceiversWithTransactionStatus_ThenReturnRecievers()
        {
            ITransaction fromGogo = new Transaction(0, TransactionStatus.Successfull, "Gogo", "Pesho", 5);
            ITransaction fromPesho = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gogo", 2);
            ITransaction fromVik = new Transaction(3, TransactionStatus.Failed, "Vik", "Me", 20);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(fromGogo);
            this.chainblock.Add(fromPesho);
            this.chainblock.Add(fromVik);

            IEnumerable<string> expectedRecievers = new List<string>() { "Gogo", "Pesho", "Me" };
            IEnumerable<string> actualRecievers = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expectedRecievers, actualRecievers);
        }

        [Test]
        public void GivenChainblock_WhenGetAllReceiversWithTransactionStatus_ThenThrowExceptioNotTransactionsExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GivenChainblock_WhenGetAllOrderedByAmountDescendingThenById_ThenReturnSenders()
        {
            ITransaction fromGogo = new Transaction(0, TransactionStatus.Successfull, "Gogo", "Pesho", 5);
            ITransaction fromPesho = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gogo", 5);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(fromGogo);
            this.chainblock.Add(fromPesho);

            IEnumerable<ITransaction> expectedSenders =
                new List<ITransaction>() { this.transaction, fromGogo, fromPesho };

            IEnumerable<ITransaction> actualSenders = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            Assert.AreEqual(expectedSenders, actualSenders);
        }

        [Test]
        public void GivenChainblock_WhenGetBySenderOrderedByAmountDescending_ThenReturnSenderTransaction()
        {
            ITransaction transaction1 = new Transaction(0, TransactionStatus.Successfull, "Pesho", "Pesho", 20);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gogo", 50);
            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);

            IEnumerable<ITransaction> expectedTransactions =
                new List<ITransaction>() { transaction2, transaction1 };

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetBySenderOrderedByAmountDescending("Pesho");

            Assert.AreEqual(expectedTransactions, actualTransactions);

        }

        [Test]
        public void GivenChainblock_WhenGetBySenderOrderedByAmountDescending_ThenThrowExceptionIfNoTransactionByGivenSender()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending("Pesho"));
        }

        [Test]
        public void GivenChainblock_WhenGetByReceiverOrderedByAmountThenById_ThenReturnRecieverTransaction()
        {
            ITransaction transaction1 = new Transaction(0, TransactionStatus.Successfull, "Toto", "Me", 20);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Me", 20);
            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);

            IEnumerable<ITransaction> expectedTransactions =
                new List<ITransaction>() { transaction1, transaction2 };

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById("Me");

            Assert.AreEqual(expectedTransactions, actualTransactions);

        }

        [Test]
        public void GivenChainblock_WhenGetByReceiverOrderedByAmountThenById_ThenThrowExceptionIfNoTransactionByGivenReceiver()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById("Me"));
        }

        [Test]
        public void GivenChainblock_WhenGetByTransactionStatusAndMaximumAmount_ThenReturnAllTransactions()
        {
            ITransaction fromGogo = new Transaction(0, TransactionStatus.Successfull, "Gogo", "Pesho", 200);
            ITransaction fromPesho = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gogo", 15);
            ITransaction fromVik = new Transaction(3, TransactionStatus.Failed, "Vik", "Me", 50);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(fromGogo);
            this.chainblock.Add(fromPesho);
            this.chainblock.Add(fromVik);

            var expectedTransactions = new List<ITransaction> { this.transaction, fromPesho };
            var actualTransactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 20);

            Assert.AreEqual(expectedTransactions, actualTransactions);
            Assert.AreEqual(new List<ITransaction>(), this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted,10));
        }

        [Test]
        public void GivenChainblock_WhenGetByGetBySenderAndMinimumAmountDescending_ThenReturnAllSenderTransactions()
        {
            ITransaction transaction1 = new Transaction(0, TransactionStatus.Successfull, "Bank", "Pesho", 200);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Bank", "Gogo", 15);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Bank", "Me", 50);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);

            var expectedTransactions = new List<ITransaction> { transaction1, transaction3 };
            var actualTransactions = this.chainblock.GetBySenderAndMinimumAmountDescending("Bank", 20);

            Assert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GivenChainblock_WhenGetByGetBySenderAndMinimumAmountDescending_ThenThrowExceptionIfThereIsNotTransactions()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending("Bank",20));
        }

        [Test]
        public void GivenChainblock_WhenGetByReceiverAndAmountRange_ThenReturnReceiverTransactions()
        {

            ITransaction transaction1 = new Transaction(0, TransactionStatus.Successfull, "Bank", "Me", 200);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Bank", "Me", 15);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Bank", "Me", 50);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);

            var expectedTransactions = new List<ITransaction> { transaction3, this.transaction };
            var actualTransactions = this.chainblock.GetByReceiverAndAmountRange("Me", 20,200);

            Assert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GivenChainblock_WhenGetByReceiverAndAmountRange_ThenThrowExceptionIfThereIsNotTransactions()
        {
            Assert.Throws<InvalidOperationException>
                (() => this.chainblock.GetByReceiverAndAmountRange("Me",20,200));
        }

        [Test]
        public void GivenChainblock_WhenGetAllInAmountRange_ThenReturnAllTransactionInAmountRange()
        {
            ITransaction transaction1 = new Transaction(0, TransactionStatus.Successfull, "Bank", "Me", 200);
            ITransaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "Bank", "Me", 15);
            ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "Bank", "Me", 50);
            this.chainblock.Add(this.transaction);
            this.chainblock.Add(transaction1);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);

            var expectedTransactions = new List<ITransaction> {this.transaction, transaction3 };
            var actualTransactions = this.chainblock.GetAllInAmountRange(20, 50);

            var actualEmptyResult = this.chainblock.GetAllInAmountRange(10, 14);

            Assert.AreEqual(expectedTransactions, actualTransactions);
            Assert.AreEqual(new List<ITransaction>(), actualEmptyResult);
        }
    }
}
