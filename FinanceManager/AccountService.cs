using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FinanceManager
{
    public class AccountService
    {
        private static 
        List<Account> accounts = new List<Account>();

        public void
        AddAccount(Account account)
        {
            accounts.Add(account);
        }
        public List<Account> GetAccountsByUser(int userId)
        {
            List<Account> userAccounts = new List<Account>();
            foreach (Account a in accounts)
            {
               if (a.UserId == userId)
               {
                   userAccounts.Add(a);
               }
            }
            return userAccounts;
        }   
        public void UpdateAccountBalance(int accountId, decimal newBalance)
        {
            foreach (Account account in accounts)
                {
                if (account.Id == accountId)
                {
                    account.Balance += newBalance;
                    break;
                }
            }
        }
        public Account GetAccount(int id)
        {
            foreach (Account account in accounts)
            {
                if (account.Id == id)
                {
                    return account;
                }
            }
            return null;

        }
    }
}  



 
    

