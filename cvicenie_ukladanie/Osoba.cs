using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_ukladanie
{
    public class Osoba
    {
        public string Meno {get ; set;}
         
        public int Vek {get; set;}

        public Osoba (string meno, int vek)
        {
            Meno = meno;
            Vek = vek;
        }
        public string UdajeOddeleneCiarkou()
        {
            string line;
            line = Meno + "," + Vek;
            return line;


        }

    }    
}
