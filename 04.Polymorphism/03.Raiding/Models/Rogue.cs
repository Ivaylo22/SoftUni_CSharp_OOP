using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RogueBasePower = 80;
        public Rogue(string name)
            : base(name, RogueBasePower)
        {

        }

        public override int Power
            => RogueBasePower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
