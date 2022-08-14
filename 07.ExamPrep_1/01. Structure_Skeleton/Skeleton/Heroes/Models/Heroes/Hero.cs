using Heroes.Models.Contracts;
using System;
using Heroes.Utilities;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        private bool isAlive;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
            
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new HeroNameIsNullOrEmptyException("Hero name cannot be null or empty.");
                }
                this.name = value; 
            }
        }

        public int Health
        {
            get { return this.health; }
            private set 
            {
                if (value < 0)
                {
                    throw new HeroHealthLessThan0Exception("Hero health cannot be below 0.");
                }
                this.health = value; 
            }
        }

        public int Armour
        {
            get { return this.armour; }
            private set
            {
                if (value < 0)
                {
                    throw new HeroArmourLessThan0Exception("Hero armour cannot be below 0.");
                }
            }
        }


        public IWeapon Weapon
        {
            get { return this.weapon; }
            private set
            {
                if (value == null)
                {
                    throw new HeroWeaponIsNull("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon) => this.Weapon = weapon;
        
        public void TakeDamage(int points)
        {
            int leftArmour = this.Armour - points;

            if (leftArmour > 0)
            {
                this.Armour = leftArmour;
            }

            else
            {
                this.Armour = 0;

                var damage = -leftArmour;

                var leftHealth = this.Health - damage;

                if (leftHealth < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health = leftHealth;
                }
            }
        }
    }
}
