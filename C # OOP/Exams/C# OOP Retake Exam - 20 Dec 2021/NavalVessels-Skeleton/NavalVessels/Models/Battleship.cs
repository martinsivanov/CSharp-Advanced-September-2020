namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private const int INITIAL_ARMOR = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, INITIAL_ARMOR)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                this.SonarMode = true;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                this.SonarMode = false;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < INITIAL_ARMOR)
            {
                this.ArmorThickness = INITIAL_ARMOR;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var mode = this.SonarMode ? "ON" : "OFF";
            sb.Append($" *Sonar mode: {mode}");
            return sb.ToString();
        }
    }
}
