namespace Formula1.Models
{
    using Contracts;
    using System;
    using Utilities;
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;
        public FormulaOneCar(string model, int horsePower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsePower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get { return this.model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException($"Invalid car model: {value}.");
                }
                this.model = value; 
            }
        }

        public int Horsepower
        {
            get { return this.horsePower; }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: {value}.");
                }
                this.horsePower = value; 
            }
        }

        public double EngineDisplacement
        {
            get { return this.engineDisplacement; }
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException($"Invalid car engine displacement: {value}.");
                }
                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps) => this.EngineDisplacement / this.Horsepower * laps;


    }
}
