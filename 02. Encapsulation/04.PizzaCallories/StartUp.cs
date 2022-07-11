using System;

namespace _04.PizzaCallories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string pizzaName = pizzaInput[1];

                string[] doughInput = Console.ReadLine().Split();
                string flour = doughInput[1];
                string technique = doughInput[2];
                int weight = int.Parse(doughInput[3]);

                Dough dough = new Dough(flour, technique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();
                while (input != "END") 
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string core = tokens[0];
                    
                    if (core == "Topping")
                    {
                        string name = tokens[1];
                        int toppingWeight = int.Parse(tokens[2]);
                        Topping topping = new Topping(name, toppingWeight);
                        pizza.AddTopping(topping);
                    }
                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToStringResult(dough, pizza.Toppings));
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
