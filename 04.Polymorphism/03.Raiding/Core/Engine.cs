using _03.Raiding.Core.Interfaces;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly List<BaseHero> heroesList;

        public Engine(List<BaseHero> heroesList)
        { 
           this.heroesList = heroesList;
        }

        public void Start()
        {
            long totalPower = 0;
            foreach (BaseHero hero in heroesList)
            {
                Console.WriteLine($"{hero.CastAbility()}");
                totalPower += hero.Power;
            }

            long bossPower = long.Parse(Console.ReadLine());
            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
