using System;

namespace RapidPack.Models
{
    public class ParcelCalculator
    {
        public decimal Calculate(double weight, string type, int h, int w, int d, bool isExpress)
        {
            if (weight > 30)
            {
                throw new ArgumentException($"Paczka jest zbyt ciężka! Maksymalna waga to 30kg, a twoja paczka waży {weight}kg");
            }

            decimal price;

            if (type == "Paleta")
            {
                price = 100m;
            }
            else
            {
                price = 10m + ((decimal)weight * 2m);

                if (type == "Ostrożnie")
                {
                    price += 10m;
                }

                if ((h + w + d) > 150)
                {
                    price *= 1.5m;
                }
            }

            if (isExpress)
            {
                price += 15m;
            }

            return price;
        }
    }
}