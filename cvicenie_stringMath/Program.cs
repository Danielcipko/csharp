using System.Security.Cryptography.X509Certificates;

namespace cvicenie_stringMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadaj prve cislo:");
            string numberTxt = Console.ReadLine();
            int number = int.Parse(numberTxt);
            Console.WriteLine("Zadaj druhe cislo:");
            string numberTxt2 = Console.ReadLine();
            int number2 = int.Parse(numberTxt2);

            int sum = Scitanie(number, number2, 1, 2, 5);
            Console.WriteLine(sum);

        }
        public static int Scitanie(int a, int b, int c, int d, int f)
        {
            
                     




            int g = a + b + c + d + f;
            return g;
            
            


            
        }
    }
}
