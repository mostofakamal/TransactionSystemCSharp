using System;
using System.Linq;
using System.Collections.Generic;

namespace TransactionSystem
{
    public class TransactionManager
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public bool HasPendingTransactions
        {
            get { return _transactions.Any(x => !x.IsCompleted); }
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void ProcessPendingTransactions()
        {
            foreach (var transaction in _transactions.Where(x => !x.IsCompleted))
            {
                if (!transaction.PendingForRollback)
                    transaction.Execute();
                else
                    transaction.RollBackTransaction();
            }
        }

        public void RollbackTransaction(Guid transactionId)
        {
            var transaction = _transactions.FirstOrDefault(x => x.TransactionId == transactionId);

            if (transaction == null)
            {
                throw new ArgumentException($"Transaction with Id {transactionId} does not exist!!");
            }

            if (!transaction.IsCompleted)
            {
                throw new InvalidOperationException("Can not rollback incomplete transaction");
            }
            if (!transaction.IsAbleToRollback)
            {
                throw new InvalidOperationException("Transaction is not able to be rollbacked");
            }

            transaction.IsCompleted = false;
            transaction.PendingForRollback = true;
        }
    }
}
