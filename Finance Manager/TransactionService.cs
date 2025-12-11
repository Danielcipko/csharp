
using System;
using System.Collections.Generic;

namespace Finance_Manager
{
    public class TransactionService
    {
        private Account _account;

        public TransactionService()
        {
        }

        public TransactionService(Account account)
        {
            _account = account;
            
        }
        public List<string>GetHistory()
        {
           List<string> history = new List<string>();
           foreach (var transaction in _account.Transactions)
           {
               history.Add(transaction.ToString());
           }
              return history;
        }

        internal void AddTransaction(Transaction newTransaction)
        {
            throw new NotImplementedException();
        }

        internal List<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
        }   
    }
}
