using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_batlle_simulator
{
    public class Monster
    {
        public string RaceType { get; set; }  //Monster race type (e.g., Goblin, Orc, Troll)

        public int HP { get; set; } //Health points

        public int DMG { get; set; } //Damage
         
        public Monster(string raceType, int hP, int dmG)
        { 
           RaceType = raceType;
            HP = hP;
            DMG = dmG;

            
        }
        public void MonsterAttack(hero hero)
        {
           hero.HP -= this.DMG;

        
            if (hero.SHD > DMG)
            {
                hero.HP = hero.HP - 0;
            }
            else if (hero.SHD < DMG)
            {
                hero.HP = (hero.SHD + hero.HP) - DMG;


            }


        }
    }
}




