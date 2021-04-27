using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesValues = Console.ReadLine().Split().Select(int.Parse).ToArray();


            Queue<int> cups = new Queue<int>(cupsValues);
            Stack<int> bottles = new Stack<int>(bottlesValues);

            int wastedWaters = 0;

            while (true)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                {
                    wastedWaters += currentBottle - currentCup;
                    cups.Dequeue();

                }
                else
                {
                    int totalBottles = 0;
                    while (currentBottle <= currentCup)
                    {
                        int nextBottle = bottles.Pop();
                        totalBottles += nextBottle;
                        if (totalBottles + currentBottle >= currentCup)
                        {
                            wastedWaters += totalBottles + currentBottle - currentCup;

                            break;
                        }
                    }
                    cups.Dequeue();
                }
                if (!cups.Any())
                {

                    Console.Write($"Bottles: ");
                    foreach (var bottle in bottles)
                    {
                        Console.Write(bottle);
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Wasted litters of water: {wastedWaters}");
                    break;
                }
                if (!bottles.Any())
                {
                    Console.Write($"Cups: ");
                    foreach (var cup in cups)
                    {
                        if (cups.Count > 1)
                        {

                            Console.Write($"{cup} ");
                        }
                        else
                        {
                            Console.Write(cup);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Wasted litters of water: {wastedWaters}");
                    break;
                }
            }
        }
    }
}
