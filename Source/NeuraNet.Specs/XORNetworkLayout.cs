using System.Collections.Generic;

using NeuraNet.Activations;
using NeuraNet.NetworkLayout;

namespace NeuraNet.Specs
{
    public class XORNetworkLayout : NetworkLayoutProvider
    {
        public XORNetworkLayout()
        {
            var neuronInitializer = new RandomLayerInitializer();
            var outputActivation = new SigmoidActivation();

            layers = new List<Layer>
            {
                new Layer(2, 3, neuronInitializer, outputActivation),
                new Layer(3, 1, neuronInitializer, outputActivation),
            };

            ConnectLayers();
        }
    }
}