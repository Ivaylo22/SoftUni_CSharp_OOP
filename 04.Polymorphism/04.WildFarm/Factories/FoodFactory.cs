using _04.WildFarm.Exceptions;
using _04.WildFarm.Factories.Interfaces;
using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            {
                Food food;
                if (type == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }
                else if (type == "Fruit")
                {
                    food = new Fruit(quantity);
                }
                else if (type == "Meat")
                {
                    food = new Meat(quantity);
                }
                else if (type == "Seeds")
                {
                    food = new Seeds(quantity);
                }
                else
                {
                    throw new InvalidFactoryTypeException();
                }

                return food;
            }
        }
    }
}
