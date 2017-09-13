
using NeuraNet.Activations;

namespace NeuraNet.FormsApp
{
    internal class LayerConfiguration
    {
        public LayerConfiguration(int neuronCount, IActivation outputActivation)
        {
            NeuronCount = neuronCount;
            OutputActivation = outputActivation;
        }

        public int NeuronCount { get; }
        public IActivation OutputActivation { get; }
    }
}
