using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCallories
{
    public class Topping
    {
        private string name;
        private int weight;

        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private Dictionary<string, double> types = new Dictionary<string, double>() 
        {          
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name 
        {
            get
            {   
                return this.name;
            }
            private set 
            {
                if (!types.ContainsKey(value.ToLower())) 
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.name = value.ToLower();
            }
        }

        public int Weight 
        {
            get
            {
                return this.weight;
            }
            private set 
            {
                if (value < MinWeight || value > MaxWeight) 
                {
                    throw new ArgumentException($"{char.ToUpper(this.Name[0]) + this.Name.Substring(1)} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double CalculateToppingCalories() 
        {
            double sum = 2 * this.Weight * types[this.Name];
            return sum;
        }
    }
}
