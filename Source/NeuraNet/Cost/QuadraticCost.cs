using MathNet.Numerics.LinearAlgebra;

namespace NeuraNet.Cost
{
    public class QuadraticCost : ICostFunction
    {
        public double Calculate(Vector<double> output, Vector<double> target)
        {
            return (output - target).Map(Squared).Sum();
        }

        private static double Squared(double v) => v * v;

        public Vector<double> Derivative(Vector<double> output, Vector<double> target)
        {
            return 2 * (output - target);
        }
    }
}