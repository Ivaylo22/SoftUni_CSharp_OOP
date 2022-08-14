using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private readonly UnitRepository units;
        private readonly WeaponRepository weapons;

        private string name;
        private double budget;
        private double militaryPower;

        public Planet()
        {
            this.units = new UnitRepository(); 
            this.weapons = new WeaponRepository();
        }

        public Planet(string name, double budget)
            : this()
        {
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value; 
            }
        }

        public double MilitaryPower
        {
            get
            {
                double sumUnitEndurance;
                double sumWeaponDestLevel;
                double totalAmount;

                sumUnitEndurance = Army.Sum(units => units.Cost);

                sumWeaponDestLevel = Weapons.Sum(weapon => weapon.Price);

                totalAmount = sumWeaponDestLevel + sumUnitEndurance;


                if(Army.Any(unit => unit.GetType().Name == "AnonymousImpactUnit"))
                {
                    totalAmount *= 1.3;
                }

                if (Weapons.Any(wep => wep.GetType().Name == "NuclearWeapon"))
                {
                    totalAmount = totalAmount * 1.45;
                }

                return Math.Round(totalAmount, 3);

            }
            private set 
            {
                this.militaryPower = value;
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            string forcesNames = Army.Count > 0 
                ? String.Join(", ", Army.Select(unit => unit.GetType().Name)) 
                : "No units";

            string weaponsNames = Weapons.Count > 0 
                ? String.Join(", ", Weapons.Select(weapon => weapon.GetType().Name)) 
                : "No weapons";


            sb
                .AppendLine($"{this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"--Forces: {forcesNames}")
                .AppendLine($"--Combat equipment: {weaponsNames}")
                .AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            else
            {
                this.Budget -= amount;
            }
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
