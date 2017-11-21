using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NeuraNet.Activations;
using NeuraNet.Cost;
using NeuraNet.NetworkLayout;
using NeuraNet.Specs.Builders;

using Xunit;

namespace NeuraNet.Specs
{
    public class NeuralNetworkSpecs
    {
        private class TwoLayerNetworkProvider : NetworkLayoutProvider
        {
            private readonly ILayerInitializer hiddenLayerInitializer = new LayerInitializerBuilder()
                .UsingWeights(new[,]
                {
                    { 0.1, 0.2, 0.3 },
                    { 0.4, 0.5, 0.6 },
                    { 0.7, 0.8, 0.9 },
                    { 1.0, 1.1, 1.2 },
                })
                .UsingBiases(new[]
                {
                    0.06,
                    0.08,
                    0.10,
                    0.12
                })
                .Build();

            private readonly ILayerInitializer outputLayerInitializer = new LayerInitializerBuilder()
                .UsingWeights(new[,]
                {
                    { 0.15, 0.25, 0.35, 0.45 },
                    { 0.55, 0.65, 0.75, 0.85 },
                })
                .UsingBiases(new[]
                {
                    0.04,
                    0.05
                })
                .Build();

            public TwoLayerNetworkProvider()
            {
                layers = new List<Layer>
                {
                    new Layer(3, 4, hiddenLayerInitializer, new SigmoidActivation()),
                    new Layer(4, 2, outputLayerInitializer, new SigmoidActivation())
                };

                ConnectLayers();
            }
        }

        [Fact]
        public void When_querying_a_network_with_known_weights_and_biases_it_should_return_the_expected_output()
        {
            // Arrange
            var network = new NeuralNetworkBuilder()
                .Using(new TwoLayerNetworkProvider())
                .Build();

            // Act
            double[] networkOutput = network.Query(new[] { 0.1, 0.2, 0.3 });

            // Assert
            networkOutput.Should().HaveCount(2);
            networkOutput[0].Should().BeApproximately(0.6918, 0.00005);
            networkOutput[1].Should().BeApproximately(0.8596, 0.00005);
        }

        [Fact]
        public void When_training_the_network_for_a_single_epoch_it_should_return_the_cost()
        {
            // Arrange
            const int numberOfEpochs = 1;
            const double learningRate = 0.5;

            var network = new NeuralNetworkBuilder()
                .Using(new TwoLayerNetworkProvider())
                .Using(new QuadraticCost())
                .Build();

            // Act
            double cost = network.Train(new[]
            {
                new TrainingExample(new[] { 0.1, 0.2, 0.3 }, new[] { 1.0, 0.0 })
            }, numberOfEpochs, learningRate);

            // Assert
            cost.Should().BeApproximately(0.83395, 0.000005);
        }

        [Fact]
        public void When_training_the_network_for_a_single_epoch_it_should_calculate_the_gradients()
        {
            // Arrange
            const int numberOfEpochs = 1;
            const double learningRate = 0.5;

            var network = new NeuralNetworkBuilder()
                .Using(new TwoLayerNetworkProvider())
                .Build();

            // Act
            network.Train(new[]
            {
                new TrainingExample(new[] { 0.1, 0.2, 0.3 }, new[] { 1.0, 0.0 })
            }, numberOfEpochs, learningRate);

            // Assert
            Layer hiddenLayer = network.GetLayers().First();
            Layer outputLayer = network.GetLayers().Last();

            double[] outputWeightGradients = outputLayer.WeightGradients.ToRowMajorArray();
            outputWeightGradients[0].Should().BeApproximately(-0.07225635, 0.000000005);
            outputWeightGradients[1].Should().BeApproximately(-0.07867644, 0.000000005);
            outputWeightGradients[2].Should().BeApproximately(-0.08484882, 0.000000005);
            outputWeightGradients[3].Should().BeApproximately(-0.09067289, 0.000000005);
            outputWeightGradients[4].Should().BeApproximately(0.11406304, 0.000000005);
            outputWeightGradients[5].Should().BeApproximately(0.12419773, 0.000000005);
            outputWeightGradients[6].Should().BeApproximately(0.13394138, 0.000000005);
            outputWeightGradients[7].Should().BeApproximately(0.14313518, 0.000000005);

            var outputBiasGradients = outputLayer.BiasGradients.ToArray();
            outputBiasGradients[0].Should().BeApproximately(-0.131415, 0.0000005);
            outputBiasGradients[1].Should().BeApproximately(0.207450, 0.0000005);

            var outputInputGradients = outputLayer.PreviousLayerActivationGradients.ToArray();
            outputInputGradients[0].Should().BeApproximately(0.09438525, 0.000000005);
            outputInputGradients[1].Should().BeApproximately(0.10198876, 0.000000005);
            outputInputGradients[2].Should().BeApproximately(0.10959228, 0.000000005);
            outputInputGradients[3].Should().BeApproximately(0.11719579, 0.000000005);

            double[] hiddenWeightGradients = hiddenLayer.WeightGradients.ToRowMajorArray();
            hiddenWeightGradients[0].Should().BeApproximately(0.00233619, 0.0000005);
            hiddenWeightGradients[1].Should().BeApproximately(0.00467238, 0.0000005);
            hiddenWeightGradients[2].Should().BeApproximately(0.00700857, 0.0000005);
            hiddenWeightGradients[3].Should().BeApproximately(0.00245039, 0.0000005);
            hiddenWeightGradients[4].Should().BeApproximately(0.00490078, 0.0000005);
            hiddenWeightGradients[5].Should().BeApproximately(0.00735117, 0.0000005);
            hiddenWeightGradients[6].Should().BeApproximately(0.00250730, 0.0000005);
            hiddenWeightGradients[7].Should().BeApproximately(0.00501460, 0.0000005);
            hiddenWeightGradients[8].Should().BeApproximately(0.00752190, 0.0000005);
            hiddenWeightGradients[9].Should().BeApproximately(0.00250693, 0.0000005);
            hiddenWeightGradients[10].Should().BeApproximately(0.00501386, 0.0000005);
            hiddenWeightGradients[11].Should().BeApproximately(0.00752079, 0.0000005);

            double[] hiddenBiasGradients = hiddenLayer.BiasGradients.ToArray();
            hiddenBiasGradients[0].Should().BeApproximately(0.02336191, 0.000000005);
            hiddenBiasGradients[1].Should().BeApproximately(0.02450390, 0.000000005);
            hiddenBiasGradients[2].Should().BeApproximately(0.02507299, 0.000000005);
            hiddenBiasGradients[3].Should().BeApproximately(0.02506932, 0.000000005);

            hiddenLayer.PreviousLayerActivationGradients.Should().BeNull();
        }

        [Fact]
        public void When_training_the_network_for_a_single_epoch_it_should_update_the_weights_and_biases_correctly()
        {
            // Arrange
            const int numberOfEpochs = 1;
            const double learningRate = 0.5;

            var network = new NeuralNetworkBuilder()
                .Using(new TwoLayerNetworkProvider())
                .Build();

            // Act
            network.Train(new[]
            {
                new TrainingExample(new[] { 0.1, 0.2, 0.3 }, new[] { 1.0, 0.0 })
            }, numberOfEpochs, learningRate);

            // Assert
            Layer hiddenLayer = network.GetLayers().First();
            Layer outputLayer = network.GetLayers().Last();

            var updatedOutputWeights = outputLayer.Weights.ToRowMajorArray();
            updatedOutputWeights[0].Should().BeApproximately(0.18612817, 0.000000005);
            updatedOutputWeights[1].Should().BeApproximately(0.28933822, 0.000000005);
            updatedOutputWeights[2].Should().BeApproximately(0.39242441, 0.000000005);
            updatedOutputWeights[3].Should().BeApproximately(0.49533644, 0.000000005);
            updatedOutputWeights[4].Should().BeApproximately(0.49296848, 0.000000005);
            updatedOutputWeights[5].Should().BeApproximately(0.58790113, 0.000000005);
            updatedOutputWeights[6].Should().BeApproximately(0.68302931, 0.000000005);
            updatedOutputWeights[7].Should().BeApproximately(0.77843241, 0.000000005);

            var updatedOutputBiases = outputLayer.Biases.ToArray();
            updatedOutputBiases[0].Should().BeApproximately(0.10570742, 0.000000005);
            updatedOutputBiases[1].Should().BeApproximately(-0.05372498, 0.000000005);

            var updatedHiddenWeights = hiddenLayer.Weights.ToRowMajorArray();
            updatedHiddenWeights[0].Should().BeApproximately(0.09883190, 0.000000005);
            updatedHiddenWeights[1].Should().BeApproximately(0.19766381, 0.000000005);
            updatedHiddenWeights[2].Should().BeApproximately(0.29649571, 0.000000005);
            updatedHiddenWeights[3].Should().BeApproximately(0.39877481, 0.000000005);
            updatedHiddenWeights[4].Should().BeApproximately(0.49754961, 0.000000005);
            updatedHiddenWeights[5].Should().BeApproximately(0.59632442, 0.000000005);
            updatedHiddenWeights[6].Should().BeApproximately(0.69874635, 0.000000005);
            updatedHiddenWeights[7].Should().BeApproximately(0.79749270, 0.000000005);
            updatedHiddenWeights[8].Should().BeApproximately(0.89623905, 0.000000005);
            updatedHiddenWeights[9].Should().BeApproximately(0.99874653, 0.000000005);
            updatedHiddenWeights[10].Should().BeApproximately(1.09749307, 0.000000005);
            updatedHiddenWeights[11].Should().BeApproximately(1.19623960, 0.000000005);

            var updatedHiddenBiases = hiddenLayer.Biases.ToArray();
            updatedHiddenBiases[0].Should().BeApproximately(0.04831904, 0.000000005);
            updatedHiddenBiases[1].Should().BeApproximately(0.06774805, 0.000000005);
            updatedHiddenBiases[2].Should().BeApproximately(0.08746351, 0.000000005);
            updatedHiddenBiases[3].Should().BeApproximately(0.10746534, 0.000000005);
        }
    }
}