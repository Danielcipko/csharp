using System.Reflection.Metadata.Ecma335;

namespace skuska_5._11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ct = 0;
            for (int i = 0; i < 1000; i++) 
            {
                bool results = Prob();
                if (results == true)
                {

                }
            }
        }
        public static bool Prob()
        {
            Random r = new Random();
            int nahodneCislo = r.Next(0,101);
            if (nahodneCislo >= 73)
            {

                return true;

            }
            return false;

        }    
    }
}
