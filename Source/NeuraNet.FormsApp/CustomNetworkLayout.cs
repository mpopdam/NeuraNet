using System.Collections.Generic;

using NeuraNet.Activations;
using NeuraNet.NetworkLayout;

namespace NeuraNet.FormsApp
{
    internal class CustomNetworkLayout : NetworkLayoutProvider
    {
        public CustomNetworkLayout(LayerConfiguration firstHiddenConfig, params LayerConfiguration[] nextHiddenConfigs)
        {
            var initializer = new RandomLayerInitializer();

            layers = new List<Layer>
            {
                new Layer(784, firstHiddenConfig.NeuronCount, initializer, firstHiddenConfig.OutputActivation)
            };

            int previousLayerNeuronCount = firstHiddenConfig.NeuronCount;
            foreach (LayerConfiguration layerConfig in nextHiddenConfigs)
            {
                layers.Add(new Layer(previousLayerNeuronCount, layerConfig.NeuronCount, initializer, layerConfig.OutputActivation));
                previousLayerNeuronCount = layerConfig.NeuronCount;
            }

            layers.Add(new Layer(previousLayerNeuronCount, 10, initializer, new SigmoidActivation()));

            ConnectLayers();
        }
    }
}
