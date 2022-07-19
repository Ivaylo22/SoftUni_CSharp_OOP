using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorBasePower = 100;
        public Warrior(string name)
            : base(name, WarriorBasePower)
        {

        }

        public override int Power
            => WarriorBasePower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
