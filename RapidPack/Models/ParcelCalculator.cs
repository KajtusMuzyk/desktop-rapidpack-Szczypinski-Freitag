using System;

namespace RapidPack.Models
{
    public class ParcelCalculator
    {
        private const double MaxWeight = 30.0;

        public void ValidateWeight(double weight)
        {
            if (weight > MaxWeight)
            {
                throw new ArgumentException($"Paczka jest za ciężka ({weight} kg). Maksimum to {MaxWeight} kg!");
            }
        }
    }
}