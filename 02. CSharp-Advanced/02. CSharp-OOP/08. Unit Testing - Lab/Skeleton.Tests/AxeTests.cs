using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 100, 100, 99)]
    [TestCase(45, 45, 50, 31, 30)]
    public void WeaponShouldLoseDurabilityAfterAtttack(int health, int experiance, int attack, int durability, int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experiance);
        Axe axe = new Axe(attack, durability);

        //Act
        axe.Attack(dummy);

        //Assert
        var actualResult = axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void AttackShouldThrowInvalidOperationExceptionWhenWeaponDurabilityIsBelowZero()
    {
        //Arrange
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(20, 0);

        //Act -- Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}