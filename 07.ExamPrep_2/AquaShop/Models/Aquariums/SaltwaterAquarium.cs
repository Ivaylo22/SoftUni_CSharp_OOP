using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums.Contracts
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int InitialCapacity = 25;
        public SaltwaterAquarium(string name)
            : base(name, InitialCapacity)
        {

        }
    }
}
