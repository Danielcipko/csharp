namespace cvicenie_batlle_simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            hero ourHero = new hero();
            Monster monster1 = new Monster("Goblin", 150, 20);
            Monster monster2 = new Monster("Gumkac", 125, 15);
            Monster monster3 = new Monster("Troll", 200, 10);
            List<Monster> monsters = new List<Monster>();
            monsters.Add(monster1);
            monsters.Add(monster2);
            monsters.Add(monster3);
            Random r = new Random();

            Console.WriteLine("Kto chces aby bojoval s hrdinom 1.Goblin 2.Gumkac 3.Vsetci 4.Random");
            string Monstername = Console.ReadLine();




            if (Monstername == "Goblin") ;
            {
                while (true)
                {

                    //Hero dostal utok od monstra
                    monster1.MonsterAttack(ourHero);
                    monster2.MonsterAttack(ourHero);
                    monster3.MonsterAttack(ourHero);
                    Console.WriteLine("HERO:HP " + ourHero.HP);

                    //Monster dostal utok od hrdinu
                    bool wasAttack = ourHero.HeroAttack(monster1);
                    if (wasAttack)
                    {
                        Console.WriteLine("MONSTER:HP " + monster1.HP);
                    }
                    else
                    {
                        Console.WriteLine("---Not enough energy to attack! Restoring energy...");
                        Console.WriteLine("HERO:energy " + ourHero.ENG);
                    }

                    if (ourHero.HP <= 0)
                    {
                        Console.WriteLine("Hero is dead!");
                        break;
                    }

                    if (monster1.HP <= 0)
                    {
                        Console.WriteLine("Monster is dead!");
                        break;
                    }
                }

                if (Monstername == "Gumkac") ;
                {
                    while (true)
                    {

                        //Hero dostal utok od monstra
                        monster1.MonsterAttack(ourHero);
                        monster2.MonsterAttack(ourHero);
                        monster3.MonsterAttack(ourHero);
                        Console.WriteLine("HERO:HP " + ourHero.HP);

                        //Monster dostal utok od hrdinu
                        bool wasAttack = ourHero.HeroAttack(monster1);
                        if (wasAttack)
                        {
                            Console.WriteLine("MONSTER:HP " + monster1.HP);
                        }
                        else
                        {
                            Console.WriteLine("---Not enough energy to attack! Restoring energy...");
                            Console.WriteLine("HERO:energy " + ourHero.ENG);
                        }

                        if (ourHero.HP <= 0)
                        {
                            Console.WriteLine("Hero is dead!");
                            break;
                        }

                        if (monster1.HP <= 0)
                        {
                            Console.WriteLine("Monster is dead!");
                            break;
                        }
                    }
                }

                if (Monstername == "Vsetci") ;

                while (true)
                {

                    //Hero dostal utok od monstra
                    monster1.MonsterAttack(ourHero);
                    monster2.MonsterAttack(ourHero);
                    monster3.MonsterAttack(ourHero);
                    Console.WriteLine("HERO:HP " + ourHero.HP);

                    //Monster dostal utok od hrdinu
                    bool wasAttack = ourHero.HeroAttack(monster1);
                    if (wasAttack)
                    {
                        Console.WriteLine("MONSTER:HP " + monster1.HP);
                    }
                    else
                    {
                        Console.WriteLine("---Not enough energy to attack! Restoring energy...");
                        Console.WriteLine("HERO:energy " + ourHero.ENG);
                    }

                    if (ourHero.HP <= 0)
                    {
                        Console.WriteLine("Hero is dead!");
                        break;
                    }

                    if (monster1.HP <= 0)
                    {
                        Console.WriteLine("Monster is dead!");
                        break;
                    }
                }
                if (Monstername == "Random")
                {
                    Console.WriteLine("Utok sa zacal!");
                    while (true)
                    {


                        int pocetPriser = monsters.Count;
                        int ktora = r.Next(0, pocetPriser);
                        monsters[0].MonsterAttack(ourHero);
                        if (ourHero.HP <= 0)
                        {
                            Console.WriteLine("Hero is dead!");
                            break;
                        }
                        ourHero.HeroAttack(monsters[ktora]);
                        if (monsters[ktora].HP <= 0)
                        {
                            monsters.RemoveAt(ktora);
                        }
                        if (monsters.Count == 0)
                        {
                            Console.WriteLine("All monsters are dead.");
                            break;
                        }
                        Console.WriteLine("HERO:HP " + ourHero.HP);

                        foreach (Monster monster in monsters)
                        {
                            Console.WriteLine(monster.RaceType + ":HP" + ourHero.HP);
                        }
                    }
                }
            }
        }
    }
}




