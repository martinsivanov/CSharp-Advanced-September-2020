namespace NavalVessels.Core
{
    using NavalVessels.Core.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICollection<ICaptain> captains;

        public Controller()
        {
            this.captains = new List<ICaptain>();
            this.vessels = new VesselRepository();
        }
        public string HireCaptain(string fullName)
        {

            if (this.captains.Any(x => x.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            var captain = new Captain(fullName);
            this.captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            if (vesselType == "Submarine")
            {
                var submarine = new Submarine(name, mainWeaponCaliber, speed);
                this.vessels.Add(submarine);

                return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                var battleship = new Battleship(name, mainWeaponCaliber, speed);
                this.vessels.Add(battleship);

                return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!this.captains.Any(x => x.FullName == selectedCaptainName))
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (this.vessels.FindByName(selectedVesselName) == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (this.vessels.FindByName(selectedVesselName).Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            var vessel = this.vessels.FindByName(selectedVesselName);
            var captain = this.captains.First(x => x.FullName == selectedCaptainName);
            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }
        public string CaptainReport(string captainFullName)
        {
            var captain = this.captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }
        public string VesselReport(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            return vessel.ToString();
        }
        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            if (vessel != null && vessel.GetType().Name == "Battleship")
            {
                var battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if (vessel != null && vessel.GetType().Name == "Submarine")
            {
                var submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
            else
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = this.vessels.FindByName(attackingVesselName);
            var defender = this.vessels.FindByName(defendingVesselName);

            if (attacker == null && defender == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (attacker != null && defender == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (attacker == null && defender != null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }


            if (attacker.ArmorThickness == 0 && defender.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (attacker.ArmorThickness != 0 && defender.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            if (attacker.ArmorThickness == 0 && defender.ArmorThickness != 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }



            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defender.Name, attacker.Name, defender.ArmorThickness);
        }
    }
}
