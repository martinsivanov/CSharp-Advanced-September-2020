using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public virtual int Quantity { get; }
    }
}
