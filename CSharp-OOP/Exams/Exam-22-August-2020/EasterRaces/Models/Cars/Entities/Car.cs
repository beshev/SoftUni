using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string _model;
        private int _horsePower;
        private double _cubicCentimeters;
        private int _minHorsePower;
        private int _maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this._minHorsePower = minHorsePower;
            this._maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get => this._model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                this._model = value;
            }
        }

        public int HorsePower
        {
            get => this._horsePower;
            private set
            {
                if ((value >= this._minHorsePower && value <= this._maxHorsePower) == false)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this._horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get => this._cubicCentimeters;
            private set
            {
                this._cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
