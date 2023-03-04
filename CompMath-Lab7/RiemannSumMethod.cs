namespace CompMath_Lab7
{
	public class RiemannSumMethod : QuadratureMethod
	{
		public RiemannSumMethod(Func<double, double> f) : base(f)
		{
		}

		public override string Name => "Riemann Sum";

		protected override double Formula(double a, double b) => (b - a) * _f((a + b) / 2);
	}
}
