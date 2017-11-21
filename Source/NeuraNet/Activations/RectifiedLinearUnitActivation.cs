using System;

namespace NeuraNet.Activations
{
    public class RectifiedLinearUnitActivation : Activation
    {
        public override string Name => "ReLU";

        protected override double Calculate(double value)
        {
            return Math.Max(0, value);
        }

        protected override double Derivative(double value)
        {
            return value < 0 ? 0 : 1;
        }
    }
}
