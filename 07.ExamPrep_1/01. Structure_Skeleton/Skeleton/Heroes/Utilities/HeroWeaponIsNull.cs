using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities
{
    public class HeroWeaponIsNull : ArgumentException
    {
        public HeroWeaponIsNull()
        {
        }

        public HeroWeaponIsNull(string message) 
            : base(message)
        {
        }
    }
}
