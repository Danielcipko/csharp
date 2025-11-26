using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_GameShop
{
    public class LootGenerator
    {
        public static List<item> GetRandomLoot()
        {
            var itemNames = new List<string>
    {
                 "Zafírový amulet",
                 "Dračí plášť",
                 "Kúzelné ponožky",
                 "Elixír neviditeľnosti",
                 "Plášť tieňov",
                 "Strieborný roh",
                 "Temný artefakt",
                 "Runový zvitok",
                 "Plameňová koruna",
                 "Oceľové rukavice",
                 "Krištáľový prsteň",
                 "Tajomný medailón",
                 "Meč bleskov",
                 "Klenot púšte",
                 "Prikrývka mrazu",
                 "Kniha zabudnutých kúziel",
                 "Hromový halapartník",
                 "Zlatý pohár",
                 "Svätožiarová lampa",
                 "Vírivá dýka",
                 "Galaktické okuliare",
                 "Truhlica so záhadou",
                 "Rubínové topánky",
                 "Prsteň večnosti",
                 "Zamatové puzdro",
                 "Náhrdelník odvahy",
                 "Maska ilúzií",
                 "Korunka moci",
                 "Tótem šťastia"
    };          


            var rand = new Random(148752985);
            var itemNamesCopy = new List<string>(itemNames);
            var result = new List<item>();

            for (int i = 0; i < 20; i++)
            {
                int idx = rand.Next(itemNamesCopy.Count);
                string name = itemNamesCopy[idx];
                itemNamesCopy.RemoveAt(idx);

                int price = rand.Next(50, 2001);    // náhodná cena 50 až 2000
                int level = rand.Next(1, 11);       // náhodný level 1 až 10

                var item = new item
                {
                    Name = name,
                    Price = price,
                    Level = level
                };

                result.Add(item);
            }
            return result;
        }

    }
}
