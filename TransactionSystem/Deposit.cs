namespace TransactionSystem
{
    public class Deposit : Transaction
    {
        private readonly Account _account;
        private readonly decimal _amount;

        public Deposit(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;

            IsCompleted = false;
        }

        public override void Execute()
        {
            PerformTransactionExecution(true, () =>
            {
                _account.Balance += _amount;
            });
        }

        public override void RollBackTransaction()
        {
            PerformTransactionRollback(_account.Balance >= _amount, () =>
            {
                _account.Balance -= _amount;
            });
        }
    }
}
