using MathNet.Numerics.LinearAlgebra;

namespace NeuraNet
{
    /// <summary>
    /// Contains the input and expected output values that serve as training examples for the <see cref="NeuralNetwork"/>.
    /// </summary>
    public class TrainingExample
    {
        public TrainingExample(double[] input, double[] expectedOutput)
        {
            Input = input;

            ExpectedOutput = Vector<double>.Build.DenseOfArray(expectedOutput);
        }

        /// <summary>
        /// The input values
        /// </summary>
        public double[] Input { get; }

        /// <summary>
        /// The expected output values of the network given the <see cref="Input"/> values.
        /// </summary>
        public Vector<double> ExpectedOutput { get; }
    }
}
