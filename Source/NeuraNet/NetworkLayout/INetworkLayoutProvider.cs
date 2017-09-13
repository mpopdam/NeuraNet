using System.Collections.Generic;

namespace NeuraNet.NetworkLayout
{
    /// <summary>
    /// Provides the layout of a neural network, i.e. the layers and the number of neurons in each layer.
    /// </summary>
    public interface INetworkLayoutProvider
    {
        /// <summary>
        /// Gets the layers of the neural network. These include the hidden and the output layer. The input layer
        /// is not part of the layout.
        /// </summary>
        IEnumerable<Layer> GetLayers();
    }
}
