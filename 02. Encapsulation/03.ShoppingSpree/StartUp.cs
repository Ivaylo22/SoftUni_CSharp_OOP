using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var peopleDict = new Dictionary<string, Person>();
            var productsDict = new Dictionary<string, Product>();

            try
            {
                string people = Console.ReadLine();
                string[] peopleValues = people.Split(";");
                for (int i = 0; i < peopleValues.Length; i++)
                {
                    string[] personValue = peopleValues[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = personValue[0];
                    int money = int.Parse(personValue[1]);
                    Person person = new Person(name, money);
                    peopleDict[name] = person;
                }

                string products = Console.ReadLine();
                string[] productsValues = products.Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productsValues.Length; i++)
                {
                    string[] productValue = productsValues[i].Split("=");
                    string name = productValue[0];
                    int cost = int.Parse(productValue[1]);
                    Product product = new Product(name, cost);
                    productsDict[name] = product;
                }

                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    string[] tokens = input.Split();
                    string buyerName = tokens[0];
                    string productName = tokens[1];

                    int personMoney = peopleDict[buyerName].Money;
                    int productMoney = productsDict[productName].Cost;

                    if (personMoney < productMoney)
                    {
                        Console.WriteLine($"{buyerName} can't afford {productName}");
                    }

                    else
                    {
                        peopleDict[buyerName].Money -= productMoney;
                        peopleDict[buyerName].Products.Add(productName);
                        Console.WriteLine($"{buyerName} bought {productName}");
                    }

                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }


            foreach (string name in peopleDict.Keys)
            {
                if (peopleDict[name].Products.Count == 0)
                {
                    Console.WriteLine($"{name} - Nothing bought");
                }
                else
                {
                    string boughtProducts = string.Join(", ", peopleDict[name].Products);
                    Console.WriteLine($"{name} - {boughtProducts}");
                }

            }
        }
    }

}
