using System;
using System.Collections.Generic;
using System.Linq;

namespace BANKA
{
    public class Bank
    {
        // Zoznam v ktorom su ulozene vsetky ucty
        private static List<Account> zoznamUctov = new List<Account>();

        // Premenna pre ulozenie ID prihlaseneho pouzivatela
        private static Account prihlasenyUcet = null;

        // Pocitadlo pre generovanie ID uctov (zaciname napr. od 1000)
        private static int noveID = 1000;

        public void StartBank()
        {

            // Hlavny cyklus
            while (true)
            {
                if (prihlasenyUcet == null)
                {
                    // Uzivatel nie je prihlaseny = zobrazi sa uvodne menu
                    UvodneMenu();
                }
                else
                {
                    // Uzivatel je prihlaseny = zobrazi sa menu aplikacie
                    BankoveMenu();
                }
            }
        }

        // --- Metody pre Menu a Prihlasovanie ---

        static void UvodneMenu()
        {
            Console.Clear(); // Vymazanie obrazovky
            Console.WriteLine("=====================================");
            Console.WriteLine("    Vitajte v Mojom Bankovom Systeme");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Prihlasenie");
            Console.WriteLine("2. Zalozenie noveho uctu");
            Console.WriteLine("3. Zabudnute heslo (Obnovenie)");
            Console.WriteLine("4. Zobrazit zoznam vsetkych ID ");
            Console.WriteLine("5. Ukoncit program");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Zvolte moznost: ");

            string volba = Console.ReadLine();

            switch (volba)
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
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nNeplatna volba. Stlacte Enter pre pokracovanie...");
                    Console.ReadLine();
                    break;
            }
        }

        static void Prihlasenie()
        {
            Console.Clear();
            Console.WriteLine("--- Prihlasenie ---");

            Console.WriteLine("Zadajte ID uctu (cislo): ");
            if (!int.TryParse(Console.ReadLine(), out int idUctu))
            {
                Console.WriteLine("Neplatny format ID. Stlacte Enter.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Zadajte heslo: ");
            string heslo = Console.ReadLine();

            // Hladanie uctu v zozname podla ID
            Account ucet = zoznamUctov.FirstOrDefault(u => u.ID == idUctu);

            if (ucet != null && ucet.Heslo == heslo)
            {
                prihlasenyUcet = ucet; // Uspesne prihlasenie
                Console.WriteLine("\nPrihlasenie uspesne! Vitajte, " + ucet.MenoPriezvisko + ".");
            }
            else
            {
                Console.WriteLine("\nChybne ID alebo heslo!");
            }
            Console.WriteLine("Stlacte Enter pre pokracovanie...");
            Console.ReadLine();
        }

        static void ZalozenieUctu()
        {
            Console.Clear();
            Console.WriteLine("--- Zalozenie Noveho Uctu ---");

            Console.WriteLine("Zadajte Vase meno a priezvisko: ");
            string meno = Console.ReadLine();

            Console.WriteLine("Zadajte nove heslo: ");
            string heslo = Console.ReadLine();

            Console.WriteLine("Pociatocny vklad (min. 10 EUR): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal vklad) || vklad < 10)
            {
                Console.WriteLine("Neplatny vklad. Musi byt aspon 10 EUR.");
                Console.WriteLine("Stlacte Enter pre navrat do menu.");
                Console.ReadLine();
                return;
            }

            // Vytvorenie noveho uctu a pridelenie ID
            Account novyUcet = new Account(noveID, meno, heslo, vklad);
            zoznamUctov.Add(novyUcet);
            noveID++; // Zvysenie pre dalsi ucet

            Console.WriteLine($"\nUcet bol uspesne zalozeny!");
            Console.WriteLine($"Vase prihlasovacie ID je: {novyUcet.ID}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Stlacte Enter pre pokracovanie...");
            Console.ReadLine();
        }

        static void ObnovenieHesla()
        {
            Console.Clear();
            Console.WriteLine("--- Zabudnute Heslo (Obnovenie) ---");

            Console.WriteLine("Zadajte ID uctu (cislo): ");
            if (!int.TryParse(Console.ReadLine(), out int idUctu))
            {
                Console.WriteLine("Neplatny format ID. Stlacte Enter.");
                Console.ReadLine();
                return;
            }

            Account ucet = zoznamUctov.FirstOrDefault(u => u.ID == idUctu);

            if (ucet == null)
            {
                Console.WriteLine("Ucet s danym ID neexistuje.");
            }
            else
            {
                Console.WriteLine($"Zadajte vase meno a priezvisko ({ucet.MenoPriezvisko}): ");
                string zadaneMeno = Console.ReadLine();

                if (zadaneMeno.Equals(ucet.MenoPriezvisko, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Zadajte nove heslo: ");
                    ucet.Heslo = Console.ReadLine();
                    Console.WriteLine("\nHeslo bolo uspesne zmenene!");
                }
                else
                {
                    Console.WriteLine("Meno/Priezvisko nesedi, obnova hesla zrusena.");
                }
            }
            Console.WriteLine("Stlacte Enter pre pokracovanie...");
            Console.ReadLine();
        }

        static void ZobrazVsetkyID()
        {
            Console.Clear();
            Console.WriteLine("--- Zoznam vsetkych ID a Mien ---");
            if (zoznamUctov.Count == 0)
            {
                Console.WriteLine("Zatial nebol zalozeny ziaden ucet.");
            }
            else
            {
                foreach (var ucet in zoznamUctov)
                {
                    Console.WriteLine($"ID: {ucet.ID} | Meno: {ucet.MenoPriezvisko} | Heslo: {ucet.Heslo}");
                }
            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Stlacte Enter pre navrat do menu.");
            Console.ReadLine();
        }

        // --- Metody pre Prihlaseneho Uzivatela ---

        static void BankoveMenu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine($"    Vitajte, {prihlasenyUcet.MenoPriezvisko}");
            Console.WriteLine($"    ID uctu: {prihlasenyUcet.ID}");
            Console.WriteLine("=====================================");
            Console.WriteLine($"Aktualny zostatok: {prihlasenyUcet.Zostatok:N2} EUR");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. Vklad (Pripisanie penazi)");
            Console.WriteLine("2. Vyber (Odpisanie penazi)");
            Console.WriteLine("3. Prevod na iny ucet");
            Console.WriteLine("4. Zobrazit historiu transakcii");
            Console.WriteLine("5. Odhlasit sa");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Zvolte moznost: ");

            string volba = Console.ReadLine();

            switch (volba)
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
                    prihlasenyUcet = null; // Odhlasenie
                    Console.WriteLine("\nBoli ste uspesne odhlaseny. Stlacte Enter.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nNeplatna volba. Stlacte Enter pre pokracovanie...");
                    Console.ReadLine();
                    break;
            }
        }

        static void Vklad()
        {
            Console.Clear();
            Console.WriteLine("--- Vklad na Ucet ---");
            Console.WriteLine("Zadajte sumu pre vklad: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal suma) && suma > 0)
            {
                prihlasenyUcet.Zostatok += suma;
                prihlasenyUcet.HistoriaPrevodov.Add($"Vklad na ucet: +{suma:N2} EUR ({DateTime.Now.ToShortDateString()})");
                Console.WriteLine($"\nUspesne vlozenych {suma:N2} EUR.");
                Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR.");
            }
            else
            {
                Console.WriteLine("\nNeplatna suma pre vklad.");
            }
            Console.WriteLine("Stlacte Enter pre pokracovanie...");
            Console.ReadLine();
        }

        static void Vyber()
        {
            Console.Clear();
            Console.WriteLine("--- Vyber z Uctu ---");
            Console.WriteLine("Zadajte sumu pre vyber: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal suma) && suma > 0)
            {
                if (prihlasenyUcet.Zostatok >= suma)
                {
                    prihlasenyUcet.Zostatok -= suma;
                    prihlasenyUcet.HistoriaPrevodov.Add($"Vyber z uctu: -{suma:N2} EUR ({DateTime.Now.ToShortDateString()})");
                    Console.WriteLine($"\nUspesne vybranych {suma:N2} EUR.");
                    Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR.");
                }
                else
                {
                    Console.WriteLine("\nNedostatocny zostatok na ucte!");
                }
            }
            else
            {
                Console.WriteLine("\nNeplatna suma pre vyber.");
            }
            Console.WriteLine("Stlacte Enter pre pokracovanie...");
            Console.ReadLine();
        }

        static void Prevod()
        {
            Console.Clear();
            Console.WriteLine("--- Prevod na Iny Ucet ---");

            Console.WriteLine("Zadajte ID uctu prijemcu (cislo): ");
            if (!int.TryParse(Console.ReadLine(), out int idPrijemcu))
            {
                Console.WriteLine("Neplatny format ID prijemcu. Stlacte Enter.");
                Console.ReadLine();
                return;
            }

            // Kontrola, ci uzivatel neprevadza peniaze sebe
            if (prihlasenyUcet.ID == idPrijemcu)
            {
                Console.WriteLine("Nemozete poslat peniaze sam sebe!");
                Console.WriteLine("Stlacte Enter.");
                Console.ReadLine();
                return;
            }

            // Najdenie prijemcu
            Account prijemca = zoznamUctov.FirstOrDefault(u => u.ID == idPrijemcu);

            if (prijemca == null)
            {
                Console.WriteLine($"Ucet s ID {idPrijemcu} neexistuje.");
            }
            else
            {
                Console.WriteLine($"Zadajte sumu pre prevod na ucet {prijemca.MenoPriezvisko}: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal suma) && suma > 0)
                {
                    if (prihlasenyUcet.Zostatok >= suma)
                    {
                        // Odpisanie od odosielatela
                        prihlasenyUcet.Zostatok -= suma;
                        prihlasenyUcet.HistoriaPrevodov.Add($"Odoslany prevod (ID: {prijemca.ID}): -{suma:N2} EUR ({DateTime.Now.ToShortDateString()})");

                        // Pripisanie prijemcovi
                        prijemca.Zostatok += suma;
                        prijemca.HistoriaPrevodov.Add($"Prijaty prevod (ID: {prihlasenyUcet.ID}): +{suma:N2} EUR ({DateTime.Now.ToShortDateString()})");

                        Console.WriteLine($"\nUspesne prevedenych {suma:N2} EUR na ucet ID: {prijemca.ID}.");
                        Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR.");
                    }
                    else
                    {
                        Console.WriteLine("\nNedostatocny zostatok na ucte pre prevod!");
                    }
                }
                else
                {
                    Console.WriteLine("\nNeplatna suma pre prevod.");
                }
            }
            Console.WriteLine("Stlacte Enter pre pokracovanie...");
            Console.ReadLine();
        }

        static void ZobrazHistoriu()
        {
            Console.Clear();
            Console.WriteLine("--- Historia Transakcii ---");
            Console.WriteLine($"Ucet ID: {prihlasenyUcet.ID}");
            Console.WriteLine($"Aktualny zostatok: {prihlasenyUcet.Zostatok:N2} EUR");
            Console.WriteLine("---------------------------");

            if (prihlasenyUcet.HistoriaPrevodov.Count == 0)
            {
                Console.WriteLine("Zatial neboli ziadne transakcie.");
            }
            else
            {
                // Zobrazenie transakcii od najnovsej
                foreach (string transakcia in prihlasenyUcet.HistoriaPrevodov.AsEnumerable().Reverse())
                {
                    Console.WriteLine(transakcia);
                }
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("Stlacte Enter pre navrat do menu.");
            Console.ReadLine();
        }
    }
}






    

