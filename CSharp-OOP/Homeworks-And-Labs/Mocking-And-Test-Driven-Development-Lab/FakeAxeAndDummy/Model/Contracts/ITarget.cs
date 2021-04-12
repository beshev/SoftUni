namespace FakeAxeAndDummy.Model.Contracts
{
    public interface ITarget
    {
        public int Health { get; }

        public void TakeAttack(int attackPoints);

        public int GiveExperience();

        public bool IsDead();
    }
}