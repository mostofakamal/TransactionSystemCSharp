using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionSystem;

namespace TransactionSystemTests
{
    [TestClass]
    public class TransactionTests
    {
        private TransactionManager _transactionManager = new TransactionManager();

        [TestMethod]
        public void DepositAccountCheckBalanceAndThenWithdraw_AllTransactionsSuccessful()
        {
            // Create Account with Balance 0
            // Add a deposit reqest of 100 to that account
            // Pre-check : transactionManager Should have pending transactions at this point
            // Account Balance Should be 0 at this point

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // Check : there should not be any pending Transactions now

            // Check balance of the account which should be 100 now

            // Create a Withdraw of 50 on that account

            // Perform a ProcessPendingTransactions() to process this

            // check : No pending Transactions at this point
            // Check balance: should be 100-50 =50
        }

        [TestMethod]
        public void Test_WithDrawRequestForAmountGreaterThanAvailableBalance_TransactionExecutedWhenBalanceConstrainMet()
        {
            // Create account with 75 as initial Balance
            // Add a withdraw request of 100 (exceeding the available balance)
            // Check Balance: should be 75 

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // Add a deposit request to that account of 75

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // check : there should be pending transactions at this point

            // check Balance: should be 150

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // Check: there should be no pending transactions at this point

            // Balance Check : should be 50 (withdraw request of 100 should be successfull at this point)
          
        }

        [TestMethod]
        public void Test_TransferRequestForAmountGreaterThanAvailableBalance_TransactionExecutedWhenBalanceConstrainMet()
        {
            // Create firstAccount with Initial Balance 100
            // Create secondAccount with Initial Balance 2000

            // Create a transfer request of 700 from firstAccount to secondAccount

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // Balance Check : FirstAccount -> 100
            // Balance Check : SecondAccount -> 2000

            // Add a Deposit request of 900 to FirstAccount

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // Balance Check : FirstAccount: 1000

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // Check: there should be no pending transactions at this point
            // Balance Check : FirstAccount -> 300
            // Balance Check : SecondAccount -> 2700
        }

        [TestMethod]
        public void Test_Transfer_ThenRollback_AccountStatusRegainedItsInitialState()
        {
            // Create firstAccount with Initial Balance 2000
            // Create secondAccount with Initial Balance 100

            // Create a transfer request of 700 from firstAccount to secondAccount

            // Run ProcessPendingTransactions() to process Pending TransactionRequests

            // Balance Check : FirstAccount -> 1300
            // Balance Check : SecondAccount -> 800

            // Perform a Rollback with the transaction Id of the transfer which is made

            // Check: there should be no pending transactions at this point
            // Balance Check : FirstAccount -> 2000
            // Balance Check : SecondAccount -> 100
        }

    }
}
