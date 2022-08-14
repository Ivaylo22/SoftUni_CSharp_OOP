using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            string heroAlias = null;
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            else
            {
                if (type == "Barbarian")
                {
                    IHero hero = new Barbarian(name, health, armour);
                    heroes.Add(hero);
                    heroAlias = $"Barbarian {name}";
                }
                else if (type == "Knight")
                {
                    IHero hero = new Knight(name, health, armour);
                    heroes.Add(hero);
                    heroAlias = $"Sir {name}";
                }
                else
                {
                    throw new InvalidOperationException("Invalid hero type.");
                }
                return $"Successfully added {heroAlias} to the collection.";
            } 
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            else
            {
                if (type == "Mace")
                {
                    IWeapon weapon = new Mace(name, durability);
                    weapons.Add(weapon);
                    return $"A {type.ToLower()} {name} is added to the collection.";
                }
                else if (type == "Claymore")
                {
                    IWeapon weapon = new Claymore(name, durability);
                    weapons.Add(weapon);
                    return $"A {type.ToLower()} {name} is added to the collection.";
                }
                else
                {
                    throw new InvalidOperationException("Invalid weapon type.");
                }
            }
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);

            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            else if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            else if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            else
            {
                hero.AddWeapon(weapon);
                weapons.Remove(weapon);
                return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
            }
        }
        public string StartBattle()
        {
            IMap map = new Map();
            var heroesAttack = heroes
                .Models
                .Where(h => h.IsAlive && h.Weapon != null)
                .ToList();
            return map.Fight(heroesAttack);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            var sortedHero = heroes
                .Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);

            foreach (var hero in sortedHero)
            {
                string weaponName = "Unarmed";
                if (hero.Weapon != null)
                {
                    weaponName = hero.Weapon.Name;
                }
                sb.AppendLine($"{hero.GetType()}: {hero.Name}")
                    .AppendLine($"--Health: {hero.Health}")
                    .AppendLine($"--Armour: {hero.Armour}")
                    .AppendLine($"--Weapon: {weaponName}");             
            }
            return sb.ToString().Trim();
        }

    }
}
