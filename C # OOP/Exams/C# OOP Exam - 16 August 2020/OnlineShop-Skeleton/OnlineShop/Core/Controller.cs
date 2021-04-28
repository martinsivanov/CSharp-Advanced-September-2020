using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        public Controller()
        {
            this.computers = new List<IComputer>();
        }
        public string AddComputer(string computerType, int id, string manufacturer,
            string model, decimal price)
        {
            //Creates a computer with the correct type and adds it to the collection of computers.
            //If a computer, with the same id, already exists in the computers collection, 
            //throw an ArgumentException
            //with the message "Computer with this id already exists."
            //If the computer type is invalid, throw an ArgumentException with the message
            //"Computer type is invalid."
            //If it's successful, returns "Computer with id {id} added successfully.".

            IComputer computer;
            if (computerType == "Laptop")
            {
                CheckIfComputerIdAlreadyExist(id);
                computer = new Laptop(id, manufacturer, model, price);

            }
            else if (computerType == "DesktopComputer")
            {
                CheckIfComputerIdAlreadyExist(id);
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            if (this.computers.FirstOrDefault(c => c.Id == computer.Id) != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            this.computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, computer.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer,
            string model, decimal price, double overallPerformance, int generation)
        {
            IComputer currentComputer = this.computers.FirstOrDefault(c => c.Id == computerId);
            CheckIfComputerIdExist(computerId);
            if (currentComputer.Components.FirstOrDefault(x => x.Id == id) != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            currentComputer.AddComponent(component);
            return String.Format(SuccessMessages.AddedComponent,
                component.GetType().Name, component.Id, currentComputer.Id);
            //Creates a component with the correct type and adds it to the computer with that id, 
            //then adds it to the collection of components in the controller.
            //If a component, with the same id, already exists in the components collection, 
            //throws an ArgumentException with the message "Component with this id already exists."
            //If the component type is invalid, throws an ArgumentException 
            // with the message "Component type is invalid."
            //If it's successful, returns "Component {component type} with id {component id}
            //added successfully in computer with id {computer id}.".

        }
        private void CheckIfComputerIdAlreadyExist(int id)
        {
            if (this.computers.FirstOrDefault(x => x.Id == id) != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
        }
        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            CheckIfComputerIdExist(computerId);

            IComponent component = currentComputer.RemoveComponent(componentType);

            return String.Format(SuccessMessages.RemovedComponent, component.GetType().Name, component.Id);

        }



        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer,
            string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            CheckIfComputerIdExist(computerId);
            IPeripheral peripheral = computer.Peripherals.FirstOrDefault(x => x.Id == id);
            if (peripheral != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            else
            {
                if (peripheralType == "Headset")
                {
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                }
                else if (peripheralType == "Keyboard")
                {
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);

                }
                else if (peripheralType == "Monitor")
                {
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);

                }
                else if (peripheralType == "Mouse")
                {
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);

                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
                }
            }
            computer.AddPeripheral(peripheral);
            return String.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, peripheral.Id, computer.Id);

            //Creates a peripheral, with the correct type, and adds it to the computer with 
            //that id, then adds it to the collection of peripherals in the controller.

            //If a peripheral, with the same id, already exists in the peripherals collection, it throws 
            //an ArgumentException with the message "Peripheral with this id already exists."

            //If the peripheral type is invalid, throws an ArgumentException with the 
            //message "Peripheral type is invalid."

            //If it's successful, it returns "Peripheral {peripheral type} with id {peripheral id}
            //added successfully in computer with id {computer id}.".

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            CheckIfComputerIdExist(computerId);
            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            return String.Format(SuccessMessages.RemovedPeripheral, peripheral.GetType().Name, peripheral.Id);
        }
        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);
            CheckIfComputerIdExist(id);
           
                Computer currComputer = (Computer)computer;
                this.computers.Remove(computer);
                return currComputer.ToString();
           
        }
        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            IComputer bestComputer = null;
            double bestOverallPerformance = 0;
            foreach (var currentComputer in this.computers)
            {
                if (currentComputer.Price <= budget)
                {
                    if (bestOverallPerformance < currentComputer.OverallPerformance)
                    {
                        bestOverallPerformance = currentComputer.OverallPerformance;
                        bestComputer = currentComputer;
                    }
                }
            }
            if (bestComputer != null)
            {
                this.computers.Remove(bestComputer);
                return bestComputer.ToString();
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
        }


        public string GetComputerData(int id)
        {

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            else
            {
                Computer currentComp = (Computer)computer;
                return currentComp.ToString();
            }
        }

        private void CheckIfComputerIdExist(int computerId)
        {
            if (this.computers.FirstOrDefault(x => x.Id == computerId) == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
