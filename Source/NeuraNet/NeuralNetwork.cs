using System;
using System.Collections.Generic;
using System.Linq;

using MathNet.Numerics.LinearAlgebra;
using NeuraNet.Cost;
using NeuraNet.NetworkLayout;

namespace NeuraNet
{
    /// <summary>
    /// Neural network implementation that can be trained to recognise 'patterns' by learning from examples.
    /// </summary>
    public class NeuralNetwork
    {
        private readonly IEnumerable<Layer> layers;
        private readonly Layer firstHiddenLayer;
        private readonly Layer outputLayer;

        public ICostFunction CostFunction { get; }

        public event EventHandler<ExampleTrainedEventArgs> ExampleTrained = delegate { };

        /// <summary>
        /// Instantiates a new neural network with the layout provided by the specified <paramref name="layoutProvider"/>.
        /// </summary>
        /// <param name="layoutProvider">Provides the layout of the network</param>
        public NeuralNetwork(INetworkLayoutProvider layoutProvider, ICostFunction costFunction)
            : this(layoutProvider.GetLayers(), costFunction)
        {
        }

        public NeuralNetwork(IEnumerable<Layer> layers, ICostFunction costFunction)
        {
            this.layers = layers.ToArray();
            firstHiddenLayer = this.layers.First();
            outputLayer = this.layers.Last();

            CostFunction = costFunction;
        }

        /// <summary>
        /// Returns the layers of the network
        /// </summary>
        public IEnumerable<Layer> GetLayers()
        {
            return layers;
        }

        /// <summary>
        /// Queries the network for the result of the given <paramref name="input"/>.
        /// </summary>
        public double[] Query(double[] input)
        {
            return firstHiddenLayer.FeedForward(input).ToArray();
        }

        /// <summary>
        /// Train the network using the specified <paramref name="trainingExamples"/>.
        /// </summary>
        /// <param name="trainingExamples">The list of examples that will train the network.</param>
        /// <param name="numberOfEpochs">
        /// The number of epochs to use for the training. Each epoch means one forward pass and one backward pass of
        /// all the training examples
        /// </param>
        /// <param name="learningRate">Influences how big the changes to weights and bias values are.</param>
        /// <param name="momentum">
        /// The use of a momentum in the backpropagation algorithm can be helpful in speeding the convergence and
        /// avoiding local minima.
        /// </param>
        /// <returns>The mean cost for the examples in the last epoch</returns>
        public double Train(TrainingExample[] trainingExamples, int numberOfEpochs, double learningRate, double momentum)
        {
            double meanCost = 0;

            for (int epoch = 1; epoch <= numberOfEpochs; epoch++)
            {
                meanCost = TrainAllExamples(new Epoch(trainingExamples, epoch), numberOfEpochs, learningRate, momentum);
            }

            return meanCost;
        }

        private double TrainAllExamples(Epoch epoch, int numberOfEpochs, double learningRate, double momentum)
        {
            double meanCost = 0;
            double totalCostForAllExamples = 0.0;

            int currentExample = 1;
            foreach (TrainingExample example in epoch.Examples)
            {
                totalCostForAllExamples += Train(example.Input, example.ExpectedOutput, learningRate, momentum);

                meanCost = totalCostForAllExamples / currentExample;
                OnExampleTrained(epoch.Sequence, numberOfEpochs, currentExample, epoch.Examples.Length, meanCost);

                currentExample++;
            }

            return meanCost;
        }

        private void OnExampleTrained(
            int currentEpoch, int totalNumberOfEpochs, int currentExample, int totalNumberOfExamples, double meanCost)
        {
            ExampleTrainedEventArgs arguments = new ExampleTrainedEventArgs
            {
                CurrentEpoch = currentEpoch,
                TotalEpochCount = totalNumberOfEpochs,
                CurrentExample = currentExample,
                TotalExampleCount = totalNumberOfExamples,
                MeanCost = meanCost,
            };

            ExampleTrained(this, arguments);
        }

        private double Train(double[] input, Vector<double> target, double learningRate, double momentum)
        {
            Vector<double> output = firstHiddenLayer.FeedForward(input);

            outputLayer.BackPropagate(CostFunction.Derivative(output, target));

            firstHiddenLayer.PerformGradientDescent(learningRate, momentum);

            return CostFunction.Calculate(output, target);
        }
    }
}
