using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionSystem;

namespace TransactionSystemTests
{
    [TestClass]
    public class TransactionTests
    {
        private readonly TransactionManager _transactionManager = new TransactionManager();

        [TestMethod]
        public void DepositAccountCheckBalanceAndThenWithdraw_AllTransactionsSuccessful()
        {
            Account sumonAccount = new Account("Sumon", 0);
            Deposit deposit = new Deposit(sumonAccount, 100);
            _transactionManager.AddTransaction(deposit);

            Assert.IsTrue(_transactionManager.HasPendingTransactions);
            Assert.AreEqual(0, sumonAccount.Balance);

            _transactionManager.ProcessPendingTransactions();

            Assert.IsFalse(_transactionManager.HasPendingTransactions);
            Assert.AreEqual(100, sumonAccount.Balance);
            Withdraw withdrawal = new Withdraw(sumonAccount, 50);
            _transactionManager.AddTransaction(withdrawal);

            _transactionManager.ProcessPendingTransactions();

            Assert.IsFalse(_transactionManager.HasPendingTransactions);
            Assert.AreEqual(50, sumonAccount.Balance);
        }

        [TestMethod]
        public void Test_WithDrawRequestForAmountGreaterThanAvailableBalance_TransactionExecutedWhenBalanceConstrainMet()
        {
            Account sumonAccount = new Account("Sumon", 75);
            _transactionManager.AddTransaction(new Withdraw(sumonAccount, 100));
            Assert.AreEqual(75, sumonAccount.Balance);

            _transactionManager.AddTransaction(new Deposit(sumonAccount, 75));

            _transactionManager.ProcessPendingTransactions();
            Assert.IsTrue(_transactionManager.HasPendingTransactions);
            Assert.AreEqual(150, sumonAccount.Balance);
            _transactionManager.ProcessPendingTransactions();

            Assert.IsFalse(_transactionManager.HasPendingTransactions);
            Assert.AreEqual(50, sumonAccount.Balance);

        }

        [TestMethod]
        public void Test_TransferRequestForAmountGreaterThanAvailableBalance_TransactionExecutedWhenBalanceConstrainMet()
        {

            var firstAccount = new Account("First Account", 100);
            var anotherAccount = new Account("Another Account", 2000);

            var transferTransaction = new Transfer(firstAccount, anotherAccount, 700);
            _transactionManager.AddTransaction(transferTransaction);
            _transactionManager.ProcessPendingTransactions();
            Assert.AreEqual(100, firstAccount.Balance);
            Assert.AreEqual(2000, anotherAccount.Balance);

            var depositTRansaction = new Deposit(firstAccount, 900);
            _transactionManager.AddTransaction(depositTRansaction);

            _transactionManager.ProcessPendingTransactions();
            Assert.AreEqual(1000, firstAccount.Balance);

            _transactionManager.ProcessPendingTransactions();
            Assert.AreEqual(300, firstAccount.Balance);
            Assert.AreEqual(2700, anotherAccount.Balance);
        }

       

        [TestMethod]
        public void Test_Transfer_ThenRollback_AccountStatusRegainedItsInitialState()
        {
           
            var firstAccount = new Account("First Account", 2000);
            var anotherAccount = new Account("Another Account", 100);

            var transferTransaction = new Transfer(firstAccount, anotherAccount, 700);
            _transactionManager.AddTransaction(transferTransaction);

            _transactionManager.ProcessPendingTransactions();

            Assert.AreEqual(1300, firstAccount.Balance);
            Assert.AreEqual(800, anotherAccount.Balance);
            var withdrawTransaction = new Withdraw(anotherAccount, 600);
            _transactionManager.AddTransaction(withdrawTransaction);

            _transactionManager.ProcessPendingTransactions();
            Assert.AreEqual(1300, firstAccount.Balance);
            Assert.AreEqual(200, anotherAccount.Balance);

            _transactionManager.RollbackTransaction(transferTransaction.TransactionId);
            _transactionManager.ProcessPendingTransactions();
            _transactionManager.RollbackTransaction(withdrawTransaction.TransactionId);
            _transactionManager.ProcessPendingTransactions();
            _transactionManager.ProcessPendingTransactions();

            Assert.AreEqual(2000, firstAccount.Balance);
            Assert.AreEqual(100, anotherAccount.Balance);


        }

    }
}
