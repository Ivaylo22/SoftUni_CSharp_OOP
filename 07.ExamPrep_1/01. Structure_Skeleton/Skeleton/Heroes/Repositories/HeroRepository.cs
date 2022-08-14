using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;
        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes;


        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            foreach (var hero in heroes)
            {
                if (hero.Name == name)
                {
                    return hero;
                }
            }
            return null;
        }

        public bool Remove(IHero model)
        {
            foreach (var hero in heroes)
            {
                if (hero == model)
                {
                    heroes.Remove(hero);
                    return true;
                }
            }
            return false;
        }
    }
}
