using Heroes.Models.Contracts;
using Heroes.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new WeaponTypeIsNullOrEmptyException("Weapon type cannot be null or empty.");
                }
                this.name = value; 
            }
        }


        public int Durability
        {
            get { return this.durability; }
            protected set 
            {
                if (value < 0)
                {
                    throw new WeaponDurabilityLessThan0Exception("Durability cannot be below 0.");
                }
                this.durability = value;
            }
        }

        public abstract int DoDamage();

    }
}
