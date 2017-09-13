using MathNet.Numerics.LinearAlgebra;

using NeuraNet.Activations;
using NeuraNet.NetworkLayout;

namespace NeuraNet
{
    /// <summary>
    /// Represents one layer in a <see cref="NeuralNetwork"/>. The layer receives inputs from the previous layer in
    /// the network. Based on this input it calculates an output that serves as the input for the next layer in the network.
    /// </summary>
    public class Layer
    {
        private Layer previousLayer;
        private Layer nextLayer;

        public IActivation OutputActivation { get; }

        internal Matrix<double> Weights { get; }
        internal Vector<double> Biases { get; }

        public Layer(int numberOfNeuronsInPreviousLayer, int numberOfNeurons, ILayerInitializer layerInitializer,
            IActivation outputActivation)
        {
            OutputActivation = outputActivation;

            Weights = Matrix<double>.Build.Dense(numberOfNeurons, numberOfNeuronsInPreviousLayer, layerInitializer.GetWeight);
            Biases = Vector<double>.Build.Dense(numberOfNeurons, layerInitializer.GetBias);
        }

        /// <summary>
        /// Connects the current layer to the specified <paramref name="previous"/> and <paramref name="next"/>.
        /// A proper connection between the layers is required for the feedforward and backpropagation algorithms.
        /// </summary>
        public void ConnectTo(Layer previous, Layer next)
        {
            previousLayer = previous;
            nextLayer = next;
        }
    }
}
