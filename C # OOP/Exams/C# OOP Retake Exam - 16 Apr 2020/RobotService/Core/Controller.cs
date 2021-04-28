using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<string, IProcedure> procedures;
        public Controller()
        {
            garage = new Garage();
            procedures = new Dictionary<string, IProcedure>();
        }

        public string Manufacture(string robotType, string name, int energy,
            int happiness, int procedureTime)
        {

            IRobot robot = null;
            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            garage.Manufacture(robot);
            return $"Robot {robot.Name} registered successfully";
        }
        public string Chip(string robotName, int procedureTime)
        {
            //Calls the Chip procedure with parameters currentRobot and procedureTime.
            //Returns "{current robot name} had chip procedure".
            CheckIfRobotExists(robotName);

            IRobot robot = this.garage.Robots[robotName];
            if (this.procedures.ContainsKey("Chip"))
            {
                this.procedures["Chip"].DoService(robot, procedureTime);
            }
            else
            {
                IProcedure chip = new Chip();
                this.procedures.Add("Chip", chip);
                this.procedures["Chip"].DoService(robot, procedureTime);
            }
            return String.Format(OutputMessages.ChipProcedure, robotName);

        }


        public string TechCheck(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);
            IRobot robot = this.garage.Robots[robotName];

          
            if (this.procedures.ContainsKey("TechCheck"))
            {
                this.procedures["TechCheck"].DoService(robot, procedureTime);
            }
            else
            {
                IProcedure techCheck = new TechCheck();
                this.procedures.Add("TechCheck", techCheck);
                this.procedures["TechCheck"].DoService(robot, procedureTime);
            }
            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }
        public string Rest(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);
            IRobot robot = this.garage.Robots[robotName];

            
            if (this.procedures.ContainsKey("Rest"))
            {
                this.procedures["Rest"].DoService(robot, procedureTime);
            }
            else
            {
                IProcedure rest = new Rest();
                this.procedures.Add("Rest", rest);
                this.procedures["Rest"].DoService(robot, procedureTime);
            }
            return String.Format(OutputMessages.RestProcedure, robotName);
        }
        public string Work(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);
            IRobot robot = this.garage.Robots[robotName];
          
            if (this.procedures.ContainsKey("Work"))
            {
                this.procedures["Work"].DoService(robot, procedureTime);
            }
            else
            {
                IProcedure work = new Work();
                this.procedures.Add("Work", work);
                this.procedures["Work"].DoService(robot, procedureTime);
            }
            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }
        public string Charge(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);
            IRobot robot = this.garage.Robots[robotName];
            
            if (this.procedures.ContainsKey("Charge"))
            {
                this.procedures["Charge"].DoService(robot, procedureTime);
            }
            else
            {
                IProcedure charge = new Charge();
                this.procedures.Add("Charge", charge);
                this.procedures["Charge"].DoService(robot, procedureTime);
            }
            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }


        public string Polish(string robotName, int procedureTime)
        {
            CheckIfRobotExists(robotName);
            IRobot robot = this.garage.Robots[robotName];
          
            if (this.procedures.ContainsKey("Polish"))
            {
                this.procedures["Polish"].DoService(robot, procedureTime);
            }
            else
            {
                IProcedure polish = new Polish();
                this.procedures.Add("Polish", polish);
                this.procedures["Polish"].DoService(robot, procedureTime);
            }
            return String.Format(OutputMessages.PolishProcedure, robotName);
        }
        public string Sell(string robotName, string ownerName)
        {
            CheckIfRobotExists(robotName);
            IRobot robot = this.garage.Robots[robotName];
            if (robot.IsChipped)
            {
                robot.Owner = ownerName;
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                robot.Owner = ownerName;
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }
        public string History(string procedureType)
        {
            Procedure procedure = (Procedure)this.procedures[procedureType];
            return procedure.History();
            //Returns information about all robots which had current procedure type in the format:
            //"{procedure type}"
            //" Robot type: {robot type1} - {robot name1} - Happiness: {robot happiness1} - Energy: {robot energy1}"
            //" Robot type: {robot type2} - {robot name2} - Happiness: {robot happiness2} - Energy: {robot energy2}"

        }






        private void CheckIfRobotExists(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
