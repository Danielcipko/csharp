using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_batlle_simulator
{
    public class hero
    {
        public string Name { get; set; } = "Arnost"; //Hero name

        public int HP { get; set; } = 100; //Health points

        public int DMG { get; set; } = 10;  //Damage


        public int SHD { get; set; } = 15;         //Shield

        public int Eng { get; set; }
        public bool HeroAttack(Monster monster)
        {
            if (Eng - 20 >= 0)
            {
                Eng -= 20;
                monster.HP -= this.DMG;
                return true;
            }
            else

            {
                Eng = Eng + 50;
                return false;
            }
        }
        









    }
}
