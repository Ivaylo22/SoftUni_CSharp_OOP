using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCallories
{
    public class Dough
    {
        private Dictionary<string, double> flourData = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1.0},
        };

        private Dictionary<string, double> techniqueDate = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0},
        };

        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flour;
        private string technique;
        private int weight;

        public Dough(string flour, string technique, int weight)
        {
            this.Flour = flour;
            this.Technique = technique;
            this.Weight = weight;
        }

        public string Flour 
        {
            get 
            {
                return flour;
            }
            private set
            {
                if (!flourData.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flour = value.ToLower();
            }
        }

        public string Technique
        {
            get
            {
                return technique;
            }
            private set
            {
                if (!techniqueDate.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.technique = value.ToLower();
            }
        }
        public int Weight 
        {
            get
            { 
                return weight;
            }
            private set
            {
                if (value < MinWeight || value > MaxWeight) 
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double CalculateDoughCalories() 
        {
            double sum = 2 * this.Weight * flourData[this.Flour] * techniqueDate[this.Technique];
            return sum;
        }
    }
}
