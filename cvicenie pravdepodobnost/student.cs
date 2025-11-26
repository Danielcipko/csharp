using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_pravdepodobnost
{
   public class Student
   {
        public string Name { get; set; }
        public int ticketCount { get; set; }

        public Student(string meno, int ticketCount)
        {
            Name = meno;
            this.ticketCount = ticketCount;
        }
    }






}

