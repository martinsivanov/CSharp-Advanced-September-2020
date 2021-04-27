using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] roses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stackLilies = new Stack<int>(lilies);
            Queue<int> queueRoses = new Queue<int>(roses);

            int goalFlowers = 5;
            int counterFlowers = 0;
            int store = 0;
            bool goalReach = false;
            int sum = 0;
            while (stackLilies.Count > 0 && queueRoses.Count > 0)
            {
                int currentLilie = stackLilies.Peek();
                int currentRose = queueRoses.Peek();

                sum = currentLilie + currentRose;
                if (sum == 15)
                {
                    counterFlowers++;
                    stackLilies.Pop();
                    queueRoses.Dequeue();

                }
                else if (sum > 15)
                {
                    stackLilies.Pop();
                    stackLilies.Push(currentLilie - 2);
                }
                else if (sum < 15)
                {
                    store += sum;
                    stackLilies.Pop();
                    queueRoses.Dequeue();
                }

                if (counterFlowers == goalFlowers)
                {
                    goalReach = true;
                }
            }


            if (store != 0)
            {
                counterFlowers += store / 15;
                if (counterFlowers == goalFlowers)
                {
                    goalReach = true;
                }
            }
            if (goalReach)
            {
                Console.WriteLine($"You made it, you are going to the competition with {counterFlowers} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {goalFlowers - counterFlowers} wreaths more!");
            }
        }
    }
}
