using System;

namespace TransactionSystem
{
    public abstract class Transaction
    {
        protected Transaction()
        {
            TransactionId = Guid.NewGuid();
        }
        public Guid TransactionId { get; }
        public bool IsCompleted { get; set; }

        public bool PendingForRollback { get; set; }

        public bool IsAbleToRollback { get; set; }

        public abstract void Execute();
        public abstract void RollBackTransaction();

        protected void PerformTransactionExecution(bool conditionMet, Action action)
        {
            if (conditionMet)
            {
                action();
                IsCompleted = true;
                IsAbleToRollback = true;
            }
        }
        protected void PerformTransactionRollback(bool conditionMet, Action action)
        {
            if (conditionMet)
            {
                action();
                PendingForRollback = false;
                IsCompleted = true;
                IsAbleToRollback = false;
            }
            else
            {
                IsCompleted = false;
                PendingForRollback = true;
            }
        }
    }
}
