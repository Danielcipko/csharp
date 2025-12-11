using System;
using System.Collections.Generic;

namespace Finance_Manager
{
    public class Account
    {
        internal int Id;

        public string Username { get; set; }
        public string Type { get; set; } //"Bežný", "Sporiaci"
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Account(string username, string type, decimal balance, int userId)
        {
            Username = username;
            Type = type;
            Balance = balance;
            UserId = userId;
        }
    }
}
