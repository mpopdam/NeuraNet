using System;

namespace NeuraNet.Activations
{
    public class SigmoidActivation : Activation
    {
        protected override double Calculate(double value)
        {
            return (1 / (1 + Math.Exp(-value)));
        }

        protected override double Derivative(double sigmoid)
        {
            return sigmoid * (1 - sigmoid);
        }
    }
}