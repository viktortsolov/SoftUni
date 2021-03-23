using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenNullIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var raceEntry = new RaceEntry();
                raceEntry.AddDriver(null);
            });
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriverAlreadyExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var raceEntry = new RaceEntry();
                var unitCar = new UnitCar("Golf 4", 90, 2000);
                var unitDriver = new UnitDriver("Gosho", unitCar);

                raceEntry.AddDriver(unitDriver);
                raceEntry.AddDriver(unitDriver);
            });
        }

        [Test]
        public void AddDriverMethodShouldWork()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("Golf 4", 90, 2000);
            var unitDriver = new UnitDriver("Gosho", unitCar);

            var actualResult = raceEntry.AddDriver(unitDriver);
            var expectedResult = $"Driver {unitDriver.Name} added in race.";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculateHprsePowerShouldThrowExceptionWhenDriversAreNotEnough()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var raceEntry = new RaceEntry();
                var unitCar = new UnitCar("Golf 4", 90, 2000);
                var unitDriver = new UnitDriver("Gosho", unitCar);

                raceEntry.AddDriver(unitDriver);

                raceEntry.CalculateAverageHorsePower();
            });
        }
    }
}