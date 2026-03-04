using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_pokemonov
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Cvicenie_Pokemon
    {
        public class Enemy
        {
            public int Health_Max { get; set; }     //zobrazuje jeho max HP
            public int Damage { get; set; }

            public Enemy(int health_Max, int damage)
            {
                Health_Max = health_Max;
                Damage = damage;
            }
        }
    }
}
