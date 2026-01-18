using System;
using System.Collections.Generic;

namespace BANKA
{
    public class Account
    {
        public int ID { get; set; }
        public string MenoPriezvisko { get; set; }
        public string Heslo { get; set; }
        public decimal Zostatok { get; set; }
        public List<string> HistoriaPrevodov { get; set; }
        public Account(int id, string menoPriezvisko, string heslo, decimal pociatocnyZostatok)
        {
            ID = id;
            MenoPriezvisko = menoPriezvisko;
            Heslo = heslo;
            Zostatok = pociatocnyZostatok;
            HistoriaPrevodov = new List<string>();

            HistoriaPrevodov.Add($"Vklad pri zalozeni uctu: + {pociatocnyZostatok} EUR");
        }
    }
}
















