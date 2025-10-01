using System;
using System.ComponentModel.Design;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            /*
            int myAge = 15;
            Console.WriteLine(myAge);

            float pi = 3.14f;
            Console.WriteLine(pi);

            string name = "Daniel";
            Console.WriteLine(name);

            char gender = 'M';
            Console.WriteLine(gender);

            bool isAdult = false;
            Console.WriteLine(isAdult); */
            

            //scitavanie A B 
            /*int a = 6; 
            int b = 7;
            int sum = a + b;
            Console.WriteLine(sum);
        

            Console.WriteLine(a - b);
            //odcitavanie
            int sum2 = a - b;
            Console.WriteLine(sum2);


            //nasobenie delenie 
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);

            Console.WriteLine("Daniel");

            /*int birthday = 12;
            int birthMonth = 8;
            int birthYear = 2010;

            int birthsum = birthday + birthMonth + birthYear;

            Console.WriteLine(birthsum);

            Console.WriteLine(birthsum * 10);
            Console.WriteLine((birthday+birthMonth) * birthYear);
            Console.WriteLine(5 / 3);
            Console.WriteLine(5f / 3f);

            string Name = "Daniel";
            int bYear = 2010;*/



            Console.WriteLine("Napis meno");
            string meno = Console.ReadLine();
            string vypis = "Ahoj ";
            Console.WriteLine(vypis + meno);

            Console.WriteLine("Zadaj vek: ");

            string vekText = Console.ReadLine();
            int vek = int.Parse(vekText);
            int birthYear2 = 2025 - vek;
            string vypis2 = "Ahoj " + meno + " narodil si sa v roku " + birthYear2;
            Console.WriteLine(vypis2);
            /*
            if (vek < 18)
            {
                Console.WriteLine("si boss");
            }
            else
            {
                Console.WriteLine("si velky sef");
            }
            */

            /*
            if (birthYear2 > 2000)
            {
                Console.WriteLine("Si narodeny po roku 2000");
            }

            else if (birthYear2 == 2000)
            {
                Console.WriteLine("Si narodeny v roku 2000");
            } 
        
            else 
            {
                Console.WriteLine("Si narodeny pred rokom 2000");
            }




            Console.WriteLine("Zadaj prve cislo");
            string cislo1text = Console.ReadLine();
            int cislo1 = int.Parse(cislo1text);

            Console.WriteLine("Zadaj poctovu operaciu");
            string operacia = Console.ReadLine();

            Console.WriteLine("Zadaj druhe cislo");
            string cislo2text = Console.ReadLine();
            int cislo2 = int.Parse(cislo2text);

            int vysledok = 0;

            if (operacia =="+")
            {
                vysledok = cislo1 + cislo2;

            }
            else if (operacia =="-")
            {
                vysledok = cislo1 - cislo2;
            }
            else if (operacia =="*")
            {
                vysledok = cislo1 * cislo2;
            }
            else if (operacia =="/")
            {
                vysledok = cislo1 / cislo2;
            }
            */












        }
    }
}

























