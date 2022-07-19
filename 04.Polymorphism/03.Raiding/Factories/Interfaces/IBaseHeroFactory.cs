using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Factories.Interfaces
{
    public interface IBaseHeroFactory
    {
        BaseHero CreateBaseHero(string heroType, string name);
    }
}
