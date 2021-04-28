using ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private const decimal MIN_COST = 0;

        private string name;
        private decimal cost;

        public Product(string name , decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.ExeptionMassageForInvalidName);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < MIN_COST)
                {
                    throw new ArgumentException(GlobalConstants.ExeptionMassageForNegativeMoney);
                }

                this.cost = value;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
