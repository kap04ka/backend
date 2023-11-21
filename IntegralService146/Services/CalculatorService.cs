using IntegralService146.Calculators;
using IntegralService146.Models;
using MathNet.Symbolics;
using System.Security.Cryptography.X509Certificates;

namespace IntegralService146.Services
{
    public class CalculatorService : ICalculatorService
    {
        public IntegralOutputData Calculate(IntegralInputData input)
        {
            Func<double, double> f = SymbolicExpression.Parse(input.FuncIntegral).Compile("x");
            ICalculator calculatorRect = new CalculatorRect();
            IntegralOutputData integralOutputData = new IntegralOutputData();
            Tuple<double, List<double>, List<double>> result = calculatorRect.Calculate(input.DownLimit, input.UpLimit, input.N, f);
            integralOutputData.Result = result.Item1;
            integralOutputData.X = result.Item2;
            integralOutputData.Y = result.Item3;
            return integralOutputData;
        }
    }
}
