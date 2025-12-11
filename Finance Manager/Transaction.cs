using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Manager
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; } //"Príjem", "Výdavok"
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Transaction(int id, int accountId, string type, decimal amount, DateTime date, List<Transaction> transactions)
        {
            Id = id;
            AccountId = accountId;
            Type = type;
            Amount = amount;
            Date = date;
            Transactions = transactions;
           
        }

        public Transaction(object v, object value1, Type type, object value2, DateTime now, object value3)
        {
        }

        public override string ToString()
        {
            return "Id {userId} | {Typ} : {Type} {Amount} Eur";
        }








    }
}
