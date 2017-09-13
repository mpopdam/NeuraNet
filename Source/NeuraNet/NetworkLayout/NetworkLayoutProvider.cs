using System.Collections.Generic;

namespace NeuraNet.NetworkLayout
{
    public abstract class NetworkLayoutProvider : INetworkLayoutProvider
    {
        protected List<Layer> layers;

        protected void ConnectLayers()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                Layer previous = (i > 0) ? layers[i - 1] : null;
                Layer next = (i < (layers.Count - 1)) ? layers[i + 1] : null;

                layers[i].ConnectTo(previous, next);
            }
        }

        public IEnumerable<Layer> GetLayers()
        {
            return layers;
        }
    }
}