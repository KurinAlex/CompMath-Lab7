namespace CompMath_Lab7
{
	public abstract class QuadratureMethod : INumericalIntegrationMethod
	{
		protected readonly Func<double, double> _f;

		public QuadratureMethod(Func<double, double> f) => _f = f;

		public abstract string Name { get; }

		protected abstract double Formula(double a, double b);
		public double Compute(double[] bounds, double h)
		{
			if (bounds.Length != 2)
			{
				throw new ArgumentException("There must be two bounds: upper and lower");
			}

			double a = bounds[0];
			double b = bounds[1];
			return Enumerable.Range(0, (int)((b - a) / h)).Sum(k => Formula(a + h * k, a + h * (k + 1)));
		}
	}
}
