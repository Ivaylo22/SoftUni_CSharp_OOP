using System;
using System.Collections.Generic;
using System.Text;
using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }
        
        public virtual int Power { get; private set; }

        public virtual string CastAbility()
        {
            return null;
        }
    }
}
