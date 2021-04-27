using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] malesInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] femalesInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> females = new Queue<int>(femalesInfo);
            Stack<int> males = new Stack<int>(malesInfo);
            int matches = 0;
            while (females.Count > 0 && males.Count > 0)
            {
                int currentFemale = females.Peek();
                int currentMale = males.Peek();

                if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }
                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }
                if (currentFemale == currentMale)
                {
                    matches++;
                    females.Dequeue();
                    males.Pop();
                }
                else
                {
                    if (females.Count > 0 && males.Count > 0)
                    {
                        females.Dequeue();
                        males.Push(males.Pop() - 2);
                    }
                }
                
            }
            Console.WriteLine($"Matches: {matches}");

            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {String.Join(", ",males)}");
            }
            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {String.Join(", ",females)}");
            }
        }
    }
}
