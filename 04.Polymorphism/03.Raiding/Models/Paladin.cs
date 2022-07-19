using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PaladinBasePower = 100;
        public Paladin(string name)
            : base(name, PaladinBasePower)
        {

        }

        public override int Power
            => PaladinBasePower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
