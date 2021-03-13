namespace FakeAxeAndDummy.Contracts
{
    public interface IAttackable
    {
        public int GiveExperience();
        public void TakeAttack(int attackPoints);
        public bool IsDead();
    }
}
