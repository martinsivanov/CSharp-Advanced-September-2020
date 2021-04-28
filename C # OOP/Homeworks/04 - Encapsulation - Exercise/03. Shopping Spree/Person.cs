using ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private const decimal MIN_MONEY = 0;
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name,decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
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
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < MIN_MONEY)
                {
                    throw new ArgumentException(GlobalConstants.ExeptionMassageForNegativeMoney);
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.bag.Add(product);
            }
            else
            {
                throw new ArgumentException(String.Format
                    (GlobalConstants.ExeptionMassageNotEnoughtMoneyForProduct,
                    this.Name, product.Name));
            }
        }
        public override string ToString()
        {
            string outPutProducts = this.Bag.Count > 0 ? String.Join(", ", this.Bag)
            : "Nothing bought";

            return $"{this.Name} - {outPutProducts}";
        }
    }
}
