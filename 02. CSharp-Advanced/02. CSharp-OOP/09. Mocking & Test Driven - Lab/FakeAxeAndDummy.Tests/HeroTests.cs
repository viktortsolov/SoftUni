using FakeAxeAndDummy.Contracts;
using FakeAxeAndDummy.Tests.Fakes;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    Mock<IAttackable> fakeTarget;
    [SetUp]
    public void SetUp()
    {
        fakeTarget = new Mock<IAttackable>();
        fakeTarget.Setup(t => t.GiveExperience()).Returns(20);
        fakeTarget.Setup(t => t.IsDead()).Returns(true);
    }
    [Test]
    public void GivenHero_WhenAttackedTargetDies_ThenHeroRecievesExperience()
    {
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(20, hero.Experience);
    }
}