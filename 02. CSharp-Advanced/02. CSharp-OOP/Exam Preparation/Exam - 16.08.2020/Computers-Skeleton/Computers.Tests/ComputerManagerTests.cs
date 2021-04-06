using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddComputerMethodShouldThrowExceptionWhenComputerExists()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Computer computer = new Computer("IBM", "2", 2m);
                ComputerManager computerManager = new ComputerManager();

                computerManager.AddComputer(computer);
                computerManager.AddComputer(computer);
            });
        }
            
        [Test]
        public void AddComputerMethodShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = null;
                ComputerManager computerManager = new ComputerManager();

                computerManager.AddComputer(computer);
            });
        }

        [Test]
        public void GetComputerThrowsExceptionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                =>
            {
                Computer computer = new Computer("IBM", null, 2m);
                ComputerManager computerManager = new ComputerManager();

                computerManager.AddComputer(computer);
                computerManager.GetComputer("IBM", null);
            });
        }

        [Test]
        public void GetComputerThrowsExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                =>
            {
                Computer computer = new Computer(null, "yes", 2m);
                ComputerManager computerManager = new ComputerManager();

                computerManager.AddComputer(computer);
                computerManager.GetComputer(null, "yes");
            });
        }

        [Test]
        public void GetComputerMethodShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ComputerManager computerManager = new ComputerManager();

                computerManager.GetComputer("sda", "sda");
            });
        }

        [Test]
        public void GetComputerShouldWork()
        {
            Computer computer = new Computer("IBM", "A1", 2m);
            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            var expectedResult = computer;
            var actualResult = computerManager.GetComputer("IBM", "A1");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveCompuerShouldWork()
        {
            Computer computer = new Computer("IBM", "A1", 2m);
            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(computer);

            var expectedResult = computer;
            var actualResult = computerManager.RemoveComputer("IBM", "A1");

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}