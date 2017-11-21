namespace NeuraNet
{
    /// <summary>
    /// An epoch is 1 round of training for all <see cref="TrainingExample"/>s in the training data.
    /// </summary>
    internal class Epoch
    {
        /// <summary>
        /// All examples in the training data set
        /// </summary>
        public TrainingExample[] Examples { get; }

        /// <summary>
        /// The 1-based number that indicates the sequence of the current epoch.
        /// </summary>
        public int Sequence { get; }

        public Epoch(TrainingExample[] examples, int sequence)
        {
            Examples = examples;
            Sequence = sequence;
        }
    }
}