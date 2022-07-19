using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Mammal
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new List<Type>() {typeof(Vegetable), typeof(Meat)}.AsReadOnly();

        protected override double WeightMultiplier 
            => CatWeightMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
