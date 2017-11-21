using MathNet.Numerics.LinearAlgebra;

namespace NeuraNet.Cost
{
    /// <summary>
    /// Interface for a cost function that determines the performance of the neural network based on the network output
    /// and the target output.
    /// </summary>
    public interface ICostFunction
    {
        /// <summary>
        /// Calculates the cost of the network based on the <paramref name="output"/> and the <paramref name="target"/>.
        /// </summary>
        double Calculate(Vector<double> output, Vector<double> target);

        /// <summary>
        /// Calculates the derivative of the cost with respect to the output activation of the network.
        /// </summary>
        Vector<double> Derivative(Vector<double> output, Vector<double> target);
    }
}
