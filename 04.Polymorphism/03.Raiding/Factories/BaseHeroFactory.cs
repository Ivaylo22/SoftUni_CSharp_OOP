using _03.Raiding.Factories.Interfaces;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Factories
{
    public class BaseHeroFactory : IBaseHeroFactory
    {
        BaseHero hero;
        public BaseHero CreateBaseHero(string type, string name)
        {
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if(type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                Console.WriteLine("Invalid hero!");
                return null;
            }
            return hero;
        }
    }
}
