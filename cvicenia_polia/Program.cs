using System.Diagnostics.CodeAnalysis;

namespace cvicenia_polia
{
    internal class Program
    {
        static void Main(string[] args)
        {   /*
            int[] numbers =new int[7];

            numbers[0] = 10;
            numbers[1] = 15;
            numbers[2] = 35;
            numbers[3] = 48;
            numbers[4] = 2;
            numbers[5] = 1;
            numbers[6] = 19; */
            /*
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[1]);
            Console.WriteLine(numbers[2]);
            Console.WriteLine(numbers[3]);
            Console.WriteLine(numbers[4]);
            Console.WriteLine(numbers[5]);
            Console.WriteLine(numbers[6]);
            */
            /*
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
                sum += numbers[i];

            }
            Console.WriteLine(sum);
            */

            /*
            int sum = 0;
            foreach (var number in numbers)
            {
              sum += number;
            }
         
               Console.WriteLine(sum); */



            /*
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)

            {
                numbers[i] = 8;
            }

            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
                Console.WriteLine(sum);

            }                             */

            /*
            Console.WriteLine("Kolko cisel chcete zadat?");
            int n = int.Parse(Console.ReadLine());

            int[] pole = new int[n];
            int sucet = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Zadaj cislo:");
                pole[i] = i; int.Parse(Console.ReadLine());
                sucet += pole[i];
            }

            Console.WriteLine("Sucet: " +  sucet);    */

            /*
            int[] numbers = new int[11];
            Console.WriteLine("Dlzka pola je: "+numbers.Length);
            for (int i = 0; i < 10; i++) 
            {

                numbers[i] = i * 10;

            }
            int[] numbersNew = new int[numbers.Length+1];
            for (int i = 0;i < numbers.Length;i++) 
            {

                numbersNew[i] = numbers[i];

            }
            numbersNew[10] = 10000;
            foreach (var i in numbersNew)
            {

                Console.WriteLine(numbersNew[i]);
            
            }

            string[] names = { "Janko", "Misko", "Igor" };
            foreach (string name in names) 
            {

                Console.WriteLine(name);

            }                        */
            
            

            
        
        
        
        
        
        
        
        
        
        
        
        }
    }
}
