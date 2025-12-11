using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager
{
    public class TransactionService
    {
        private static List<Transaction> transactions = new List<Transaction>();
        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }
        public List<Transaction> GetTransactionsByAccountId(int accountId)
        {
            return transactions.Where(t => t.AccountId == accountId).ToList();
        }
    }
}
