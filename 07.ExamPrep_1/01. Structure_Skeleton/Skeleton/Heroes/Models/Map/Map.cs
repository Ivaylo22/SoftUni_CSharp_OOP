using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {         
            var barbarians = new List<Barbarian>();
            var knights = new List<Knight>();

            foreach (IHero player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                    else if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero type");
                    }
                }
                
            }

            bool continueBattle = true;

            while (continueBattle)
            {
                bool allKnightsAreDead = true;
                bool allBarbariansAreDead = true;

                int aliveKnights = 0;
                int aliveBarbarians = 0;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        aliveKnights++;

                        foreach (var barbarian in barbarians)
                        {
                            int weaponDamage = knight.Weapon.DoDamage();

                            barbarian.TakeDamage(weaponDamage);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbariansAreDead = false;
                        aliveBarbarians++;


                        foreach (var knight in knights)
                        {
                            int weaponDamage = barbarian.Weapon.DoDamage();

                            knight.TakeDamage(weaponDamage);
                        }
                    }
                }

                if (allKnightsAreDead)
                {
                    var deadBarbarians = barbarians.Count - aliveBarbarians;
                    return $"The barbarians took {deadBarbarians} casualties but won the battle.";
                }

                if (allBarbariansAreDead)
                {
                    var deadKnights = knights.Count - aliveKnights;
                    return $"The knights took {deadKnights} casualties but won the battle.";
                }

            }

            throw new InvalidOperationException("The map fight logic has a bug");
        }
    }
}
