namespace CompMath_Lab7
{
	public class SimpsonCubatureMethod : INumericalIntegrationMethod
	{
		private readonly Func<double, double, double> _f;

		public SimpsonCubatureMethod(Func<double, double, double> f, Func<double, double, bool> area)
		{
			_f = (double x, double y) => area(x, y) ? f(x, y) : 0.0;
		}

		public string Name => "Simpson Cubature";

		public double Compute(double[] bounds, double h)
		{
			if (bounds.Length != 4)
			{
				throw new ArgumentException("There must be four bounds: upper and lower for every variable");
			}

			double x0 = bounds[0];
			double x1 = bounds[1];
			double y0 = bounds[2];
			double y1 = bounds[3];

			double sum = 0.0;
			int n = (int)((x1 - x0) / (2.0 * h));
			int m = (int)((y1 - y0) / (2.0 * h));
			for (int i = 0; i < n; i++)
			{
				double xx0 = x0 + 2 * i * h;
				double xx1 = xx0 + h;
				double xx2 = xx1 + h;
				for (int j = 0; j < m; j++)
				{
					double yy0 = y0 + 2 * j * h;
					double yy1 = yy0 + h;
					double yy2 = yy1 + h;
					sum += _f(xx0, yy0) + _f(xx2, yy0) + _f(xx0, yy2) + _f(xx2, yy2)
						+ 4.0 * (_f(xx1, yy0) + _f(xx0, yy1) + _f(xx2, yy1) + _f(xx1, yy2))
						+ 16.0 * _f(xx1, yy1);
				}
			}
			return sum * h * h / 9.0;
		}
	}
}
