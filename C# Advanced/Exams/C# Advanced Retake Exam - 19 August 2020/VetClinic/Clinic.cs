using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        private int capacity;
        
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }
        public int Count => this.data.Count;

        public int Capacity { get; set; }

        public void Add(Pet pet)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name);
            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            foreach (var pet in data)
            {
                if (pet.Name == name && pet.Owner == owner)
                {
                    return pet;
                }
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            Pet pet = data.OrderByDescending(p => p.Age).FirstOrDefault();
            if(pet != null)
            {
                return pet;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients: ");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}