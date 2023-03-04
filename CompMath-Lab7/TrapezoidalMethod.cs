namespace CompMath_Lab7
{
	public class TrapezoidalMethod : QuadratureMethod
	{
		public TrapezoidalMethod(Func<double, double> f) : base(f)
		{
		}

		public override string Name => "Trapezoidal";

		protected override double Formula(double a, double b) => (b - a) * (_f(a) + _f(b)) / 2.0;
	}
}
