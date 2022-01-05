namespace Gym.Models.Equipment
{
    using Gym.Models.Equipment.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }
        public double Weight { get; set; }

        public decimal Price { get; set; }
    }
}
