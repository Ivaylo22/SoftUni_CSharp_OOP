using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities
{
    public class HeroNameIsNullOrEmptyException : ArgumentException
    {
        public HeroNameIsNullOrEmptyException()
        {
        }
        public HeroNameIsNullOrEmptyException(string messege)
            : base(messege)
        {

        }
    }
}
