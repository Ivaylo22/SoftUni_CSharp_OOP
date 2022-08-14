using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities
{
    public class HeroArmourLessThan0Exception : ArgumentException
    {
        public HeroArmourLessThan0Exception()
        {
        }

        public HeroArmourLessThan0Exception(string message) 
            : base(message)
        {
        }
    }
}
