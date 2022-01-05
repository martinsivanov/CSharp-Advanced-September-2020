namespace Gym.Models.Gyms
{
    using global::Gym.Models.Athletes.Contracts;
    using global::Gym.Models.Equipment.Contracts;
    using global::Gym.Models.Gyms.Contracts;
    using global::Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Gym : IGym
    {
        private string name;
        private ICollection<IEquipment> equipments;
        private ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.equipments = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }
        //The number of Athletes which can exercise in a Gym
        public int Capacity { get; protected set; }

        public double EquipmentWeight => this.equipments.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => this.equipments;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }
        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            //Athletes: {athleteName1}, {athleteName2}, {athleteName3} (…) / No athletes
            var result = this.athletes.Count == 0 ? "No athletes" : String.Join(", ", this.Athletes.Select(x => x.FullName));
            sb.AppendLine($"Athletes: {result}");
            sb.AppendLine($"Equipment total count: {this.equipments.Count()}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }


    }
}
