namespace TheRace
{
    public class UnitCar
    {
        //TODO: TEST - DONE
        public UnitCar(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model { get; }

        public int HorsePower { get; }

        public double CubicCentimeters { get; }
    }
}