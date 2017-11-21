using System.Collections.Generic;

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

            var network = new NeuralNetworkBuilder()
                .Using(new TwoLayerNetworkProvider())
                .Using(new QuadraticCost())
                .Build();

            // Act
            double cost = network.Train(new[]
            {
                new TrainingExample(new[] { 0.1, 0.2, 0.3 }, new[] { 1.0, 0.0 })
            }, numberOfEpochs);

            // Assert
            cost.Should().BeApproximately(0.83395, 0.000005);
        }
    }
}