using System;

namespace NeuraNet.Activations
{
    public class SoftplusActivation : Activation
    {
        public override string Name => "Softplus";

        protected override double Calculate(double value)
        {
            return Math.Log(1 + Math.Exp(value));
        }

        protected override double Derivative(double value)
        {
            return (1 / (1 + Math.Exp(-value)));
        }
    }
}
