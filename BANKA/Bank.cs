using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BANKA
{
    public class Bank
    {
        // zoznam v ktorom su ulozene vsetky ucty
        private static List<Account> zoznamUctov = new List<Account>();

        // premenna pre ulozenie ID prihlaseneho pouzivatela
        private static Account prihlasenyUcet = null;

        // pocitadlo pre generovanie ID uctov 
        private static int noveID = 1000;

        public void StartBank()
        {

            // hlavny cyklus
            while (true)
            {
                if (prihlasenyUcet == null)
                {
                    // uzivatel nie je prihlaseny = zobrazi sa uvodne menu
                    UvodneMenu();
                }
                else
                {
                    // uzivatel je prihlaseny = zobrazi sa menu aplikacie
                    BankoveMenu();
                }
            }
        }

        // metody pre menu a prihlasovanie

        static void UvodneMenu()
        {
            Console.Clear(); // vymazanie obrazovky (pomoc CHATGPT)
            Console.WriteLine("=====================================");
            Console.WriteLine("    Vitajte v R&D Bank");
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
                    Environment.Exit(0);    // (pomoc CHATGPT)
                    break;
                default:
                    Console.WriteLine("Neplatna volba. Stlacte Enter pre pokracovanie...");
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

            // hladanie uctu v zozname podla ID
            Account ucet = zoznamUctov.FirstOrDefault(u => u.ID == idUctu);

            if (ucet != null && ucet.Heslo == heslo)
            {
                prihlasenyUcet = ucet; // uspesne prihlasenie
                Console.WriteLine("Prihlasenie uspesne! Vitajte, " + ucet.MenoPriezvisko + ".");
            }
            else
            {
                Console.WriteLine("Chybne ID alebo heslo!");
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

            // vytvorenie noveho uctu a pridelenie ID uzivatelovi
            Account novyUcet = new Account(noveID, meno, heslo, vklad);
            zoznamUctov.Add(novyUcet);
            noveID++; // zvysenie pre dalsi ucet

            Console.WriteLine($"Ucet bol uspesne zalozeny!");
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

                if (zadaneMeno.Equals(ucet.MenoPriezvisko, StringComparison.OrdinalIgnoreCase)) // pomoc CHATGPT (OrdinalIgnoreCase)
                {
                    Console.WriteLine("Zadajte nove heslo: ");
                    ucet.Heslo = Console.ReadLine();
                    Console.WriteLine("Heslo bolo uspesne zmenene!");
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

        // metody pre prihlaseneho uzivatela

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
                    prihlasenyUcet = null; // odhlasenie
                    Console.WriteLine("Boli ste uspesne odhlaseny. Stlacte Enter.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Neplatna volba. Stlacte Enter pre pokracovanie...");
                    Console.ReadLine();
                    break;
            }
        }

        static void Vklad()
        {
            Console.Clear();
            Console.WriteLine("--- Vklad na Ucet ---");
            Console.WriteLine("Zadajte sumu pre vklad: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal suma) && suma > 0)    // (decimal sluzi na pracu s desatinymi cislami (co najpresnejsie hodnoty))
            {
                prihlasenyUcet.Zostatok += suma;
                prihlasenyUcet.HistoriaPrevodov.Add($"Vklad na ucet: +{suma:N2} EUR ({DateTime.Now.ToShortDateString()})");
                Console.WriteLine($"Uspesne vlozenych {suma:N2} EUR.");
                Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR.");
            }
            else
            {
                Console.WriteLine("Neplatna suma pre vklad.");
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
                    Console.WriteLine($"Uspesne vybranych {suma:N2} EUR.");
                    Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR.");
                }
                else
                {
                    Console.WriteLine("Nedostatocny zostatok na ucte!");
                }
            }
            else
            {
                Console.WriteLine("Neplatna suma pre vyber.");
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

            // ˇkontrola ci uzivatel neprevadza peniaze sebe
            if (prihlasenyUcet.ID == idPrijemcu)
            {
                Console.WriteLine("Nemozete poslat peniaze sam sebe!");
                Console.WriteLine("Stlacte Enter.");
                Console.ReadLine();
                return;
            }

            // najdenie prijemcu
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
                        // odpisanie od odosielatela
                        prihlasenyUcet.Zostatok -= suma;
                        prihlasenyUcet.HistoriaPrevodov.Add($"Odoslany prevod (ID: {prijemca.ID}): -{suma:N2} EUR ({DateTime.Now.ToShortDateString()})");

                        // pripisanie prijemcovi
                        prijemca.Zostatok += suma;
                        prijemca.HistoriaPrevodov.Add($"Prijaty prevod (ID: {prihlasenyUcet.ID}): +{suma:N2} EUR ({DateTime.Now.ToShortDateString()})");

                        Console.WriteLine($"Uspesne prevedenych {suma:N2} EUR na ucet ID: {prijemca.ID}.");
                        Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR.");
                    }
                    else
                    {
                        Console.WriteLine("Nedostatocny zostatok na ucte pre prevod!");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatna suma pre prevod.");
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
                // zobrazenie transakcii od najnovsej
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






    

