using System;
using System.Data.SqlTypes;

namespace FinanceManager
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; } //"Bežný", "Sporiaci"
        public decimal Balance { get; set; }
        public int UserId { get; set; }




    }
}
