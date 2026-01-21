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
        private static int noveID = 999-1500;
        private static bool programBezi = true;
        private static string heslo;
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
            Console.WriteLine("        VITAJTE V R&D BANKE          ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Prihlasenie");
            Console.WriteLine("2. Zalozenie noveho uctu");
            Console.WriteLine("3. Obnovenie hesla");
            Console.WriteLine("4. Zobrazit zoznam ID");
            Console.WriteLine("5. Ukoncit program");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Zvolte moznost:");
            


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
                    Chyba();
                    break;
            }
        }

        static void Prihlasenie()
        {
            Console.Clear();
            Console.WriteLine("--- Prihlasenie ---");

            Console.WriteLine("Zadajte ID uctu: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Chyba("Neplatny format ID.");
                return;
            }

            Console.WriteLine("Zadajte heslo: ");
            string heslo = Console.ReadLine();

            Account ucet = zoznamUctov.FirstOrDefault(u => u.ID == id); //POMOC CHAT GPT-(FirstOrDefault) PREJDE ZOZNAM UCOTV A VRATI UCET S ROVNAKYM ID AK NIE, VRATI NULL 

            if (ucet != null && ucet.Heslo == heslo)
            {
                prihlasenyUcet = ucet;
                Console.WriteLine($"Prihlasenie uspesne. Vitajte, {ucet.MenoPriezvisko}.");
            }
            else
            {
                Console.WriteLine("Chybne ID alebo heslo.");
            }

            StlacteEnter();
        }

        static void ZalozenieUctu()
        {
            Console.Clear();
            Console.WriteLine("--- Zalozenie Noveho Uctu ---");

            Console.WriteLine("Zadajte Vase meno a priezvisko: ");
            string meno = Console.ReadLine();
            Console.WriteLine("Heslo: ");
            string heslo = Console.ReadLine();

            bool Spravnemeno = true;
            foreach (char znak in meno)
            {
                if (!char.IsLetter(znak) && znak != ' ')
                {
                    Spravnemeno = false;
                    break;
                }
            }

            if (!Spravnemeno || meno.Length == 0)
            {
                Console.WriteLine("Chyba! Meno nesmie obsahovat cisla.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Pociatocny vklad (min. 10 EUR): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal vklad) || vklad < 10)
            {
                Console.WriteLine("Neplatny vklad. Musi byt aspon 10 EUR.");
                Console.WriteLine("Stlacte Enter pre navrat do menu.");
                Console.ReadLine();
                return;
            }

           
            Console.WriteLine("Vyber ID uctu:");
            Console.WriteLine("1. Chcem si zvolit vlastne ID");
            Console.WriteLine("2. Chcem automaticky (random) pridelene ID");
            Console.WriteLine("Zvolte moznost: ");
            string volbaID = Console.ReadLine();

            int idUctu;

            if (volbaID == "1")
            {
                Console.WriteLine("Zadajte vlastne ID (cislo): ");
                if (!int.TryParse(Console.ReadLine(), out idUctu))
                {
                    Console.WriteLine("Neplatny format ID.");
                    Console.ReadLine();
                    return;
                }

                
                if (zoznamUctov.Any(u => u.ID == idUctu))
                {
                    Console.WriteLine("Toto ID uz existuje.Vyberte ine ID.");
                    Console.ReadLine();
                    return;
                }
            }
            else if (volbaID == "2")
            {
                idUctu = VygenerujRandomID();
            }
            else
            {
                Console.WriteLine("Neplatna volba.");
                Console.ReadLine();
                return;
            }

            Account novyUcet = new Account(idUctu, meno, heslo, vklad)
            {
                HistoriaPrevodov = new List<string>()
            }
            ;
            zoznamUctov.Add(novyUcet);

            Console.WriteLine("Ucet bol uspesne zalozeny!");
            Console.WriteLine($"Vase prihlasovacie ID je: {novyUcet.ID}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Stlacte Enter pre pokracovanie...");
            Console.ReadLine();
        }

        static void ObnovenieHesla()
        {
            Console.Clear();
            Console.WriteLine("--- Obnovenie Hesla ---");

            Console.WriteLine("Zadajte ID uctu: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) // METODA (TrypParse) SA POKUSI PREMENIT VSTUP NA INTEGER, AK SA TO PODARI, VRATI TRUE A HODNOTU PRIRADI DO PREMENNEJ ID
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

                if (meno.Equals(ucet.MenoPriezvisko, StringComparison.OrdinalIgnoreCase)) // PODMIENKA IF SA VYKONA LEN AK SA MENO ZHODUJE S MENOM V UCTE
                {
                    Console.WriteLine("Zadajte nove heslo: ");
                    ucet.Heslo = Console.ReadLine();
                    Console.WriteLine("Vase heslo bolo uspesne zmenene.");
                }
                else
                {
                    Console.WriteLine("Meno sa nezhoduje.");
                }
            }

            StlacteEnter();
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

            StlacteEnter();
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
                    Chyba();
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
            StlacteEnter();
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
            StlacteEnter
                ();
        }

        static void Prevod()
        {
            Console.Clear();
            Console.WriteLine("--- Prevod na iny ucet ---");

            Console.WriteLine("Zadajte ID prijemcu: ");
            if (!int.TryParse(Console.ReadLine(), out int idPrijemcu))
            {
                Console.WriteLine("Neplatne ID.");
                StlacteEnter();
                return;
            }

            if (idPrijemcu == prihlasenyUcet.ID)
            {
                Console.WriteLine("Nemozete poslat peniaze sam sebe.");
                StlacteEnter();
                return;
            }

            Account prijemca = zoznamUctov.FirstOrDefault(u => u.ID == idPrijemcu);

            if (prijemca == null)
            {
                Console.WriteLine("Ucet s danym ID neexistuje.");
                StlacteEnter();
                return;
            }

            Console.WriteLine("Zadajte sumu prevodu: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal suma) || suma <= 0)
            {
                Console.WriteLine("Neplatna suma.");
                StlacteEnter();
                return;
            }

            if (prihlasenyUcet.Zostatok < suma)
            {
                Console.WriteLine("Nedostatocny zostatok na ucte.");
                StlacteEnter();
                return;
            }

            // PREVOD
            prihlasenyUcet.Zostatok -= suma;
            prijemca.Zostatok += suma;

            // HISTORIA PREVODOV
            prihlasenyUcet.HistoriaPrevodov.Add(
                $"Prevod -> ID {prijemca.ID}: -{suma:N2} EUR ({DateTime.Now:dd.MM.yyyy HH:mm})");

            prijemca.HistoriaPrevodov.Add(
                $"Prevod <- ID {prihlasenyUcet.ID}: +{suma:N2} EUR ({DateTime.Now:dd.MM.yyyy HH:mm})");

            Console.WriteLine("Prevod bol uspesne vykonany.");
            Console.WriteLine($"Novy zostatok: {prihlasenyUcet.Zostatok:N2} EUR");

            StlacteEnter();
        }

        static void StlacteEnter()
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

            StlacteEnter();
        }

        static void Chyba()
        {
            Console.WriteLine("Neplatna volba. Skuste znova prosim.");
            StlacteEnter();
        }

        static void Chyba(string sprava)
        {
            Console.WriteLine(sprava);
            StlacteEnter();
        }

        
        private static int VygenerujRandomID()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next(1000, 9999); 
            }   while (zoznamUctov.Any(u => u.ID == id)); // METODA ANY SA PYTA CI TAM EXISTUJE ASPON JEDEN UCET KTORY SPLNA PODMIENKU
            return id;
        } 
    }  
}

































































































































