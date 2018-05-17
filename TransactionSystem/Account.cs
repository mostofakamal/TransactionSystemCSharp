using System;

namespace TransactionSystem
{
    public class Account
    {
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        public Guid AccountId { get; set; }

        public Account(string ownerName, decimal balance)
        {
            OwnerName = ownerName;
            Balance = balance;
            AccountId = Guid.NewGuid();
        }
    }
}
