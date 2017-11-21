using MathNet.Numerics.LinearAlgebra;

namespace NeuraNet.Activations
{
    public abstract class Activation : IActivation
    {
        public abstract string Name { get; }

        public Vector<double> Calculate(Vector<double> values)
        {
            return values.Map(Calculate, Zeros.Include);
        }

        public Vector<double> Derivative(Vector<double> values)
        {
            return values.Map(Derivative, Zeros.Include);
        }

        protected abstract double Calculate(double value);

        protected abstract double Derivative(double value);
    }
}
