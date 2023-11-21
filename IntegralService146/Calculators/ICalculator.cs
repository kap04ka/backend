namespace IntegralService146.Calculators
{
    public interface ICalculator
    {
        public Tuple<double, List<double>, List<double>> Calculate(double down, double up, int numIntaration, Func<double, double> subIntegral);
    }
}
