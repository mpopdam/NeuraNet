using FakeItEasy;
using NeuraNet.NetworkLayout;

namespace NeuraNet.Specs.Builders
{
    internal class LayerInitializerBuilder : TestDataBuilder<ILayerInitializer>
    {
        private double[,] weightsMatrix;
        private double[] biases;

        protected override ILayerInitializer OnBuild()
        {
            var layerInitializer = A.Fake<ILayerInitializer>();

            A.CallTo(() => layerInitializer.GetWeight(A<int>._, A<int>._)).ReturnsLazily(call =>
            {
                if (weightsMatrix == null)
                {
                    return 0.5;
                }

                int row = call.GetArgument<int>(0);
                int column = call.GetArgument<int>(1);

                return weightsMatrix[row, column];
            });

            A.CallTo(() => layerInitializer.GetBias(A<int>._)).ReturnsLazily(call =>
            {
                if (biases == null)
                {
                    return 0.0;
                }

                int column = call.GetArgument<int>(0);
                return biases[column];
            });

            return layerInitializer;
        }

        public LayerInitializerBuilder UsingWeights(double[,] weightsMatrix)
        {
            this.weightsMatrix = weightsMatrix;
            return this;
        }

        public LayerInitializerBuilder UsingBiases(double[] biases)
        {
            this.biases = biases;
            return this;
        }
    }
}
