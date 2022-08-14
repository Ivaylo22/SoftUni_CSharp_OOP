using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities
{
    public class HeroHealthLessThan0Exception : ArgumentException
    {
        public HeroHealthLessThan0Exception()
        {
        }

        public HeroHealthLessThan0Exception(string message) 
            : base(message)
        {
        }
    }
}
