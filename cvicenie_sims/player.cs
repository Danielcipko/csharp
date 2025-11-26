using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_sims
{
    public class Player
    {
        public int Money { get; set; } = 50;
        public int Hunger { get; set; } = 100;
        public int Thirst { get; set; } = 100;
        public int Health { get; set; } = 100;

        public void Starving()
        {
            Hunger -= 5;
            if (Hunger <= 0)
            {
                Health -= 10;
            }
        }
        public void Thirsting ()
        {
           

        }
    }
}
