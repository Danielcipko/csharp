

namespace cvicenie_batlle_simulator
{
    public class Monster
    {
        public string RaceType { get; set; }   //Monster race type (e.g., Grdo, Orc, Troll)
        public int HP { get; set; }    //Health points
        public int DMG { get; set; }    //Damage

        public Monster(string raceType, int hP, int dMG)
        {
            RaceType = raceType;
            HP = hP;
            DMG = dMG;
        }
        public void MonsterAttack(hero hero)
        {
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