using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models.Interfaces
{
    public interface IBaseHero
    {
        string Name { get;}
        int Power { get; }
        string CastAbility();
    }
}
