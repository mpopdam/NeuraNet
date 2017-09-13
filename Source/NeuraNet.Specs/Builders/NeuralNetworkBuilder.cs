using FakeItEasy;
using NeuraNet.NetworkLayout;

namespace NeuraNet.Specs.Builders
{
    internal class NeuralNetworkBuilder : TestDataBuilder<NeuralNetwork>
    {
        private INetworkLayoutProvider layoutProvider;

        protected override void OnPreBuild()
        {
            layoutProvider = layoutProvider ?? A.Fake<INetworkLayoutProvider>();
        }

        protected override NeuralNetwork OnBuild()
        {
            return new NeuralNetwork(layoutProvider);
        }

        public NeuralNetworkBuilder Using(INetworkLayoutProvider layoutProvider)
        {
            this.layoutProvider = layoutProvider;
            return this;
        }
    }
}
