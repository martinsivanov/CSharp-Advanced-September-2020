using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] secondLootBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> queueFirst = new Queue<int>(firstLootBox);
            Stack<int> stackSecond = new Stack<int>(secondLootBox);
            int value = 0;
            while (queueFirst.Count > 0 && stackSecond.Count > 0)
            {
                int firstNum = queueFirst.Peek();
                int secondNum = stackSecond.Peek();
                int sum = firstNum + secondNum;
                if (sum % 2 == 0)
                {
                    value += sum;
                    queueFirst.Dequeue();
                    stackSecond.Pop();
                }
                else
                {
                    int lastItem = stackSecond.Pop();
                    queueFirst.Enqueue(lastItem);
                }
            }
            if (queueFirst.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (stackSecond.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (value >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {value}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {value}");
            }
        }
    }
}
