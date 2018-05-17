namespace TransactionSystem
{
    public class Withdraw : Transaction
    {
        private readonly Account _account;
        private readonly decimal _amount;

        public Withdraw(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;

            IsCompleted = false;
        }

        public override void Execute()
        {
            PerformTransactionExecution(_account.Balance >= _amount, () =>
            {
                _account.Balance = _account.Balance - _amount;
            });
        }

        public override void RollBackTransaction()
        {
            PerformTransactionRollback(true, () =>
            {
                _account.Balance += _amount;
            });
        }
    }
}
