using System.Drawing;

namespace NeuraNet.FormsApp
{
    internal class DigitTestResult
    {
        private int CorrectAnswer { get; }
        private int NetworkAnswer { get; }
        public Bitmap Bitmap { get; }

        public bool IsCorrect => CorrectAnswer == NetworkAnswer;

        public DigitTestResult(int correctAnswer, int networkAnswer, Bitmap bitmap)
        {
            CorrectAnswer = correctAnswer;
            NetworkAnswer = networkAnswer;
            Bitmap = bitmap;
        }
    }
}
