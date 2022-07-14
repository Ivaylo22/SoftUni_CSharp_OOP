using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> allBirthable = new List<IBirthable>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split();
                string type = tokens[0];

                if (type == "Citizen")
                {
                    Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    allBirthable.Add(citizen);
                }
                else if (type == "Robot")
                {
                    Robot robot = new Robot(tokens[1], tokens[2]);
                }
                else if (type == "Pet")
                {
                    Pet pet = new Pet(tokens[1], tokens[2]);
                    allBirthable.Add(pet);
                }
                command = Console.ReadLine();
            }

            string yearToSeach = Console.ReadLine();

            allBirthable.Where(a => a.BirthDate.EndsWith(yearToSeach))
                .Select(a => a.BirthDate)
                .ToList()
                .ForEach(Console.WriteLine);            
        }
    }
}
