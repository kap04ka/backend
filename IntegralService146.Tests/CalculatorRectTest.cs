using IntegralService146.Calculators;
using Xunit;

namespace IntegralService146.Tests
{
    public class CalculatorsTest
    {
        [Fact]
        public void positive_test_integral_calculate()
        {
            double down = 0.0;
            double up = 1.0;
            int iterations = 1000;
            double exceptedResult = 0.333333;
            Func<double, double> func = x => x * x;

            ICalculator calculateIntegral = new CalculatorRect();

            double result = calculateIntegral.Calculate(down, up, iterations, func).Item1;

            Assert.Equal(result, exceptedResult, 1);
        }

        [Fact]
        public void positive_test_integral_calculate_reverse()
        {
            double down = 1.0;
            double up = 0.0;
            int iterations = 1000;
            double exceptedResult = -0.333333;
            Func<double, double> func = x => x * x;

            ICalculator calculateIntegral = new CalculatorRect();

            double result = calculateIntegral.Calculate(down, up, iterations, func).Item1;

            Assert.Equal(result, exceptedResult, 1);
        }

        [Fact]
        public void positive_test_integral_calculate_x_data()
        {
            double down = 0.0;
            double up = 1.0;
            int iterations = 1000;
            
            Func<double, double> func = x => x * x;

            ICalculator calculateIntegral = new CalculatorRect();

            List < double > result = calculateIntegral.Calculate(down, up, iterations, func).Item2;

            Assert.Equal(result[0], down, 1);
        }

        [Fact]
        public void positive_test_integral_calculate_y_data()
        {
            double down = 0.0;
            double up = 1.0;
            int iterations = 1000;

            Func<double, double> func = x => x * x;

            ICalculator calculateIntegral = new CalculatorRect();

            List<double> result = calculateIntegral.Calculate(down, up, iterations, func).Item3;

            Assert.Equal(result[0], func(down), 1);
        }

        [Fact]
        public void negative_test_integral_calculate_()
        {
            double down = 0.0;
            double up = 1.0;
            int iterations = -1;

            Func<double, double> func = x => x * x;

            ICalculator calculateIntegral = new CalculatorRect();

            Assert.Throws<ArgumentException>(() => calculateIntegral.Calculate(down, up, iterations, func).Item3);
        }
    }
}
