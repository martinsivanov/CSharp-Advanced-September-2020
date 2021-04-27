using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        //•	Name: string
        //•	Capacity: int

        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Rabbit>();
        }
        public int Count => this.data.Count();
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = data.FirstOrDefault(r => r.Name == name);
            if (rabbit != null)
            {
                data.Remove(rabbit);
                return true;
            }
            return false;
        }
        public void RemoveSpecies(string species)
        {
            data.RemoveAll(r => r.Species == species);
        }
        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = data.FirstOrDefault(r => r.Name == name);
            if (rabbit != null)
            {
                rabbit.Available = false;
            }
            return rabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var soldRabbits = this.data.Where(x => x.Species == species).ToList();
            for (int i = 0; i < soldRabbits.Count; i++)
            {
                soldRabbits[i].Available = false;
            }
            return soldRabbits.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.data)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
