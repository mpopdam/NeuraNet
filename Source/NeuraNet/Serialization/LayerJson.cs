namespace NeuraNet.Serialization
{
    public class LayerJson
    {
        public string Activation { get; set; }

        public double[] Biases { get; set; }

        public double[,] Weights { get; set; }
    }
}
