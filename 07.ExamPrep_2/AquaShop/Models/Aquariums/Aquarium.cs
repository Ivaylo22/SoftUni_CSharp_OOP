namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        public Aquarium()
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public Aquarium(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name {
            get { return this.name; } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity {
            get => this.capacity;
            private set 
            {
                this.capacity = value;
            } 
        }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);


        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            else
            {
                this.Fish.Add(fish);
            }
        }
        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);


        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            var fishOutput = this.Fish.Count == 0 ?
                string.Join(", ", this.Fish.Select(f => f.Name))
                : "none";

            sb
                .AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishOutput}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }

    }
}
