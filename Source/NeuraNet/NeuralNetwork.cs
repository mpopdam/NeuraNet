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

        public ICostFunction CostFunction { get; }

        /// <summary>
        /// Instantiates a new neural network with the layout provided by the specified <paramref name="layoutProvider"/>.
        /// </summary>
        /// <param name="layoutProvider">Provides the layout of the network</param>
        public NeuralNetwork(INetworkLayoutProvider layoutProvider, ICostFunction costFunction)
        {
            layers = layoutProvider.GetLayers();
            firstHiddenLayer = layers.First();

            CostFunction = costFunction;
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
        /// <returns>The mean cost for the examples in the last epoch</returns>
        public double Train(TrainingExample[] trainingExamples, int numberOfEpochs)
        {
            double meanCost = 0;

            for (int epoch = 1; epoch <= numberOfEpochs; epoch++)
            {
                meanCost = TrainAllExamples(new Epoch(trainingExamples, epoch));
            }

            return meanCost;
        }

        private double TrainAllExamples(Epoch epoch)
        {
            double meanCost = 0;
            double totalCostForAllExamples = 0.0;

            int currentExample = 1;
            foreach (TrainingExample example in epoch.Examples)
            {
                totalCostForAllExamples += Train(example.Input, example.ExpectedOutput);

                meanCost = totalCostForAllExamples / currentExample;

                currentExample++;
            }

            return meanCost;
        }

        private double Train(double[] input, Vector<double> target)
        {
            Vector<double> output = firstHiddenLayer.FeedForward(input);

            return CostFunction.Calculate(output, target);
        }
    }
}
