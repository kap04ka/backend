namespace IntegralService146.Calculators
{
    public class CalculatorRect : ICalculator
    {
        public Tuple<double, List<double>, List<double>> Calculate(double down, double up, int numIntaration, Func<double, double> subIntegral)
        {
            if (numIntaration <= 0) throw new ArgumentException();
            double sum = 0;
            double h = (up - down) / numIntaration;

            double
                _x,
                _y;

            List<double> x = new List<double>();
            List<double> y = new List<double>();
           
            for(int i = 0; i < numIntaration; i++)
            {
                _x = down + i * h;
                _y = subIntegral(_x);

                x.Add(_x);
                y.Add(_y);

                sum += subIntegral(i * h + down);

            }

            x.Add(up);
            y.Add(subIntegral(up));

            return Tuple.Create(sum * h, x, y);
        }
    }
}
