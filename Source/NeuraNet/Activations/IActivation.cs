using MathNet.Numerics.LinearAlgebra;

namespace NeuraNet.Activations
{
    /// <summary>
    /// Interface for an activation function of nodes in the neural network that defines the output of those nodes
    /// given a number of inputs.
    /// </summary>
    public interface IActivation
    {
        /// <summary>
        /// Calculates activation for the specified input <paramref name="values"/>.
        /// </summary>
        /// <remarks>
        /// The activation function is usually an abstraction representing the rate of action potential firing in a
        /// node in the network.
        /// </remarks>
        Vector<double> Calculate(Vector<double> values);

        /// <summary>
        /// Calculates the derivative of the <see cref="Calculate"/> method.
        /// </summary>
        /// <remarks>
        /// The derivative of a function measures the sensitivity to change of the function(output) value,
        /// with respect to a change in its input values. 
        /// </remarks>
        Vector<double> Derivative(Vector<double> values);
    }
}
