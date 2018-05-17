namespace TransactionSystem
{
    public class Transfer : Transaction
    {
        private readonly decimal _amount;
        private readonly Account _fromAccount;
        private readonly Account _toAccount;

        public Transfer(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
            IsCompleted = false;
        }

        public override void Execute()
        {
            PerformTransactionExecution(_fromAccount.Balance >= _amount, () =>
            {
                _fromAccount.Balance -= _amount;
                _toAccount.Balance += _amount;
            });
        }

        public override void RollBackTransaction()
        {
            PerformTransactionRollback(_toAccount.Balance >= _amount, () =>
            {
                _toAccount.Balance -= _amount;
                _fromAccount.Balance += _amount;
            });
        }
    }
}
