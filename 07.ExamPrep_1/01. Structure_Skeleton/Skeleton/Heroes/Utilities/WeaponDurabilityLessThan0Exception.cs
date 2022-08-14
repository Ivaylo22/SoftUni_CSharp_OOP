using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities
{
    public class WeaponDurabilityLessThan0Exception : ArgumentException
    {
        public WeaponDurabilityLessThan0Exception()
        {
        }

        public WeaponDurabilityLessThan0Exception(string massege)
            : base(massege)
        {
        }
    }
}
