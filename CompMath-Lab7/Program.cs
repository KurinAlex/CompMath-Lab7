namespace CompMath_Lab7
{
	public class Program
	{
		const double A = 0.0;
		const double B = 16.0;
		const double TrueValue1 = 64.0 * Math.PI;
		static readonly double[] Bounds1 = { A, B };
		static double F1(double x) => Math.Sqrt(256.0 - x * x);

		const double X0 = 0.0;
		const double X1 = 1.0;
		const double Y0 = -1.0;
		const double Y1 = 1.0;
		const double TrueValue2 = 1.0;
		static readonly double[] Bounds2 = { X0, X1, Y0, Y1 };
		static double F2(double x, double y) => 6.0 * x * y * (1.0 + 4.0 * x * x * y * y);
		static bool Area(double x, double y) => x <= 1.0 && -x * x <= y && y <= Math.Sqrt(x);

		static readonly (INumericalIntegrationMethod, double[], double, double)[] quadratureMethods =
		{
			(new RiemannSumMethod(F1),            Bounds1, 0.1, TrueValue1),
			(new TrapezoidalMethod(F1),           Bounds1, 0.1, TrueValue1),
			(new SimpsonQuadratureMethod(F1),     Bounds1, 0.1, TrueValue1),
			(new SimpsonCubatureMethod(F2, Area), Bounds2, 0.1, TrueValue2),
		};

		static void Main()
		{
			foreach (var (method, bounds, h, trueValue) in quadratureMethods)
			{
				double res = method.Compute(bounds, h);
				double error = Math.Abs(trueValue - res) / trueValue;
				Console.WriteLine($"{method.Name}:");
				Console.WriteLine($"True value: {trueValue}");
				Console.WriteLine($"Result:     {res}");
				Console.WriteLine($"Error:      {error:P6}");
				Console.WriteLine();
			}
			Console.ReadLine();
		}
	}
}
