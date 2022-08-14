using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities
{
    public class WeaponTypeIsNullOrEmptyException : ArgumentException
    {
        public WeaponTypeIsNullOrEmptyException()
        {

        }

        public WeaponTypeIsNullOrEmptyException(string messege)
            : base(messege)
        {
        }
    }
}
