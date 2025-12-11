using System;
using System.Collections.Generic;

namespace Finance_Manager
{
    class Program
    {
        private static AccountService accountService = new AccountService();
        private static TransactionService transactionService = new TransactionService();
        private static object username;
        private const int CurrentUserId = 1;

        public static object Id { get; private set; }

        // HLAVNÁ METÓDA (Vstupný bod)
        static void Main(string[] args)
        {
            Console.WriteLine("--- VITAJTE vo Finančnom manažérovi (Console Edition) ---");

            if (PerformLogin())
            {
                ShowMainMenu();
            }

            Console.WriteLine("\nProgram ukončený. Stlačte Enter.");
            Console.ReadLine();
        }

        // 1. Prihlasovacia logika
        static bool PerformLogin()
        {
            Console.Write("\nZadajte meno (admin): ");
            string username = Console.ReadLine();

            Console.Write("Zadajte heslo (123): ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "123")
            {
                Console.WriteLine("\nPrihlásenie úspešné!");
                return true;
            }
            else
            {
                Console.WriteLine("\nNesprávne údaje. Ukončujem program.");
                return false;
            }
        }

        // 2. Hlavné menu
        static void ShowMainMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("--- HLAVNÉ MENU ---");
                Console.WriteLine("1) Správa účtov (Pridať/Zobraziť)");
                Console.WriteLine("2) Transakcie (Pridať)");
                Console.WriteLine("3) Zobraziť Prehľad (Zostatky/Sumár)");
                Console.WriteLine("4) Koniec");
                Console.Write("Vyberte možnosť (1-4): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ManageAccounts();
                        break;
                    case "2":
                        AddTransaction();
                        break;
                    case "3":
                        ShowOverview();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Neplatná voľba. Skúste znova.");
                        break;
                }
            }
        }

        // 3. Správa účtov
        static void ManageAccounts()
        {
            Console.WriteLine("\n--- SPRÁVA ÚČTOV ---");
            ShowAccounts();

            Console.WriteLine("\nChcete pridať nový účet? (A/N)");
            if (Console.ReadLine().ToUpper() == "A")
            {
                Console.Write("Zadajte názov nového účtu: ");
                string name = Console.ReadLine();

                Console.Write("Zadajte typ účtu (Bežný/Sporiaci): ");
                string type = Console.ReadLine();

                Account newAccount = new Account(name, type, 0, CurrentUserId);

                accountService.AddAccount(newAccount);
                Console.WriteLine($"\nÚčet '{name}' bol úspešne pridaný.");
                ShowAccounts();
            }
        }

        static void ShowAccounts()
        {
            Console.WriteLine("\n--- ZOZNAM ÚČTOV ---");
            List<Account> accounts = accountService.GetAccountsByUser(CurrentUserId);

            if (accounts.Count == 0)
            {
                Console.WriteLine("Zatiaľ nemáte žiadne účty.");
                return;
            }

            foreach (Account account in accounts)
            {
                Console.WriteLine($"ID: {Id} | Názov: {username} ({account.Type}) | Zostatok: {account.Balance:C}");
            }
        }

        // 4. Pridanie transakcie
        static void AddTransaction()
        {
            Console.WriteLine("\n--- PRIDAŤ TRANSAKCIU ---");
            ShowAccounts();

            Console.Write("Zadajte ID účtu pre transakciu: ");
            if (!int.TryParse(Console.ReadLine(), out int accountId))
            {
                Console.WriteLine("Neplatné ID.");
                return;
            }

            Account targetAccount = accountService.GetAccount(accountId);
            if (targetAccount == null)
            {
                Console.WriteLine("Účet s týmto ID neexistuje.");
                return;
            }

            Console.Write("Zadajte typ (Príjem/Výdavok): ");
            string type = Console.ReadLine();
            if (type != "Príjem" && type != "Výdavok")
            {
                Console.WriteLine("Neplatný typ.");
                return;
            }

            Console.Write("Zadajte sumu: ");
            // Kontrola, či je vstup číslo (decimal)
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Neplatná suma.");
                return;
            }

            Console.Write("Zadajte krátky popis: ");
            string description = Console.ReadLine();

            decimal updateAmount = amount;
            if (type == "Výdavok")
            {
                updateAmount *= -1;
            }
            accountService.UpdateBalance(accountId, updateAmount);

            Transaction newTransaction = new Transaction(
                new Random().Next(1000, 9999), // id
                accountId,                     // accountId
                type,                          // type
                amount,                        // amount
                DateTime.Now,                  // date
                null                           // transactions (or new List<Transaction>() if needed)
            );
            transactionService.AddTransaction(newTransaction);

            Console.WriteLine("\nTransakcia úspešne pridaná! Nový zostatok na účte:");
            Console.WriteLine($"{targetAccount.Username}: {targetAccount.Balance:C}");
        }

        // 5. Prehľad (Náhrada grafu)
        static void ShowOverview()
        {
            Console.WriteLine("\n--- FINANČNÝ PREHĽAD (SUMÁR) ---");

            List<Account> accounts = accountService.GetAccountsByUser(CurrentUserId);
            decimal totalBalance = 0;
            decimal totalPrijmy = 0;
            decimal totalVydavky = 0;

            // Celkový zostatok
            foreach (Account acc in accounts)
            {
                totalBalance += acc.Balance;
                Console.WriteLine($"Zostatok {acc.Username}: {acc.Balance:C}");
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"CELKOVÝ ZOSTANOK VŠETKÝCH ÚČTOV: {totalBalance:C}");
            Console.WriteLine("--------------------------------------");

            // Sumár transakcií (náhrada vizuálneho grafu)
            List<Transaction> transactions = transactionService.GetAllTransactions();

            foreach (Transaction t in transactions)
            {
                if (t.Type == "Príjem")
                {
                    totalPrijmy += t.Amount;
                }
                else if (t.Type == "Výdavok")
                {
                    totalVydavky += t.Amount;
                }
            }

            Console.WriteLine("\n--- SUMÁR VŠETKÝCH TRANSAKCIÍ ---");
            Console.WriteLine($"Celkové prijaté príjmy: {totalPrijmy:C}");
            Console.WriteLine($"Celkové výdavky:        {totalVydavky:C}");
            Console.WriteLine($"Čistý zisk/strata:      {(totalPrijmy - totalVydavky):C}");

            Console.WriteLine("\nStlačte Enter pre návrat do menu.");
            Console.ReadLine();
        }
    }
}

        
            







        
    





