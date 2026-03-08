using System;

namespace RapidPack.Models
{
    public class ParcelCalculator
    {
        public const double MaxWeight = 30.0;

        public decimal Calculate(double weight, string type, double h, double w, double d, bool isExpress)
        {
            if (weight > MaxWeight)
            {
                throw new ArgumentException($"Paczka jest za ciężka! Max: {MaxWeight} kg.");
            }

            decimal price;

            if (type == "Paleta")
            {
                price = 100m;
            }
            else
            {
                price = 10m + ((decimal)weight * 2m);
            }

            if ((h + w + d) > 150)
            {
                price *= 1.5m;
            }

            if (isExpress)
            {
                price += 25m;
            }

            return price;
        }
    }
}