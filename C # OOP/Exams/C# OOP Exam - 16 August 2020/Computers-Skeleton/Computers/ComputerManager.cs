using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers
{
    public class ComputerManager
    {
        private const string CanNotBeNullMessage = "Can not be null!";

        private readonly List<Computer> computers;

        public ComputerManager()
        {
            // TEST - DONE
            this.computers = new List<Computer>();
        }

        // TEST
        public IReadOnlyCollection<Computer> Computers => this.computers.AsReadOnly();

        // TEST - DONE
        public int Count => this.computers.Count;

        public void AddComputer(Computer computer)
        {

            this.ValidateNullValue(computer, nameof(computer), CanNotBeNullMessage);

            if (this.computers.Any(c => c.Manufacturer == computer.Manufacturer && c.Model == computer.Model))
            {// TEST - DONE
                throw new ArgumentException("This computer already exists.");
            }
            // TEST - Done
            this.computers.Add(computer);
        }

        public Computer RemoveComputer(string manufacturer, string model)
        {
            Computer computer = this.GetComputer(manufacturer, model);
            // TEST - DONE
            this.computers.Remove(computer);
            return computer;
        }

        public Computer GetComputer(string manufacturer, string model)
        {
            this.ValidateNullValue(manufacturer, nameof(manufacturer), CanNotBeNullMessage);
            this.ValidateNullValue(model, nameof(model), CanNotBeNullMessage);

            Computer computer = this.computers
                .FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (computer == null)
            {// TEST - DONE
                throw new ArgumentException("There is no computer with this manufacturer and model.");
            }
            // TEST - DONE
            return computer;
        }

        public ICollection<Computer> GetComputersByManufacturer(string manufacturer)
        {
            this.ValidateNullValue(manufacturer, nameof(manufacturer), CanNotBeNullMessage);

            ICollection<Computer> computers = this.computers
                .Where(c => c.Manufacturer == manufacturer)
                .ToList();
            // TEST - DONE
            return computers;
        }

        private void ValidateNullValue(object variable, string variableName, string exceptionMessage)
        {
            if (variable == null)
            {// TEST - DONE
                throw new ArgumentNullException(variableName, exceptionMessage);
            }
        }
    }
}