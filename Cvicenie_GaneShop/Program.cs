namespace Cvicenie_GameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<item> items = LootGenerator.GetRandomLoot();

            item currentBest = items[0];
            foreach(var item in items)
            {
                if (item.Price > currentBest.Price)
                {
                    currentBest = item;
                }
            }
            Console.WriteLine(currentBest);
       
            //New way - LINQ
            item worst = items.MinBy(item => item.Price);
            Console.WriteLine(worst);

            //najlacnejsi item
            item best = items.MaxBy(item => item.Price);
            Console.WriteLine(best);

            List<item> orderByPrice = items .OrderBy(vec => vec.Price).ToList();
            Console.WriteLine(orderByPrice[items.Count - 1]);

            List<item> orderByPriceNajdrahsi = items.OrderBy(vec => vec.Price).ToList() ;
            Console.WriteLine("Toto je najdrahsia vec" + orderByPriceNajdrahsi[0]);

            List<item> itemunder1000= items.Where(vec => vec.Price <= 1000).ToList();
            Console.WriteLine(itemunder1000);

            List<item> item500to1000 = items.Where(vec => vec.Price <= 1000 && vec.Price >= 500).ToList();
            Console.WriteLine(item500to1000.Count);
        }
    }
} 