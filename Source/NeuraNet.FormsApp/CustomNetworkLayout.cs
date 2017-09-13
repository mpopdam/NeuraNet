using System.Collections.Generic;

using NeuraNet.Activations;
using NeuraNet.NetworkLayout;

namespace NeuraNet.FormsApp
{
    internal class CustomNetworkLayout : INetworkLayoutProvider
    {
        private readonly List<Layer> layers;

        public CustomNetworkLayout(LayerConfiguration firstHiddenLayer, params LayerConfiguration[] nextHiddenLayers)
        {
            var initializer = new RandomLayerInitializer();

            layers = new List<Layer>();
            layers.Add(new Layer(784, firstHiddenLayer.NeuronCount, initializer, firstHiddenLayer.OutputActivation));

            int previousLayerNeuronCount = firstHiddenLayer.NeuronCount;
            foreach (LayerConfiguration hiddenLayer in nextHiddenLayers)
            {
                layers.Add(new Layer(previousLayerNeuronCount, hiddenLayer.NeuronCount, initializer, hiddenLayer.OutputActivation));
                previousLayerNeuronCount = hiddenLayer.NeuronCount;
            }

            layers.Add(new Layer(previousLayerNeuronCount, 10, initializer, new SigmoidActivation()));
        }

        public IEnumerable<Layer> GetLayers()
        {
            return layers;
        }
    }
}
