using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;


        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }




        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (Contains(tx))
            {
                throw new InvalidOperationException();
            }
            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException();
            }

            transaction.Status = newStatus;

        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Any(t => t.Id == tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactions
                .Where(t => t.Amount >= lo && t.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receivers =
               this.transactions.Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            if (receivers.Any() == false)
            {
                throw new InvalidOperationException();
            }
            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders =
               this.transactions.Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            if (senders.Any() == false)
            {
                throw new InvalidOperationException();
            }
            return senders;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }
            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = this.transactions
                .Where(t => t.To == receiver && (t.Amount >= lo && t.Amount < hi))
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (result.Any() == false)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> result = this.transactions
                .Where(t => t.To == receiver)
                .OrderBy(t => t.Amount)
                .ThenBy(t => t.Id);

            if (result.Any() == false)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> result = this.transactions
                .Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount);

            if (result.Any() == false)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> allSenderTransaction =
                this.transactions.Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);
            if (allSenderTransaction.FirstOrDefault() == null)
            {
                throw new InvalidOperationException();
            }

            return allSenderTransaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> result =
                this.transactions.Where(t => t.Status == status);
            if (result.Any() == false)
            {
                throw new InvalidOperationException();
            }
            result = result.OrderByDescending(t => t.Amount);
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions
                .Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction;
            }

        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }
            this.transactions.Remove(transaction);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
