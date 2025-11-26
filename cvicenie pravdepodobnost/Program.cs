namespace cvicenie_pravdepodobnost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
          Random rand = new Random();
          int value = rand.Next(0,100);
          if (value < 80)     //80:20
          {
            Console.WriteLine("Vyhral ten s 80%");
          }
          else
          {
                Console.WriteLine("Vyhral ten s 20%"); 
          }  */

            Student student1 = new Student("Michal", 1);
            Student student2 = new Student("Radovan", 3);
            Student student3 = new Student("Dano", 6);
            Student student4 = new Student("Rado", 8);

            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);


            List<Student> klobucik = new List<Student>();
            foreach (Student stud in students)
            {
                for (int i = 0; i < stud.ticketCount; i++) 
                {
                    klobucik.Add(stud);
                }
            } 
            Random random = new Random();
            int index = random.Next(klobucik.Count);
            Student vyherca = klobucik[index];
            Console.WriteLine(vyherca.Name + vyherca.ticketCount);
        }   
    }
}
