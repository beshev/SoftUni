using _03.Raiding.Common;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int POWER = 80;

        public Rogue(string name) : base(name, POWER)
        { }

        public override string CastAbility()
        {
            return string.Format(GlobalConst.DAMAGING_INFO,this.GetType().Name,this.Name,this.Power);
        }
    }
}