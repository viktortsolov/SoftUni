using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            var expectedResult = 16;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldThrowExpectionIfThereAreNot16Elements()
        {
            //TODO: Refactor this
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            var expectedResult = 10;
            var actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Add(5);
            var allElements = database.Fetch();

            //Assert
            var expectedValue = 5;
            var actualValue = allElements[10];

            var expectedCount = 11;
            var actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfElementsAreAbove16()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(10));
        }

        [Test]
        public void RemoveOperationShouldSupportOnlyRemovingAnElementAtTheLastIndex()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Remove();

            //Assert
            var expectedResult = 9;
            var actualValue = database.Fetch()[8];

            var expectedCount = 9;
            var actualCount = database.Count;

            Assert.AreEqual(expectedResult, actualValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveOperationShouldThrowExpectionIfDatabaseIsEmpty()
        {
            Database.Database database = new Database.Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllElementsAsArray()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var allElements = database.Fetch();

            //Assert
            int[] expectedValue = { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expectedValue, allElements);

        }

    }
}