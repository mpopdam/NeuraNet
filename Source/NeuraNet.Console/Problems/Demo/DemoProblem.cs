using System;
using System.Diagnostics;

namespace NeuraNet.ConsoleApp.Problems.Demo
{
    internal static class DemoProblem
    {
        public static void Solve()
        {
            Console.WriteLine($"Creating neural network...");
            var network = new NeuralNetwork(new DemoNetworkLayout());

            Console.WriteLine($"Training network...");
            var s = new Stopwatch();
            s.Start();

            network.Train(new[]
            {
                new TrainingExample(new[] { 1.0, -2.0, 3.0 }, new[] { 0.1234, 0.8766 })
            }, 10000, 0.5, 0.1);

            s.Stop();
            Console.WriteLine($"Training complete in {s.ElapsedMilliseconds} ms{Environment.NewLine}");
            Console.WriteLine("Querying network...");

            double[] input = { 1.0, -2.0, 3.0 };
            double[] output = network.Query(input);

            bool answer0IsCorrect = (Math.Abs(output[0] - 0.1234) < 0.00001);
            bool answer1IsCorrect = (Math.Abs(output[1] - 0.8766) < 0.00001);
            string isAnswerCorrect = answer0IsCorrect && answer1IsCorrect ? "Correct" : "Wrong";

            Console.WriteLine($"Network answer for [{input[0]}, {input[1]}, {input[2]}] = [{output[0]:0.00000}, {output[1]:0.00000}] ({ isAnswerCorrect })");
        }
    }
}
