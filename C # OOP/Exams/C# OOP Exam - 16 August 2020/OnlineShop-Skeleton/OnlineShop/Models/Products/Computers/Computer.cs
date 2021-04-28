using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model,
            decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components =>
            (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals =>
            (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;

                }
                else
                {
                    double resultAvarage = this.components.Average(x => x.OverallPerformance);
                    return (base.OverallPerformance + resultAvarage);
                }
            }
        }
        public override decimal Price
        {
            get
            {
                return base.Price + this.Components.Sum(x => x.Price) + this.Peripherals.Sum(s => s.Price);
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($" Components ({this.Components.Count}):");
            if (this.Components.Count != 0)
            {
                foreach (Component componet in this.Components)
                {

                    sb.AppendLine($"  {componet.ToString()}");
                }

            }


            double avaragePeripherals = this.peripherals.Count == 0 ? 0 : this.Peripherals.Average(x => x.OverallPerformance);

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({avaragePeripherals:f2}):");
            if (this.Peripherals.Count != 0)
            {
                foreach (Peripheral peripheral in this.Peripherals)
                {
                    sb.AppendLine($"  {peripheral.ToString()}");
                }

            }
            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            IComponent search = this.Components.FirstOrDefault(x => x.GetType().Name
            == component.GetType().Name);
            if (search != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }


        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null || this.Components.Count == 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }
            this.components.Remove(component);
            return component;
        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            IPeripheral searchPeripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name);
            if (searchPeripheral != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral == null || this.peripherals.Count == 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }
            this.peripherals.Remove(peripheral);
            return peripheral;
        }
    }
}
