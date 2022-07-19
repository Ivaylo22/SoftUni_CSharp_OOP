using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidBasePower = 80;
        public Druid(string name) 
            : base(name, DruidBasePower)
        {

        }

        public override int Power 
            => DruidBasePower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
