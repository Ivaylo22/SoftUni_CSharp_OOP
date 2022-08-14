namespace AquaShop.Core.Contracts
{
    using Models;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Controller :IController
    {
        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new HashSet<IAquarium>();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);

            }
            else if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);

            }
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(n => n.Name == aquariumName);
            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            else
            {
                aquarium?.AddDecoration(decoration);
                decorations.Remove(decoration);

                return $"Successfully added {decorationType} to {aquariumName}.";
            }

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(n => n.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                if (aquarium is FreshwaterAquarium)
                {
                    IFish fishToAdd = new FreshwaterFish(fishName, fishSpecies, price);
                    aquarium.AddFish(fishToAdd);
                    return $"Successfully added {fishType} to {aquariumName}";
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
            }

            else if (fishType == "SaltwaterFish")
            {
                if (aquarium is SaltwaterAquarium )
                {
                    IFish fishToAdd = new SaltwaterFish(fishName, fishSpecies, price);
                    aquarium.AddFish(fishToAdd);
                    return $"Successfully added {fishType} to {aquariumName}";
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }
        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(n => n.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(n => n.Name == aquariumName);
            var fishPrice = aquarium.Fish.Sum(n => n.Price);
            var decorationPrice = aquarium.Decorations.Sum(n => n.Price);
            var totalPrice = fishPrice + decorationPrice;

            return $"The value of Aquarium {aquariumName} is {totalPrice:f2}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                string fishReport = aquarium.Fish.Count == 0
                    ? "none" 
                    : string.Join(", ", aquarium.Fish.Select(n => n.Name).ToArray());
                sb
                    .AppendLine($"{aquarium.Name} ({aquarium.GetType().Name}):")
                    .AppendLine($"Fish: {fishReport}")
                    .AppendLine($"Decorations: {aquarium.Decorations.Count}")
                    .AppendLine($"Comfort: {aquarium.Comfort}");
            }
            return sb.ToString().Trim();
           
        }
    }
}
