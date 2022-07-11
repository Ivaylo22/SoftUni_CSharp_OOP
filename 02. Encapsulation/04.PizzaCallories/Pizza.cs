using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCallories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza()
        {
            Toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
            :this()
        {
            this.Name = name;
            this.Dough = dough;
        }

        public string Name 
        {
            get
            { 
                return this.name;
            }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15) 
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public List<Topping> Toppings { get;}

        public void AddTopping(Topping topping) 
        {
            if (Toppings.Count >= 10)
            {           
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }

        private double CalcolateCalories(Dough dough, List<Topping> toppings) 
        {
            double sum = 0;
            sum += dough.CalculateDoughCalories();
            foreach (var topping in toppings)
            {
                sum += topping.CalculateToppingCalories();
            }
            return sum;
        }

        public string ToStringResult(Dough dough, List<Topping> toppings)
        {
            return $"{this.Name} - {CalcolateCalories(dough, toppings):f2} Calories.";
        }
    }
}
