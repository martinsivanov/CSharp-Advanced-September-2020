namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Athlete : IAthlete
    {
        private string fullname;
        private string motivation;
        private int numberOfMedals;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName
        {
            get
            {
                return this.fullname;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                this.fullname = value;
            }
        }

        public string Motivation
        {
            get
            {
                return this.motivation;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                this.motivation = value;
            }
        }

        public int Stamina { get; protected set; }

        public int NumberOfMedals
        {
            get
            {
                return this.numberOfMedals;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
