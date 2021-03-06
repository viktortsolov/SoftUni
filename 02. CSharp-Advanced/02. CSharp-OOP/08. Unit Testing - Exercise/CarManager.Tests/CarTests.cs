using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("VW", "Golf 3", 10, 100)]
        [TestCase("BMW", "Troika dizel", 20, 100)]
        public void CarConstructorShouldSetAllDataCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange /Act
            Car car = new Car(
                make: make,
                model: model,
                fuelConsumption: fuelConsumption,
                fuelCapacity: fuelCapacity);

            //Assert
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Golf", 10, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void CarConstructorShouldThrowExceptionIfFuelConsumptionIsBelowOrEqualToZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", fuelConsumption, 10));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", model, 10, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-50)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsBelowOrEqualToZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExceptionWhenPassedValueIsBelowOrEqualToZero(double value)
        {
            Car car = new Car("VW", "Passat", 10, 1000);
            Assert.Throws<ArgumentException>(() => car.Refuel(value));
        }

        [Test]
        [TestCase(100, 50, 50)]
        [TestCase(200, 350, 200)]
        public void RefuelShouldWorkAsExpected(double fuelCapacity, double fuelToRefuel, double expectedResult)
        {
            //Arrange
            Car car = new Car("VW", "Passat", 10, fuelCapacity);

            //Act
            car.Refuel(fuelToRefuel);

            //Assert
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10, 50, 505)]
        [TestCase(15, 30, 201)]
        public void DriveShouldThrowExceptionIfFuelAmountIsNotEnough(double fuelConsumption, double refuel, double km)
        {
            //Arrange
            Car car = new Car("VW", "Passat", fuelConsumption, 100);

            //Assert Act
            car.Refuel(refuel);
            Assert.Throws<InvalidOperationException>(() => car.Drive(km));
        }

        [Test]
        [TestCase(10, 100, 50, 95)]
        public void DriveShouldReduceFuelBasedOnDriveKm(double fuelConsumption, double fuel, double km, double fuelAmountLeft)
        {
            //Arrange
            Car car = new Car("VW", "Golf", fuelConsumption, 100);

            car.Refuel(fuel);

            //Act
            car.Drive(km);

            //Assert
            var expectedValue = fuelAmountLeft;
            var actualValue = car.FuelAmount;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}