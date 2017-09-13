using System.Collections.Generic;
using System.Drawing;

namespace NeuraNet.FormsApp
{
    internal class NetworkPerformance
    {
        private List<DigitTestResult> testResults = new List<DigitTestResult>();

        public void Add(DigitTestResult testResult)
        {
            testResults.Add(testResult);
        }
    }

    internal class DigitTestResult
    {
        public int CorrectAnswer { get; }
        public int NetworkAnswer { get; }
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
