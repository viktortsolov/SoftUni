using FakeAxeAndDummy.Contracts;
using Moq;

public class StartUp
{
    static void Main(string[] args)
    {
        Mock<IAttackable> target = new Mock<IAttackable>();
        target.Setup(t => t.GiveExperience()).Returns(20);

        Mock<IWeapon> weapon = new Mock<IWeapon>();
        weapon.Setup(w => w.AttackPoints).Returns(55);
        weapon.Setup(w => w.DurabilityPoints).Returns(30);

        System.Console.WriteLine($"Fake Attack: {weapon.Object.AttackPoints}");
        System.Console.WriteLine($"Fake Durability: {weapon.Object.DurabilityPoints}");
        weapon.Object.Attack(target.Object);

        int exp = target.Object.GiveExperience();
        System.Console.WriteLine(exp);

        Hero hero = new Hero("Pesho", weapon.Object);
    }
}
