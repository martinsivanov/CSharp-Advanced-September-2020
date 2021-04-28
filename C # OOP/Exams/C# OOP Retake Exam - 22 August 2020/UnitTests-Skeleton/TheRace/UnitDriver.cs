namespace TheRace
{
    using System;

    public class UnitDriver
    {
        private string name;

        //TODO: TEST - DONE
        public UnitDriver(string name, UnitCar car)
        {
            this.Name = name;
            this.Car = car;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                //TODO: TEST - DONE
                this.name = value ?? throw new ArgumentNullException(nameof(Name), "Name cannot be null!");
            }
        }

        public UnitCar Car { get; }
    }
}