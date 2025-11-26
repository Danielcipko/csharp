using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace cvicenie_sims
{
    public class sims_game
    {
        public Player MyPlayer { get; set; } = new Player();
        public void StartGame()
        {
            bool isRunning = true;
            while (isRunning)
            {
                MyPlayer.Starving();

                if (MyPlayer.Health <= 0)
                {
                    Console.WriteLine("Game Over");
                    isRunning = false;
                }
                Console.WriteLine(MyPlayer.Hunger + " " + MyPlayer.Health);
            }
            while (isRunning) ;
            {
                MyPlayer.Thirsting();
                if (MyPlayer.Health <= 0)
                {
                    Console.WriteLine("Game is over");
                    isRunning = false;
                }
                Console.WriteLine(MyPlayer.Thirst + " " + MyPlayer.Health);

                



            }
        }
    }
}







    
  


   
        












