using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            this.data = new List<Present>();
        }
        public int Count => this.data.Count();
        //•	Color: string
        //•	Capacity: int

        public string Color { get; set; }
        public int Capacity { get; set; }

        public void Add(Present present)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(present);
            }
        }
        public bool Remove(string name)
        {
            bool exist = data.Any(p => p.Name == name);
            if (exist)
            {
                data.RemoveAll(p => p.Name == name);
                return true;

            }
            return false;

        }
        public Present GetHeaviestPresent()
        {
            double heaviest = double.MinValue;
            Present heaviestPresent = null;
            foreach (var present in data)
            {
                if (present.Weight > heaviest)
                {
                    heaviest = present.Weight;
                     heaviestPresent = present;
                }
            }
            return heaviestPresent;
        }
        public Present GetPresent(string name)
        {
            Present present = data.FirstOrDefault(p => p.Name == name);
            if (present != null)
            {
                return present;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
