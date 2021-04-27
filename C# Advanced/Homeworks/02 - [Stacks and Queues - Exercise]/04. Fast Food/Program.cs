using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtyFood = int.Parse(Console.ReadLine()); //348

            int[] clients = Console.ReadLine().Split().Select(int.Parse).ToArray(); // 20 54 30 16 7 9

            Queue<int> orders = new Queue<int>(clients);
            int biggestOrder = orders.Max();


            for (int i = 0; i < clients.Length; i++)
            {
                int currentClient = clients[i];

                if (currentClient <= qtyFood)
                {
                    qtyFood -= currentClient;
                    if (biggestOrder < currentClient)
                    {
                        biggestOrder = currentClient;
                    }
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Any())
            {
                Console.WriteLine(biggestOrder);
                Console.Write("Orders left: ");
                Console.WriteLine(String.Join(" ", orders));
            }
            else
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }

        }
    }
}
