using _03.Raiding.Core;
using _03.Raiding.Core.Interfaces;
using _03.Raiding.Factories;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class StartUp
    {
        public static List<BaseHero> heroes = new List<BaseHero>();

        static void Main(string[] args)
        {
            try
            {
                BaseHeroFactory baseHeroFactory = new BaseHeroFactory();
                BaseHero currentHero;
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();
                    currentHero = baseHeroFactory.CreateBaseHero(type, name);
                    if (currentHero == null)
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        heroes.Add(currentHero);
                    }
                }

                IEngine engine = new Engine(heroes);
                engine.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
