using _03.Raiding.Common;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;

        public Warrior(string name) : base(name, POWER)
        {
        }

        public override string CastAbility()
        {
            return string.Format(GlobalConst.DAMAGING_INFO,this.GetType().Name,this.Name,this.Power);
        }
    }
}