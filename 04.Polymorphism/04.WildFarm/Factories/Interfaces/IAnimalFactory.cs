using _04.WildFarm.Models.Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}
