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

        /// <summary>
        /// Instantiates a new neural network with the layout provided by the specified <paramref name="layoutProvider"/>.
        /// </summary>
        /// <param name="layoutProvider">Provides the layout of the network</param>
        public NeuralNetwork(INetworkLayoutProvider layoutProvider, ICostFunction costFunction)
        {
            layers = layoutProvider.GetLayers();
            firstHiddenLayer = layers.First();
            outputLayer = layers.Last();

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
        /// <returns>The mean cost for the examples in the last epoch</returns>
        public double Train(TrainingExample[] trainingExamples, int numberOfEpochs, double learningRate)
        {
            double meanCost = 0;

            for (int epoch = 1; epoch <= numberOfEpochs; epoch++)
            {
                meanCost = TrainAllExamples(new Epoch(trainingExamples, epoch), learningRate);
            }

            return meanCost;
        }

        private double TrainAllExamples(Epoch epoch, double learningRate)
        {
            double meanCost = 0;
            double totalCostForAllExamples = 0.0;

            int currentExample = 1;
            foreach (TrainingExample example in epoch.Examples)
            {
                totalCostForAllExamples += Train(example.Input, example.ExpectedOutput, learningRate);

                meanCost = totalCostForAllExamples / currentExample;

                currentExample++;
            }

            return meanCost;
        }

        private double Train(double[] input, Vector<double> target, double learningRate)
        {
            Vector<double> output = firstHiddenLayer.FeedForward(input);

            outputLayer.BackPropagate(CostFunction.Derivative(output, target));

            return CostFunction.Calculate(output, target);
        }
    }
}
