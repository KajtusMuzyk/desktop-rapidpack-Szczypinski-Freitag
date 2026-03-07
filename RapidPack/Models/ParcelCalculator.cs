using System;

namespace RapidPack.Models
{
    public class ParcelCalculator
    {
        public const double MaxWeight = 30.0;

        public decimal Calculate(double weight, string type)
        {
            if (weight > MaxWeight)
            {
                throw new ArgumentException($"Paczka jest za ciężka! Max: {MaxWeight} kg.");
            }

            if (type == "Paleta")
            {
                return 100m; 
            }

            return 10m + ((decimal)weight * 2m);
        }
    }
}