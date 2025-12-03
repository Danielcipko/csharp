using System.Globalization;
using System.Text.Json;

namespace cvicenie_ukladanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Napis co treba");
            string subor = "osoba.txt";
            string command = Console.ReadLine();
            if (command == "write") 
            {
                Osoba osoba1 = new Osoba( "Igor",  21);
                Osoba osoba2 = new Osoba( "Misko",  25);
                Osoba osoba3 = new Osoba( "Radko",  19);
                List<Osoba> ludia = new List<Osoba>();
                ludia.Add(osoba1);
                ludia.Add(osoba2);
                ludia.Add(osoba3);
                string json = JsonSerializer.Serialize(ludia);
                File.WriteAllText(subor, json);
            }
            if (command == "read")
            {
                if (!File.Exists(subor)) 
                {
                    Console.WriteLine("Subor neexistuje");
                    return;
                }
                string celySuborNacitany = File.ReadAllText(subor);
                List<Osoba> ludia =  JsonSerializer.
                Deserialize<List<Osoba>>(celySuborNacitany);

                foreach (Osoba o in ludia) 
                {
                    Console.WriteLine(o.Meno + " " + o.Vek);
                }  
            }
           

            






        }
    }  
}
