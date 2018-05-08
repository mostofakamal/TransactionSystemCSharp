#                                          Design a Simple transaction System


Consider a simple account where account contains information of **Account Owner Name**, **AccountId** and **AccountBalance**. Transaction is an operation on this account. This operation can be Deposit, Withdraw or Transfer. 

* **Deposit**: The deposit operation is depositing an amount to a certain account. For example consider an account with Id# 1 and Owner’s name Mr.X and Balance of 100. If we deposit 50 to this account then new balance turns to be 150.
* **Withdraw**: The withdraw operation is withdrawing an amount from a certain account. For successful withdraw it has to meet the condition :  **withdraw Amount >= Account Balance**.
* **Transfer**: The transfer operation is about transferring an amount from one account (Sender’s Account) to another account (Receiver Account). Of course for transfer sender must have to have enough balance in the account. 

Design a System which supports all the above three operations where operations should be processed sequentially in the order they were added.
 Let us call these operations as Transaction request.
You can use an ordered list or queue for this purpose to store
 these transaction requests. You should be able to add new transaction requests to that List or queue. 
Adding transaction requests to that list/queue will not execute the operation right away rather it would be executed once you call to **ProcessPendingTransactions()** (in class **TransactionManager** ) explicitly which will process the pending operation(transaction) in the list.
Once an operation is processed that should be marked as completed and should
 not be processed in next call (Hint: you can maintain a flag for this purpose for simplicity).  

For example there can be transaction requests like below in the list in the below sequence:

1. Deposit 30 to account X
2. Withdraw 20 from Account X
3. Transfer 10 from account Y to X

If for any reason any transaction request cannot be executed for balance constraints (e.g. withdraw amount is greater than available balance) 
then that transaction request should still be in the list as pending operation and in next run of **ProcessPendingTransactions()** if the balance constraint is met then it should be marked as executed. 

**Taks:**

- Complete the TransactionManager class.
- You should be able to check balance of an account at any point of your program execution.
- Your design should have reusable code component (e.g should support adding new type of transaction with minimal changes) and follow OOP concepts
- Add Unit Tests checking three of the above operations. Add cases for balance constraint operation.
- Add functionality for Undoing a specific Transaction Request which has been executed already. 
