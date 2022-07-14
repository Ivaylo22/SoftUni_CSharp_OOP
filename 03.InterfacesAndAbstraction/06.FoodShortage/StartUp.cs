using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> allBuyers = new List<IBuyer>();

            string personInfo;
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                personInfo = Console.ReadLine();

                string[] tokens = personInfo.Split();
                if (tokens.Length == 4)
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    allBuyers.Add(citizen);
                }
                else if (tokens.Length == 3)
                {
                    Rebel rebel = new Rebel(tokens[0], int.Parse(tokens[1]));
                    allBuyers.Add(rebel);
                }
            }

            string name = Console.ReadLine();

            while (name != "End")
            {
                foreach (var person in allBuyers)
                {
                    if (person.Name == name)
                    {
                        person.BuyFood();
                    }
                }
                name = Console.ReadLine(); 
            }

            Console.WriteLine(allBuyers.Sum(x => x.Food));

        }
    }
}
