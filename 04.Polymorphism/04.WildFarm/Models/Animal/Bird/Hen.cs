using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Bird
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }
        public override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>() { typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable) }
            .AsReadOnly();

        protected override double WeightMultiplier
            => HenWeightMultiplier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
