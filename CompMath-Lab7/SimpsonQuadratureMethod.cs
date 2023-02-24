namespace CompMath_Lab7
{
	public class SimpsonQuadratureMethod : QuadratureMethod
	{
		public SimpsonQuadratureMethod(Func<double, double> f) : base(f)
		{
		}

		public override string Name => "Simpson Quadrature";

		protected override double Formula(double a, double b)
			=> (b - a) / 6.0 * (_f(a) + 4.0 * _f((a + b) / 2) + _f(b));
	}
}
