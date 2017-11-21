using MathNet.Numerics.Random;

namespace NeuraNet.NetworkLayout
{
    /// <summary>
    /// Initializes the weights and biases of the network with random values.
    /// </summary>
    public class RandomLayerInitializer : ILayerInitializer
    {
        public double GetWeight(int row, int column)
        {
            return GenerateRandom();
        }

        public double GetBias(int column)
        {
            return GenerateRandom();
        }

        private double GenerateRandom()
        {
            CryptoRandomSource random = new CryptoRandomSource();
            double value = random.NextDouble();
            bool negate = random.NextBoolean();
            return negate ? -value : value;
        }
    }
}
