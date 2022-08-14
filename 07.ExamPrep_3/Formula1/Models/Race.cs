namespace Formula1.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities;

    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private readonly List<IPilot> pilots;

        public Race(string raceName, int laps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = laps;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return this.raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return this.numberOfLaps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value; 
            }
        }

        public bool TookPlace { get; set; } = false;

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot) => this.Pilots.Add(pilot);


        public string RaceInfo()
        {
            var sb = new StringBuilder();
            var tookPlayce = this.TookPlace == true ? "Yes" : "No";

            sb
                .AppendLine($"The {this.RaceName} race has:")
                .AppendLine($"Participants: {this.Pilots.Count(x => x.CanRace == true)}")
                .AppendLine($"Number of laps: {this.NumberOfLaps}")
                .AppendLine($"Took place: {tookPlayce}");

            return sb.ToString().TrimEnd();
        }
    }
}
