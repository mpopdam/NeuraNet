using System;

using NeuraNet.NetworkLayout;

namespace NeuraNet.ConsoleApp.Problems.Demo
{
    internal class IncrementingLayerInitializer : ILayerInitializer
    {
        private readonly double[,] weights;
        private readonly double[] biases;

        public IncrementingLayerInitializer(int rows, int columns, double startWeight, double startBias)
        {
            double currentWeight = startWeight;
            weights = new double[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    weights[row, column] = Math.Round(currentWeight, 3);
                    currentWeight += 0.001;
                }
            }

            double currentBias = startBias;
            biases = new double[columns];

            for (int column = 0; column < columns; column++)
            {
                biases[column] = Math.Round(currentBias, 3);
                currentBias += 0.001;
            }
        }

        public double GetWeight(int row, int column)
        {
            return weights[row, column];
        }

        public double GetBias(int column)
        {
            return biases[column];
        }
    }
}
