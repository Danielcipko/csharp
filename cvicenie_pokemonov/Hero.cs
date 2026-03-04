using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_pokemonov
{
    public class Hero
    {
        public int Health { get; set; } //zobrazuje aktualne zivoty hrdinu
        public int HealthMax { get; set; } //zobrazuje jeho maximalne HP
        public int Damage { get; set; }

        public Hero(int health, int healthMax, int damage)
        {
            Health = health;
            HealthMax = healthMax;
            Damage = damage;
        }
    }
}


