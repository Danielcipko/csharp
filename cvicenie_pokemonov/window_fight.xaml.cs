using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_Pokemon
{
    public class Hero
    {
        public int Health { get; set; }      //zobrazuje aktualne zivoty hrdinu
        public int Health_Max { get; set; }    //zobrazuje jeho max HP
        public int Damage { get; set; }

        public Hero(int health, int health_Max, int damage)
        {
            Health = health;
            Health_Max = health_Max;
            Damage = damage;
        }
    }
}