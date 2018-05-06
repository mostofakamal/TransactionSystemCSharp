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
           
        }

        [TestMethod]
        public void Test_WithDrawRequestForAmountGreaterThanAvailableBalance_TransactionExecutedWhenBalanceConstrainMet()
        {
         
        }

        [TestMethod]
        public void Test_TransferRequestForAmountGreaterThanAvailableBalance_TransactionExecutedWhenBalanceConstrainMet()
        {

        }

        [TestMethod]
        public void Test_Transfer_ThenRollback_AccountStatusRegainedItsInitialState()
        {
            
        }
    }
}
