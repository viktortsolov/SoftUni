using NUnit.Framework;
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
        public void ConstructorShoulThrowExpectionIfThereAreNot16Elements()
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
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            database.Add(5);

        }
    }
}