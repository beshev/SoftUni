using _03.Raiding.Common;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private const int POWER = 100;

        public Paladin(string name) : base(name, POWER)
        { }

        public override string CastAbility()
        {
            return string.Format(GlobalConst.HEALING_INFO, this.GetType().Name, this.Name, this.Power);
        }
    }
}