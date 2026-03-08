using Xunit;
using RapidPack.Models;
using System;

namespace RapidPack.Tests
{
    public class ParcelCalculatorTests
    {
        [Fact]
        public void Calculate_Standard10kg_Returns30()
        {
            var calculator = new ParcelCalculator();
            var result = calculator.Calculate(10, "Standardowa", 10, 10, 10, false);
            Assert.Equal(30m, result);
        }

        [Fact]
        public void Calculate_Pallet_ReturnsFixed100()
        {
            var calculator = new ParcelCalculator();
            var result = calculator.Calculate(25, "Paleta", 80, 80, 80, false);
            Assert.Equal(100m, result);
        }

        [Fact]
        public void Calculate_FragileStandard_Adds10PLN()
        {
            var calculator = new ParcelCalculator();
            var result = calculator.Calculate(5, "Ostrożnie", 10, 10, 10, false);
            Assert.Equal(30m, result);
        }

        [Fact]
        public void Calculate_OversizeWithExpress_CalculatesCorrectly()
        {
            var calculator = new ParcelCalculator();
            var result = calculator.Calculate(10, "Standardowa", 60, 60, 60, true);
            Assert.Equal(60m, result);
        }

        [Fact]
        public void Calculate_Overweight_ThrowsException()
        {
            var calculator = new ParcelCalculator();
            Assert.Throws<ArgumentException>(() => 
                calculator.Calculate(31, "Standardowa", 10, 10, 10, false));
        }
    }
}