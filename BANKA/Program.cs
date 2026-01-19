using System;
using System.Collections.Generic;
using System.Linq;

namespace BANKA
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Bank bank = new Bank();
            bank.StartBank();
        }
    }
}
