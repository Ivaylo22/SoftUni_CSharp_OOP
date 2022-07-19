using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Exceptions
{
    public class FoodNotPreferredException : Exception
    {
        public FoodNotPreferredException(string message)
            : base(message)
        {

        }
    }
}
