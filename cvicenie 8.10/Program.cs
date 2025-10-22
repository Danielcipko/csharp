using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace cvicenie_8._10
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<int> list = new List<int>();

            //bool running = true;
            while ( /*running*/true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        {
                            AddNumber(list);
                            break;
                        }
                    case "del":
                        {
                            Console.WriteLine("What number do you want to delete");
                            string number = Console.ReadLine();
                            int numberint = int.Parse(number);
                            list.Remove(numberint);
                            break;
                        }
                    case "deli":
                        {
                            Console.WriteLine("The number at what position do you want to remove");

                            string number = Console.ReadLine();
                            int numberint = int.Parse(number);
                            if (numberint >= 0 && numberint < list.Count)
                            {
                                list.RemoveAt(numberint);
                            }
                            else
                            {
                                Console.WriteLine("bad index");
                            }

                            break;
                        }
                    case "end":
                        {
                            //running = false;
                            break;
                        }
                    case "list":
                        {
                            foreach (int i in list)
                            {
                                Console.WriteLine(i);
                            }

                            break;
                        }
                    case "has":
                        {
                            Console.WriteLine("What number do you want to check if the list has?");
                            string number = Console.ReadLine();
                            int numberint = int.Parse(number);
                            bool hasnumberint = list.Contains(numberint);
                            if (hasnumberint)
                            {
                                Console.WriteLine("true");
                            }
                            else
                            {
                                Console.WriteLine("false");
                            }

                            break;
                        }
                    case "count":
                        {
                            int sum = 0;
                            foreach (int i in list)
                            {
                                sum += i;
                                Console.WriteLine(sum);
                            }

                            break;
                        }
                    case "avg":
                        {
                            int sum = 0;
                            foreach (int i in list)
                            {
                                sum += i;

                            }

                            int sum1 = sum / list.Count;
                            Console.WriteLine(sum1);
                            break;
                        }
                        case "max":
                        {
                            int max = list[0];
                            foreach (int num in list)
                            {
                                if (num > max)
                                {

                                }
                            }
                            break;
                        }
                    case "min":
                        {
                            int min = list[0];
                            foreach (int num in list)
                            {
                                if (num < min)
                                {
                                    min = num;
                                }
                            }

                            Console.WriteLine(min);
                            break;
                        }
                    case "help":
                        {
                            Console.WriteLine("type ´add´ to add a number into the list");
                            Console.WriteLine("type ´del´ to remove the number from the list");
                            Console.WriteLine("type ´deli´ to remove the a number from the chosen position");
                            Console.WriteLine("type ´has´ to check if the chosen number is in the list");
                            Console.WriteLine("type ´list´ to open the list");
                            Console.WriteLine("type ´end´ to exit the console");
                            Console.WriteLine("type ´avg´ to calculate the average number on list");
                            Console.WriteLine("type ´min´ to get the biggest number on list");
                            Console.WriteLine("type ´max´ to get the smallest number on list");
                            Console.WriteLine("type ´get´ to find the number on chosen position");
                            break;
                        }
                    case "get":
                        {
                            Console.WriteLine("pick a position of a number to get");
                            string numberTxt = Console.ReadLine();
                            int number = int.Parse(numberTxt);

                            if (number >= 0 && number < list.Count)
                            {
                                Console.WriteLine(list[number]);
                            }
                            else
                            {
                                Console.WriteLine("this position is not in the list");
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("unknown command, type ´help´ for help");
                            break;
                        }
                }

            }
        }
        public static void AddNumber(List<int> list)
        {
            Console.WriteLine("What number do you want to add");
            string number = Console.ReadLine();
            int numberint = int.Parse(number);
            list.Add(numberint);
        }

        public static void DelNumber(List<int> list)
        {
            Console.WriteLine("What number do you want to delete");
            string number = Console.ReadLine();
            int numberint = int.Parse(number);
            list.Add(numberint);

        }

        public static bool HasNumber(List<int> list, int num) 
        {
            bool has = false;
            if (list.Contains(num))
            {

                has = true;
            }
            else
            {
                has = false;

            }

            return has;
        }

        public static int CountNumber(List<int> list) 
        {
            int sum = 0;
            foreach (int i in list) 
            {
                sum += i;
                
            }
            
            return sum;
        }
    }
}


            









































































































        }
    }
    
}





















































