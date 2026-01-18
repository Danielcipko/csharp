using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BANKA
{

    public class Bank
    {
        private static List<Account> zoznamUctov = new List<Account>();
        private static Account prihlasenyUcet = null;
        private static int noveID = 1000;
        private static bool programBezi = true;

        public void StartBank()
        {
            while (programBezi)
            {
                if (prihlasenyUcet == null)
                    UvodneMenu();
                else
                    BankoveMenu();
            }
        }

        static void UvodneMenu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("        Vitajte v R&D Bank");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Prihlasenie");
            Console.WriteLine("2. Zalozenie noveho uctu");
            Console.WriteLine("3. Obnovenie hesla");
            Console.WriteLine("4. Zobrazit zoznam ID");
            Console.WriteLine("5. Ukoncit program");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Zvolte moznost: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Prihlasenie();
                    break;
                case "2":
                    ZalozenieUctu();
                    break;
                case "3":
                    ObnovenieHesla();
                    break;
                case "4":
                    ZobrazVsetkyID();
                    break;
                case "5":
                    programBezi = false;
                    break;
                default:
                    ChybaVolby();
                    break;
            }
        }

        static void Prihlasenie()
        {
            Console.Clear();
            Console.WriteLine("--- Prihlasenie ---");

            Console.Write("Zadajte ID uctu: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Chyba("Neplatny format ID.");
                return;
            }

            Console.WriteLine("Zadajte heslo: ");
            string heslo = Console.ReadLine();

            Account ucet = zoznamUctov.FirstOrDefault(u => u.ID == id);

            if (ucet != null && ucet.Heslo == heslo)
            {
                prihlasenyUcet = ucet;
                Console.WriteLine($"Prihlasenie uspesne. Vitajte, {ucet.MenoPriezvisko}.");
            }
            else
            {
                Console.WriteLine("Chybne ID alebo heslo.");
            }

            CakajNaEnter();
        }

        static void ZalozenieUctu()
        {
            Console.Clear();
            Console.WriteLine("--- Zalozenie Uctu ---");

            Console.WriteLine("Meno a priezvisko: ");
            string meno = Console.ReadLine();

            Console.Write("Heslo: ");
            string heslo = Console.ReadLine();

            Console.WriteLine("Pociatocny vklad (min. 10 EUR): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal vklad) || vklad < 10)
            {
                Chyba("Minimalny vklad je 10 EUR.");
                return;
            }

            Account ucet = new Account(noveID++, meno, heslo, vklad);
            zoznamUctov.Add(ucet);

            Console.WriteLine("Ucet bol uspesne vytvoreny.");
            Console.WriteLine($"Vase ID: {ucet.ID}");
            CakajNaEnter();
        }

        static void ObnovenieHesla()
        {
            Console.Clear();
            Console.WriteLine("--- Obnovenie Hesla ---");

            Console.WriteLine("Zadajte ID uctu: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Chyba("Neplatne ID.");
                return;
            }

            Account ucet = zoznamUctov.FirstOrDefault(u => u.ID == id);

            if (ucet == null)
            {
                Console.WriteLine("Ucet neexistuje.");
            }
            else
            {
                Console.WriteLine("Zadajte meno a priezvisko: ");
                string meno = Console.ReadLine();

                if (meno.Equals(ucet.MenoPriezvisko, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Zadajte nove heslo: ");
                    ucet.Heslo = Console.ReadLine();
                    Console.WriteLine("Heslo bolo zmenene.");
                }
                else
                {
                    Console.WriteLine("Meno nesedi.");
                }
            }

            CakajNaEnter();
        }

        static void ZobrazVsetkyID()
        {
            Console.Clear();
            Console.WriteLine("--- Zoznam Uctov ---");

            if (zoznamUctov.Count == 0)
            {
                Console.WriteLine("Ziadne ucty neexistuju.");
            }
            else
            {
                foreach (var ucet in zoznamUctov)
                {
                    Console.WriteLine($"ID: {ucet.ID} | Meno: {ucet.MenoPriezvisko}");
                }
            }

            CakajNaEnter();
        }

        static void BankoveMenu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine($"Prihlaseny: {prihlasenyUcet.MenoPriezvisko}");
            Console.WriteLine($"ID uctu: {prihlasenyUcet.ID}");
            Console.WriteLine($"Zostatok: {prihlasenyUcet.Zostatok:N2} EUR");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Vklad");
            Console.WriteLine("2. Vyber");
            Console.WriteLine("3. Prevod");
            Console.WriteLine("4. Historia");
            Console.WriteLine("5. Odhlasit sa");
            Console.WriteLine("Volba: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Vklad();
                    break;
                case "2":
                    Vyber();
                    break;
                case "3":
                    Prevod();
                    break;
                case "4":
                    ZobrazHistoriu();
                    break;
                case "5":
                    prihlasenyUcet = null;
                    break;
                default:
                    ChybaVolby();
                    break;
            }
        }

        static void Vklad()
        {
            Console.Clear();
            Console.WriteLine("Suma vkladu: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal suma) && suma > 0)
            {
                prihlasenyUcet.Zostatok += suma;
                prihlasenyUcet.HistoriaPrevodov.Add($"+{suma:N2} EUR ({DateTime.Now:dd.MM.yyyy HH:mm})");
                Console.WriteLine("Vklad uspesny.");
            }
            else
            {
                Console.WriteLine("Neplatna suma.");
            }
            CakajNaEnter();
        }

        static void Vyber()
        {
            Console.Clear();
            Console.WriteLine("Suma vyberu: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal suma) && suma > 0 && suma <= prihlasenyUcet.Zostatok)
            {
                prihlasenyUcet.Zostatok -= suma;
                prihlasenyUcet.HistoriaPrevodov.Add($"-{suma:N2} EUR ({DateTime.Now:dd.MM.yyyy HH:mm})");
                Console.WriteLine("Vyber uspesny.");
            }
            else
            {
                Console.WriteLine("Nedostatocny zostatok alebo neplatna suma.");
            }
            CakajNaEnter
                ();
        }

        static void Prevod()
        {
            Console.Clear();
            Console.WriteLine("--- Prevod na iny ucet ---");

            Console.Write("Zadajte ID prijemcu: ");
            if (!int.TryParse(Console.ReadLine(), out int idPrijemcu))
            {
                Console.WriteLine("Neplatne ID.");
                CakajNaEnter();
                return;
            }

            if (idPrijemcu == prihlasenyUcet.ID)
            {
                Console.WriteLine("Nemozete poslat peniaze sam sebe.");
                CakajNaEnter();
                return;
            }

            Account prijemca = zoznamUctov.FirstOrDefault(u => u.ID == idPrijemcu);

            if (prijemca == null)
            {
                Console.WriteLine("Ucet s danym ID neexistuje.");
                CakajNaEnter();
                return;
            }

            Console.Write("Zadajte sumu prevodu: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal suma) || suma <= 0)
            {
                Console.WriteLine("Neplatna suma.");
                CakajNaEnter();
                return;
            }

            if (prihlasenyUcet.Zostatok < suma)
            {
                Console.WriteLine("Nedostatocny zostatok na ucte.");
                CakajNaEnter();
                return;
            }

            // PREVOD
            prihlasenyUcet.Zostatok -= suma;
            prijemca.Zostatok += suma;

            // HISTORIA
            prihlasenyUcet.HistoriaPrevodov.Add(
                $"Prevod -> ID {prijemca.ID}: -{suma:N2} EUR ({DateTime.Now:dd.MM.yyyy HH:mm})");

            prijemca.HistoriaPrevodov.Add(
                $"Prevod <- ID {prihlasenyUcet.ID}: +{suma:N2} EUR ({DateTime.Now:dd.MM.yyyy HH:mm})");

            Console.WriteLine("Prevod bol uspesne vykonany.");
            Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR");

            CakajNaEnter();
        }

        static void CakajNaEnter()
        {
            Console.WriteLine("Pokračujte stlačením ENTER...");
            Console.ReadLine();
        }

        static void ZobrazHistoriu()
        {
            Console.Clear();
            Console.WriteLine("--- Historia prevodov ---");

            if (prihlasenyUcet.HistoriaPrevodov == null || prihlasenyUcet.HistoriaPrevodov.Count == 0)
            {
                Console.WriteLine("Ziadne zaznamy v historii.");
            }
            else
            {
                foreach (var zaznam in prihlasenyUcet.HistoriaPrevodov)
                {
                    Console.WriteLine(zaznam);
                }
            }

            CakajNaEnter();
        }

        static void ChybaVolby()
        {
            Console.WriteLine("Neplatna volba. Skuste znova.");
            CakajNaEnter();
        }

        static void Chyba(string sprava)
        {
            Console.WriteLine(sprava);
            CakajNaEnter();
        }
    }
}

















