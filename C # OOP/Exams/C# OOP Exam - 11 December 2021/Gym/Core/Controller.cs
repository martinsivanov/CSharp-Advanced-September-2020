namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Repositories.Contracts;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipments = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            if (gymType == "BoxingGym")
            {
                var boxGym = new BoxingGym(gymName);
                gyms.Add(boxGym);
            }
            if (gymType == "WeightliftingGym")
            {
                var LiftGym = new WeightliftingGym(gymName);
                gyms.Add(LiftGym);
            }
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "Kettlebell" && equipmentType != "BoxingGloves")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            if (equipmentType == "Kettlebell")
            {
                var equipment = new Kettlebell();
                equipments.Add(equipment);
            }
            if (equipmentType == "BoxingGloves")
            {
                var equipment = new BoxingGloves();
                equipments.Add(equipment);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipment = this.equipments.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            var gym = this.gyms.First(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            this.equipments.Remove(equipment);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            if (athleteType == "Boxer")
            {
                var gym = this.gyms.First(x => x.Name == gymName);

                if (gym.GetType().Name != "BoxingGym")
                {
                    throw new InvalidOperationException("The gym is not appropriate.");
                }
                var boxer = new Boxer(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(boxer);
            }
            if (athleteType == "Weightlifter")
            {
                var gym = this.gyms.First(x => x.Name == gymName);

                if (gym.GetType().Name != "WeightliftingGym")
                {
                    throw new InvalidOperationException("The gym is not appropriate.");
                }
                var lifter = new Weightlifter(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(lifter);
            }
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            var gym = this.gyms.First(x => x.Name == gymName);
            gym.Exercise();
            var totalAthletes = gym.Athletes.Count();
            return String.Format(OutputMessages.AthleteExercise, totalAthletes);
        }
        public string EquipmentWeight(string gymName)
        {
            var gym = this.gyms.First(x => x.Name == gymName);
            var value = gym.EquipmentWeight;

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, value);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
