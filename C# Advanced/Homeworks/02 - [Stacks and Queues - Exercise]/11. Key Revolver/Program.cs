using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            int[] bulletsValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] LocksValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsValues);
            Queue<int> locks = new Queue<int>(LocksValues);
            int ShootsCount = 0;
            int bulletsShots = 0;
            int totalBullets = bullets.Count;
            while (true)
            {
                if (!locks.Any() || !bullets.Any())
                {
                    break;
                }
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();


                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    ShootsCount++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    ShootsCount++;
                }
                if (ShootsCount == sizeOfGunBarrel)
                {
                    if (bullets.Any())
                    {
                        Console.WriteLine("Reloading!");
                    }
                    bulletsShots += ShootsCount;
                    ShootsCount = 0;
                    totalBullets -= sizeOfGunBarrel;

                }

            }

            if (!locks.Any())
            {
                int moneyEarned = bulletsShots * priceForBullet;
                int TotalmoneyEarned = intelligenceValue - moneyEarned;
                Console.WriteLine($"{totalBullets} bullets left. Earned ${TotalmoneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
