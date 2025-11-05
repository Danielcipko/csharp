using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;

namespace cvicenia_objekty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string Name = "Daniel";
            int Age = 15;
            string Address = "Kysuca"; 

            Student student1 = new Student();
            student1.Name = Name;
            student1.Age = Age;
            student1.Address = Address;
            student1.Sex = 'M';
            
            Student student2 = new Student();
            student2.Name = "Daniel Cipko";
            student2.Age = 56;
            student2.Address = "Kysucke Nove Mesto";
            student2.Sex = 'M'; 

            Student stary = student1;
            /*
            string menoStudenta1 = student1.Name;
            menoStudenta1 = "Peter Novak";
            student1.Name = menoStudenta1;
            Console.WriteLine(student1.Name);
            Console.WriteLine(student1.IsAdult()); */
            
            Student Vypisinfo = new Student();
            Console.WriteLine(student1.Vypisinfo()); 











        }
    }
}
