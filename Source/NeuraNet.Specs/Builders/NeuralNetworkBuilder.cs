using FakeItEasy;

using NeuraNet.Cost;
using NeuraNet.NetworkLayout;

namespace NeuraNet.Specs.Builders
{
    internal class NeuralNetworkBuilder : TestDataBuilder<NeuralNetwork>
    {
        private INetworkLayoutProvider layoutProvider;
        private ICostFunction costFunction;

        protected override void OnPreBuild()
        {
            layoutProvider = layoutProvider ?? A.Fake<INetworkLayoutProvider>();
            costFunction = costFunction ?? new QuadraticCost();
        }

        protected override NeuralNetwork OnBuild()
        {
            return new NeuralNetwork(layoutProvider, costFunction);
        }

        public NeuralNetworkBuilder Using(INetworkLayoutProvider layoutProvider)
        {
            this.layoutProvider = layoutProvider;
            return this;
        }

        public NeuralNetworkBuilder Using(ICostFunction costFunction)
        {
            this.costFunction = costFunction;
            return this;
        }
    }
}
