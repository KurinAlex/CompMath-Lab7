namespace CompMath_Lab7
{
	public interface INumericalIntegrationMethod
	{
		string Name { get; }
		double Compute(double[] bounds, double h);
	}
}
