using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvicenia_objekty
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public char Sex { get; set; }


        public bool IsAdult()
        {
            if (Age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
     
        }
        public string Vypisinfo()
        {
            string vypis = Name + ", " + Age + ", " + Address + ", " + Sex + ", " +IsAdult();

            return vypis;
        }
    }   
}