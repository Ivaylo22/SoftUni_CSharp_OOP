using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            var planet = new Planet(name, budget);

            foreach (var pl in planets.Models)
            {
                if (pl.Name == name)
                {
                    return String.Format(OutputMessages.ExistingPlanet, name);
                }
            }
            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            MilitaryUnit addUnit = null;
            IPlanet myPlanet = planets.FindByName(planetName);

            if (unitTypeName == "AnonymousImpactUnit")
            {
                addUnit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                addUnit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                addUnit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (myPlanet == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if(myPlanet.Army.Any(name => name.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException
                        (String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            myPlanet.Spend(addUnit.Cost);

            myPlanet.AddUnit(addUnit);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            Weapon addWeapon = null;
            IPlanet myPlanet = planets.FindByName(planetName);

            if (weaponTypeName == "BioChemicalWeapon")
            {
                addWeapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                addWeapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                addWeapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (myPlanet == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (myPlanet.Weapons.Any(name => name.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException
                        (String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            myPlanet.Spend(addWeapon.Price);

            myPlanet.AddWeapon(addWeapon);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }

        public string SpecializeForces(string planetName)
        {
            IPlanet myPlanet = (planets.FindByName(planetName));

            if (myPlanet == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (myPlanet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            myPlanet.Spend(1.25);
            myPlanet.TrainArmy();
            return String.Format(OutputMessages.ForcesUpgraded, planetName);

        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = (planets.FindByName(planetOne));
            IPlanet planet2 = (planets.FindByName(planetTwo));

            IPlanet winner = null;
            IPlanet loser = null;

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(n => n.GetType().Name == "NuclearWeapon") &&
                    !planet2.Weapons.Any(n => n.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet1;
                    loser = planet2;
                }

                else if (!planet1.Weapons.Any(n => n.GetType().Name == "NuclearWeapon") &&
                    planet2.Weapons.Any(n => n.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet2;
                    loser = planet1;
                }

                else
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return OutputMessages.NoWinner;
                }

            }

            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                loser = planet2;
            }
            else
            {
                winner = planet2;
                loser = planet1;
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loser.Army.Sum(unit => unit.Cost));
            winner.Profit(loser.Weapons.Sum(unit => unit.Price));
            planets.RemoveItem(loser.Name);

            return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(pl => pl.MilitaryPower).ThenBy(pl => pl.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }


    }
}
