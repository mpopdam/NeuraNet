namespace NeuraNet.NetworkLayout
{
    /// <summary>
    /// Initializes the weight of a synaps in the network.
    /// </summary>
    /// <remarks>
    /// This interface is mainly introduced to be able to test the network for a given set of weights.
    /// </remarks>
    public interface ILayerInitializer
    {
        /// <summary>
        /// Returns an initial weight for a synapse. Since the weights in our neural network will be stored
        /// in matrices, a weight can be initialized for a row and a column in a matrix.
        /// </summary>
        double GetWeight(int row, int column);

        /// <summary>
        /// Returns an initial value for the bias of a neuron. Since the biases in our neural network will be stored
        /// in a matrix, a bias can be initialized for a row and a column in a matrix (where the column is always 1).
        /// </summary>
        double GetBias(int column);
    }
}
