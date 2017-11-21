using System;

namespace NeuraNet
{
    public class ExampleTrainedEventArgs : EventArgs
    {
        public int CurrentEpoch { get; internal set; }
        public int TotalEpochCount { get; internal set; }
        public int CurrentExample { get; internal set; }
        public int TotalExampleCount { get; internal set; }
        public double MeanCost { get; internal set; }
    }
}
