using System;

namespace TransactionSystem
{
    public class TransactionManager
    {
        //TODO:  Maintain a List of Transactions (Deposit/Withdraw/ Transfer )

        //TODO:  Add a Method for Adding Transaction

        
        
        
        public bool HasPendingTransactions()
        {
            // This should track if there is any pending transaction request (Deposit/Withdraw/ Transfer)
            throw new NotImplementedException();
        }

        public void ProcessPendingTransactions()
        {
            // The logic for processing pending transaction sequentially goes here
            // It should track which are already processed and which are pending transactions
            throw new NotImplementedException();
        }

        public void RollbackTransaction(Guid transactionId)
        {
            // The logic for rolling back a transaction with Id
            throw new NotImplementedException();
        }
    }
}
