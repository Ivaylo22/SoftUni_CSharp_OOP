using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animalsList = new List<Animal>();

            while (true) 
            {
                try
                {
                    string command = Console.ReadLine();
                    if (command == "Beast!")
                    {
                        break;
                    }
                    string[] animalType = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string name = animalType[0];
                    int age = int.Parse(animalType[1]);

                    Animal animal = null;

                    if (command == "Dog")
                    {
                        string gender = animalType[2];
                        animal = new Dog(name, age, gender);
                    }
                    else if (command == "Frog")
                    {
                        string gender = animalType[2];
                        animal = new Frog(name, age, gender);
                    }
                    else if (command == "Cat")
                    {
                        string gender = animalType[2];
                        animal = new Cat(name, age, gender);
                    }
                    else if (command == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else if (command == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else
                    {
                        throw new Exception("Invalid input!");
                    }

                    animalsList.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
          
            }

            foreach (Animal animal in animalsList)
            {
                Console.WriteLine(animal.ToString()); 
            }
        }
    }
}
