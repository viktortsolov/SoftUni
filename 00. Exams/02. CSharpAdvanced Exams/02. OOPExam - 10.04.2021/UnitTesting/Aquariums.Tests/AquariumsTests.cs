namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenAquariumIsFull()
        {
            Assert.Throws<InvalidOperationException>(()
                =>
            {
                Aquarium aquarium = new Aquarium("Ime", 1);
                Fish fish = new Fish("Viksi");
                Fish fishTwo = new Fish("Piksi");

                aquarium.Add(fish);
                aquarium.Add(fishTwo);
            });
        }
        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionWhenFishIsNull()
        {
            Assert.Throws<InvalidOperationException>(()
                =>
            {
                Aquarium aquarium = new Aquarium("Ime", 1);
                Fish fish = new Fish("Viksi");

                aquarium.Add(fish);
                aquarium.RemoveFish("Piksi");
            });
        }
        [Test]
        public void SellFishShouldThrowInvalidOperationExceptionWhenFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(()
                =>
            {
                Aquarium aquarium = new Aquarium("Ime", 1);
                Fish fish = new Fish("Viksi");

                aquarium.Add(fish);
                aquarium.SellFish("Piksi");
            });
        }
        [Test]
        public void ReportShouldWork()
        {
            Aquarium aquarium = new Aquarium("Avka", 1);
            Fish fish = new Fish("Viksi");

            aquarium.Add(fish);

            var expactedResult = $"Fish available at {aquarium.Name}: Viksi";
            var actualResult = aquarium.Report();

            Assert.AreEqual(expactedResult, actualResult);
        }
        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(null, 1);
                Fish fish = new Fish("Viksi");
            });
        }
        [Test]
        public void ConstructorShouldThrowArgumentExceptionWhenCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Akva", -1);
                Fish fish = new Fish("Viksi");
            });
        }
        [Test]
        public void RemoveFishShouldWork()
        {
            Aquarium aquarium = new Aquarium("Ime", 1);
            Fish fish = new Fish("Viksi");

            aquarium.Add(fish);
            aquarium.RemoveFish("Viksi");

            var expectedResult = aquarium.Count;
            var actualReuslt = 0;

            Assert.AreEqual(expectedResult, actualReuslt);
        }
        [Test]
        public void SellFishShuldWork()
        {
            Aquarium aquarium = new Aquarium("Ime", 1);
            Fish fish = new Fish("Viksi");

            aquarium.Add(fish);
            var fishToSell = aquarium.SellFish("Viksi");

            var expectedResult = false;
            var actualReuslt = fishToSell.Available;

            Assert.AreEqual(expectedResult, actualReuslt);
        }
    }
}
