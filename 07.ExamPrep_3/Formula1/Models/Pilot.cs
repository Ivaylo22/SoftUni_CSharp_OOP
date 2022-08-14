namespace Formula1.Models
{
    using Contracts;
    using Utilities;
    using System;
    using System.Text;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get { return this.fullName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullName = value; 
            }
        }
        public bool CanRace { get; private set; } = false;


        public IFormulaOneCar Car
        {
            get { return this.car; }
            private set 
            {
                if (this.car == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }

        public int NumberOfWins { get; private set; } = 0;

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }

    }
}
