﻿using MathNet.Numerics.LinearAlgebra;

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

        /// <summary>
        /// The function that is used as activation function for calculating the output of this layer.
        /// </summary>
        public IActivation ActivationFunction { get; }

        internal Matrix<double> Weights { get; private set; }
        internal Vector<double> Biases { get; private set; }
        private Vector<double> inputs;
        private Vector<double> activations;

        internal Matrix<double> WeightGradients { get; private set; }
        internal Vector<double> BiasGradients { get; private set; }
        internal Vector<double> PreviousLayerActivationGradients { get; private set; }

        private Matrix<double> previousDeltaWeights;
        private Vector<double> previousDeltaBiases;

        public int NeuronCount => Biases.Count;
        private bool IsFirstHiddenLayer => previousLayer == null;

        public Layer(double[,] inputWeights, double[] biases, IActivation activationFunction)
        {
            Weights = Matrix<double>.Build.DenseOfArray(inputWeights);
            Biases = Vector<double>.Build.DenseOfArray(biases);

            ActivationFunction = activationFunction;

            WeightGradients = Matrix<double>.Build.Dense(Weights.RowCount, Weights.ColumnCount);

            previousDeltaWeights = Matrix<double>.Build.Dense(Weights.RowCount, Weights.ColumnCount);
            previousDeltaBiases = Vector<double>.Build.Dense(Biases.Count);
        }

        public Layer(int numberOfNeuronsInPreviousLayer, int numberOfNeurons, ILayerInitializer layerInitializer,
            IActivation activationFunction)
        {
            Weights = Matrix<double>.Build.Dense(numberOfNeurons, numberOfNeuronsInPreviousLayer, layerInitializer.GetWeight);
            Biases = Vector<double>.Build.Dense(numberOfNeurons, layerInitializer.GetBias);

            ActivationFunction = activationFunction;

            previousDeltaWeights = Matrix<double>.Build.Dense(Weights.RowCount, Weights.ColumnCount);
            previousDeltaBiases = Vector<double>.Build.Dense(Biases.Count);
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

        /// <summary>
        /// Calculates the current layer's output values based on the specified <paramref name="inputs"/>, the current
        /// <see cref="Weights"/> and <see cref="Biases"/> and the used <see cref="ActivationFunction"/> algorithm.
        /// The output is then passed on to the <see cref="nextLayer"/>. If there is no next layer the output values are
        /// the output of the entire network.
        /// </summary>
        public Vector<double> FeedForward(double[] inputs)
        {
            return FeedForward(Vector<double>.Build.DenseOfArray(inputs));
        }

        private Vector<double> FeedForward(Vector<double> inputs)
        {
            this.inputs = inputs;

            var z = (Weights * inputs) + Biases;
            activations = ActivationFunction.Calculate(z);

            return (nextLayer != null) ? nextLayer.FeedForward(activations) : activations;
        }

        /// <summary>
        /// Propagates the network output error backwards through the network by calculating the gradients for the current layer.
        /// If the current layer has a <see cref="previousLayer"/> the <see cref="PreviousLayerActivationGradients"/> will be
        /// propagated backwards to that layer, so that eventually the gradients will be calculated for all layers in the network.
        /// </summary>
        /// <param name="dC_dA">Derivative of the cost with respect to the activations of the current layer</param>
        public void BackPropagate(Vector<double> dC_dA)
        {
            CalculateGradients(dC_dA);

            previousLayer?.BackPropagate(PreviousLayerActivationGradients);
        }

        /// <summary>
        /// Calculates the gradient for the current layer based on the gradients and input weights of the next layer
        /// in the neural network.
        /// </summary>
        /// <param name="dC_dA">Derivative of cost w.r.t. the hidden layer output</param>
        /// <remarks>
        /// Gradients are a measure of how far off, and in what direction (positive or negative) the current layer's 
        /// output values are.
        /// </remarks>
        private void CalculateGradients(Vector<double> dC_dA)
        {
            Vector<double> dA_dZ = ActivationFunction.Derivative(activations);
            Vector<double> nodeDeltas = dC_dA.PointwiseMultiply(dA_dZ);

            WeightGradients = nodeDeltas.OuterProduct(inputs);
            BiasGradients = nodeDeltas;

            if (!IsFirstHiddenLayer)
            {
                PreviousLayerActivationGradients = nodeDeltas * Weights;
            }
        }

        /// <summary>
        /// Performs gradient descent by updating the <see cref="Weights"/> and <see cref="Biases"/> for the current layer.
        /// If the layer has a <see cref="nextLayer"/> then the same gradient descent is triggered for that layer, so that
        /// eventually all layers of the network will have updated their <see cref="Weights"/> and <see cref="Biases"/>.
        /// </summary>
        /// <param name="learningRate">
        /// A constant that influences how big the changes to weights and bias values should be. A higher learning rate
        /// means a faster network by taking bigger steps, at the cost of a higher chance of missing the 'sweet spot' of
        /// the lowest network error.
        /// </param>
        /// <param name="momentum">
        /// The idea about using a momentum is to stabilize the weight change by making nonradical revisions using a
        /// combination of the gradient decreasing term with a fraction of the previous weight change.
        /// With momentum, once the weights start moving in a particular direction in weight space, they tend to continue
        /// moving in that direction. Imagine a ball rolling down a hill that gets stuck in a depression half way down
        /// the hill. If the ball has enough momentum, it will be able to roll through the depression and continue down the
        /// hill. Similarly, when applied to weights in a network, momentum can help the network "roll past" a local minima,
        /// as well as speed learning (especially along long flat error surfaces)
        /// </param>
        public void PerformGradientDescent(double learningRate, double momentum)
        {
            UpdateWeights(learningRate, momentum);
            UpdateBiases(learningRate, momentum);

            nextLayer?.PerformGradientDescent(learningRate, momentum);
        }

        private void UpdateWeights(double learningRate, double momentum)
        {
            Matrix<double> momentums = momentum * previousDeltaWeights;

            Matrix<double> deltaWeights = (learningRate * WeightGradients) + momentums;
            Weights -= deltaWeights;

            previousDeltaWeights = deltaWeights;
        }

        private void UpdateBiases(double learningRate, double momentum)
        {
            Vector<double> momentums = momentum * previousDeltaBiases;

            Vector<double> deltaBiases = (learningRate * BiasGradients) + momentums;
            Biases -= deltaBiases;

            previousDeltaBiases = deltaBiases;
        }
    }
}
