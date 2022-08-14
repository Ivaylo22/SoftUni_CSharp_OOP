using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;
        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.Name == name)
                {
                    return weapon;
                }
            }
            return null;
        }

        public bool Remove(IWeapon model)
        {
            foreach (var weapon in weapons)
            {
                if (weapon == model)
                {
                    this.weapons.Remove(weapon);
                    return true;
                }
            }
            return false;
        }
    }
}
