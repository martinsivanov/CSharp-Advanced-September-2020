using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        //•	Datura Bombs: 40
        //•	Cherry Bombs: 60
        //•	Smoke Decoy Bombs: 120
        static int DaturaBombs = 40;
        static int CherryBombs = 60;
        static int SmokeDecoyBombs = 120;
        static int countDaturaBombs = 0;
        static int countCherryBombs = 0;
        static int countSmokeDecoyBombs = 0;

        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>((Console.ReadLine().Split(", ").Select(int.Parse).ToArray()));
            Stack<int> casings = new Stack<int>((Console.ReadLine().Split(", ").Select(int.Parse).ToArray()));
            bool isfilled = false;
            while (effects.Any() && casings.Any())
            {
                int currentEffect = effects.Peek();
                int currentCasing = casings.Peek();
                int sum = currentEffect + currentCasing;
                if (sum == DaturaBombs)
                {
                    countDaturaBombs++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (sum == CherryBombs)
                {
                    countCherryBombs++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (sum == SmokeDecoyBombs)
                {
                    countSmokeDecoyBombs++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    casings.Push(casings.Pop() - 5);
                }

                if (countCherryBombs > 2 && countDaturaBombs > 2 && countSmokeDecoyBombs > 2)
                {
                    isfilled = true;
                    break;
                }
            }

            if (isfilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            Console.WriteLine($"Cherry Bombs: {countCherryBombs}");
            Console.WriteLine($"Datura Bombs: {countDaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {countSmokeDecoyBombs}");
        }
    }
}
