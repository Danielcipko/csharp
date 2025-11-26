using System.Security.Cryptography.X509Certificates;

namespace cvicenie_sims
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sims_game game = new sims_game();
            game.StartGame();
        }
    }
}
