using _04.WildFarm.Core;
using _04.WildFarm.Factories;
using _04.WildFarm.Factories.Interfaces;
using System;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IEngine engine = new Engine(foodFactory, animalFactory);
            engine.Start();
        }
    }
}
