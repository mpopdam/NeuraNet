using System.Collections.Generic;

using NeuraNet.Activations;
using NeuraNet.NetworkLayout;

namespace NeuraNet.ConsoleApp.Problems.Demo
{
    public class DemoNetworkLayout : INetworkLayoutProvider
    {
        public IEnumerable<Layer> GetLayers()
        {
            return new[]
            {
                new Layer(3, 4, new IncrementingLayerInitializer(3, 4, 0.001, 0.013), new SigmoidActivation()),
                new Layer(4, 2, new IncrementingLayerInitializer(4, 2, 0.017, 0.025), new SigmoidActivation()),
            };
        }
    }
}
