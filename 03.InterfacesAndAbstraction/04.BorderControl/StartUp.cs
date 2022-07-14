using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> all = new List<IIdentifiable>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 3)
                {
                    all.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 2)
                { 
                    all.Add(new Robot(tokens[0], tokens[1]));
                }
                command = Console.ReadLine();
            }

            string lastDigits = Console.ReadLine();

            all.Where(x => x.Id.EndsWith(lastDigits))
                .Select(x => x.Id)
                .ToList()
                .ForEach(Console.WriteLine);                      
        }
    }
}
