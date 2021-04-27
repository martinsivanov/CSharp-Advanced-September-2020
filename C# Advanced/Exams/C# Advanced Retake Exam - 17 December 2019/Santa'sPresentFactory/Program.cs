using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_sPresentFactory
{
    class Program
    {
        static int doll = 150;
        static int WoodenTrain = 250;
        static int TeddyBear = 300;
        static int Bicycle = 400;
        static Dictionary<string, int> listCounts = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            listCounts.Add("Doll", 0);
            listCounts.Add("Wooden train", 0);
            listCounts.Add("Teddy bear", 0);
            listCounts.Add("Bicycle", 0);

            int[] materialForToys = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] magicInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> boxMaterials = new Stack<int>(materialForToys);
            Queue<int> magicLevels = new Queue<int>(magicInfo);
            bool isDone = false;
            while (boxMaterials.Count > 0 && magicLevels.Count > 0)
            {
                int currentMaterial = boxMaterials.Peek();
                int currentMagicLevel = magicLevels.Peek();
                int sum = currentMagicLevel * currentMaterial;

                if (currentMagicLevel == 0 || currentMaterial == 0)
                {
                    if (currentMaterial == 0)
                    {
                        boxMaterials.Pop();
                    }
                    if (currentMagicLevel == 0)
                    {
                        magicLevels.Dequeue();
                    }
                }
                if (sum == doll)
                {
                    boxMaterials.Pop();
                    magicLevels.Dequeue();
                    listCounts["Doll"]++;
                }
                else if (sum == WoodenTrain)
                {
                    boxMaterials.Pop();
                    magicLevels.Dequeue();
                    listCounts["Wooden train"]++;
                }
                else if (sum == TeddyBear)
                {
                    boxMaterials.Pop();
                    magicLevels.Dequeue();
                    listCounts["Teddy bear"]++;
                }
                else if (sum == Bicycle)
                {
                    boxMaterials.Pop();
                    magicLevels.Dequeue();
                    listCounts["Bicycle"]++;
                }
                else
                {
                    if (sum < 0)
                    {
                        boxMaterials.Pop();
                        magicLevels.Dequeue();
                        int add = currentMagicLevel + currentMaterial;
                        boxMaterials.Push(add);
                    }
                    if (sum > 0)
                    {
                        magicLevels.Dequeue();
                        boxMaterials.Push(boxMaterials.Pop() + 15);
                    }
                }
                if (listCounts["Bicycle"] > 0 && listCounts["Teddy bear"] > 0 ||
                     listCounts["Doll"] > 0 && listCounts["Wooden train"] > 0)
                {
                    isDone = true;
                }
            }

            if (isDone)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (boxMaterials.Count > 0)
            {
                Console.WriteLine($"Materials left: {String.Join(", ", boxMaterials)}");
            }
            if (magicLevels.Count > 0)
            {
                Console.WriteLine($"Magic left: {String.Join(", ", magicLevels)}");
            }

            foreach (var toy in listCounts.OrderBy(t => t.Key))
            {
                if (toy.Value > 0)
                {
                    Console.WriteLine($"{toy.Key}: {toy.Value}");
                }
            }
        }
    }
}

