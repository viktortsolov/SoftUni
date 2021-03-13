using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeDependentValue()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorExists()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Stoyan", 10, 10);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void EnrollShouldAddWarriorToCollection()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Stoyan", 10, 10);

            arena.Enroll(warrior);

            var expectedCount = 1;
            var isAny = arena.Warriors.Any(x => x.Name == "Stoyan");

            Assert.AreEqual(expectedCount, arena.Count);
            Assert.IsTrue(isAny);
        }

        [Test]
        [TestCase("Gosho", "Stoyan")]
        public void FightShouldThrowExceptionIfWarriorDoesntExist(string fighter, string deffender)
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(() => arena.Fight(fighter, deffender));

            Warrior warrior = new Warrior(fighter, 10, 10);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(fighter, deffender));
        }
    }
}
