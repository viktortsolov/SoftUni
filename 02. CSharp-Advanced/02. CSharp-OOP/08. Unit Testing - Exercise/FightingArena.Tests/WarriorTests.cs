using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Ivan", 10, 10)]
        [TestCase("Stoyan", 20, 30)]
        [TestCase("George", 213, 0)]
        public void WarriorConstructorShouldSetDataProperly(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase("", 20, 20)]
        [TestCase("", 20, 20)]
        [TestCase(null, 20, 20)]
        public void WarriorConstructorShoudlThrowExceptionIfInvalidNameIsPassed(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 0, 20)]
        [TestCase("Stoyan", -11, 20)]
        public void WarriorConstructorShoudlThrowExceptionIfInvalidDamageIsPassed(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 32, -123)]
        [TestCase("Stoyan", 32, -1)]
        public void WarriorConstructorShoudlThrowExceptionIfInvalidHPIsPassed(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 10, 10, "Stoyan", 10, 10)]
        [TestCase("Ivan", 10, 100, "Stoyan", 10, 10)]
        [TestCase("Ivan", 10, 50, "Stoyan", 100, 50)]
        public void WarriorAttackOperationMethodShouldThrowInvalidOperationExceptionIfHPIsInvalid(string fighterName, int fighterDamage, int fighterHP,
            string deffenderName, int deffenderDamage, int deffenderHP)
        {
            var fighter = new Warrior(fighterName, fighterDamage, fighterHP);
            var deffender = new Warrior(deffenderName, deffenderDamage, deffenderHP);

            Assert.Throws<InvalidOperationException>(() => fighter.Attack(deffender));
        }

        [Test]
        [TestCase("Ivan", 10, 50, 40, "Stoyan", 10, 50, 40)]
        [TestCase("Ivan", 20, 100, 90, "Stoyan", 10, 70, 50)]
        public void WarriorAttackOperationMethodShouldDecreaseHP(string fighterName, int fighterDamage, int fighterHP, int fighterHPLeft,
            string deffenderName, int deffenderDamage, int deffenderHP, int deffenderHPLeft)
        {
            var fighter = new Warrior(fighterName, fighterDamage, fighterHP);
            var deffender = new Warrior(deffenderName, deffenderDamage, deffenderHP);

            fighter.Attack(deffender);

            Assert.AreEqual(fighterHPLeft, fighter.HP);
            Assert.AreEqual(deffenderHPLeft, deffender.HP);
        }
    }
}