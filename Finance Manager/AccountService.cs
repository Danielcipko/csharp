using System;
using System.Collections.Generic;

namespace Finance_Manager
{
    public class AccountService
    {
        private static List<Account> accounts = new List<Account>();
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
        public List<Account> GetAccountsByUser(int userId)
        {
            List<Account> userAccounts = new List<Account>();
            foreach (Account account in accounts)
            {
                if (account.UserId == userId)
                {
                   userAccounts.Add(account);
                }
            }
            return userAccounts;
        }
        public void UpdateBalance(int accountId, decimal amount) 
        {
           foreach (Account account in accounts)
           {
              if (account.UserId == accountId)
              {
                  account.Balance += amount;
                  break;
              }
           }
        }
        public Account GetAccount(int id)
        {
            foreach (Account account in accounts)
            {
                if (account.UserId == id)
                {
                    return account;
                }
            }
            return null;
        }
    }
}
