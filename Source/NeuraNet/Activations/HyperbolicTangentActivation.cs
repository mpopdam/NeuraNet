using System;

namespace NeuraNet.Activations
{
    public class HyperbolicTangentActivation : Activation
    {
        public override string Name => "Tanh";

        protected override double Calculate(double value)
        {
            return Math.Tanh(value);
        }

        protected override double Derivative(double value)
        {
            double tanh = Calculate(value);
            return (1 - tanh) * (1 + tanh);
        }
    }
}
