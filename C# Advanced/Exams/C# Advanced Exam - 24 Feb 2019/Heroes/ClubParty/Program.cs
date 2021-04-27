using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        class Hall
        {
            public Hall(int capacity, string name)
            {
                Capacity = capacity;
                Name = name;
                this.Reservations = new List<int>();
            }

            public int Capacity { get; set; }
            public string Name { get; set; }

            public List<int> Reservations { get; set; }

            public override string ToString()
            {
                return $"{this.Name} -> {String.Join(", ", this.Reservations)}";
            }
        }

        static void Main(string[] args)
        {

            int hallCapacity = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>(Console.ReadLine().Split());
            Queue<Hall> halls = new Queue<Hall>();

            while (stack.Count > 0)
            {
                string current = stack.Peek();
                int people;
                if (int.TryParse(current, out people))
                {
                    if (halls.Count == 0)
                    {
                        stack.Pop();
                        continue;
                        
                    }
                    Hall hall = halls.Peek();
                    if (hall.Capacity - people >= 0)
                    {
                        hall.Capacity -= people;
                        hall.Reservations.Add(people);
                        stack.Pop();
                    }

                    else
                    {
                        Console.WriteLine(hall);
                        halls.Dequeue();
                        if (halls.Count > 0)
                        {
                            Hall newHall = halls.Peek();
                            newHall.Capacity -= people;
                            newHall.Reservations.Add(people);
                            stack.Pop();
                        }
                    }
                }
                else
                {

                    halls.Enqueue(new Hall(hallCapacity, current));

                    stack.Pop();
                }
            }
        }
    }
}
