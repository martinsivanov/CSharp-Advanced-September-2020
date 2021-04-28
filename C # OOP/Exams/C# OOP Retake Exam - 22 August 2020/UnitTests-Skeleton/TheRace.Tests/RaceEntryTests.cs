using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar unitCar;
        [SetUp]
        public void Setup()
        {
            unitCar = new UnitCar("Car", 1, 100);
        }

        [Test]
        public void TestIfUnitCarConsructorWorksCorrect()
        {
            var unitCar = new UnitCar("Car", 150, 100);

            Assert.AreEqual("Car", unitCar.Model);
            Assert.AreEqual(150, unitCar.HorsePower);
            Assert.AreEqual(100, unitCar.CubicCentimeters);
        }
        [Test]
        public void TestUnitDriverCOnstructorIfWorksCorrect()
        {
            UnitDriver unitDriver = new UnitDriver("Martin", this.unitCar);

            Assert.AreEqual("Martin", unitDriver.Name);
            Assert.AreEqual(this.unitCar, unitDriver.Car);
        }
        [Test]
        public void ShouldThrownExceptionForInvalidName()
        {


            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver unitDriver = new UnitDriver(null, this.unitCar);
            });
        }
        [Test]
        public void ShouldTestRaceEntryConstructorCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.AreEqual(0, raceEntry.Counter);
        }
        [Test]
        public void ShoudThrowInvalidOperationExceptionUnitDriverNull()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = null;
            UnitDriver unitDrive = null;

            Assert.Throws<InvalidOperationException>(() => 
            {
                raceEntry.AddDriver(unitDrive);
            });
        }
        [Test]
        public void ShouldThrowInvalidOperationExceptionForAddingSameDriver()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver unitDriver = new UnitDriver("Martin", this.unitCar);
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => 
            {
                raceEntry.AddDriver(unitDriver);
            });
        }
        [Test]
        public void ShouldAddDriverCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver unitDriver = new UnitDriver("Martin", this.unitCar);
            raceEntry.AddDriver(unitDriver);

            Assert.AreEqual(1, raceEntry.Counter);
        }
        [Test]
        public void ShouldThrowInvalidOperationExceptionForMethodCalculateAverageHorsePower()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver unitDriver = new UnitDriver("Martin", this.unitCar);
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => 
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }
        [Test]
        public void ethodCalculateAverageHorsePowerShouldWorksCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver unitDriver = new UnitDriver("Martin", this.unitCar);
            UnitDriver unitDriver2 = new UnitDriver("Mrtin", this.unitCar);
            UnitDriver unitDriver3 = new UnitDriver("Matin", this.unitCar);

            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriver2);
            raceEntry.AddDriver(unitDriver3);

            raceEntry.CalculateAverageHorsePower();
            Assert.AreEqual(1, raceEntry.CalculateAverageHorsePower());

        }
    }
}