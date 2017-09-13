using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuraNet.Activations;
using NeuraNet.Serialization;

namespace NeuraNet.FormsApp
{
    public partial class NeuralNetworkDemoForm : Form
    {
        private const string baseFolder = @"C:\Projects\NeuralNetworks\NeuraNet";
        private const string dataFolder = baseFolder + @"\Data";
        private const string saveNetworkFolder = baseFolder + @"\NetworkLayouts";
        private string digitsFolder = baseFolder + @"\Data\MyDigits";

        private readonly SynchronizationContext synchronizationContext;
        private NeuralNetwork network;

        private Bitmap drawnDigit;
        private bool isWriting = false;
        private Point previousPoint;

        public NeuralNetworkDemoForm()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetStatusText();

            EnableNetworkTraining(false);
            EnableNetworkTesting(false);

            ResetNetworkLayerControls();
        }

        private void NeuralNetworkDemoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (drawnDigit != null)
            {
                drawnDigit.Dispose();
            }
        }

        private void ResetNetworkLayerControls()
        {
            hiddenLayer1ActivationDropdown.DataSource = new[] { "ReLU", "Sigmoid", "Softplus", "Tanh" };
            hiddenLayer1ActivationDropdown.SelectedItem = "Sigmoid";

            hiddenLayer2CheckBox.Checked = false;
            hiddenLayer2CheckBox.Enabled = true;
            hiddenLayer2ActivationDropdown.DataSource = new[] { "ReLU", "Sigmoid", "Softplus", "Tanh" };
            hiddenLayer2ActivationDropdown.SelectedItem = "Sigmoid";

            hiddenLayer3CheckBox.Checked = false;
            hiddenLayer3CheckBox.Enabled = false;
            hiddenLayer3ActivationDropdown.DataSource = new[] { "ReLU", "Sigmoid", "Softplus", "Tanh" };
            hiddenLayer3ActivationDropdown.SelectedItem = "Sigmoid";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveCurrentNetworkValuesToFile();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            ResetStatusText();
            ResetNetworkLayerControls();
            if (LoadNetworkValuesFromFile())
            {
                EnableNetworkTraining(true);
                EnableNetworkTesting(true);

                DisplayNetworkConfigurationValues();
            }
        }

        private void DisplayNetworkConfigurationValues()
        {
            IEnumerable<Layer> layers = network.GetLayers();

            Layer hiddenLayer1 = layers.ElementAt(0);
            hiddenLayer1NeuronCountSelector.Value = hiddenLayer1.NeuronCount;
            hiddenLayer1ActivationDropdown.SelectedItem = hiddenLayer1.OutputActivation.Name;

            int hiddenLayerCount = layers.Count() - 1; // input layer is not in the list; last layer is output layer
            if (hiddenLayerCount > 1)
            {
                Layer hiddenLayer = layers.ElementAt(1);
                hiddenLayer2CheckBox.Checked = true;
                hiddenLayer2NeuronCountSelector.Value = hiddenLayer.NeuronCount;
                hiddenLayer2ActivationDropdown.SelectedItem = hiddenLayer.OutputActivation.Name;
            }

            if (hiddenLayerCount > 2)
            {
                Layer hiddenLayer = layers.ElementAt(2);
                hiddenLayer3CheckBox.Checked = true;
                hiddenLayer3NeuronCountSelector.Value = hiddenLayer.NeuronCount;
                hiddenLayer3ActivationDropdown.SelectedItem = hiddenLayer.OutputActivation.Name;
            }
        }

        private void hiddenLayer2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hiddenLayer2NeuronCountSelector.Enabled = hiddenLayer2CheckBox.Checked;
            hiddenLayer2ActivationDropdown.Enabled = hiddenLayer2CheckBox.Checked;

            hiddenLayer3CheckBox.Enabled = hiddenLayer2CheckBox.Checked;
            if (!hiddenLayer3CheckBox.Enabled)
            {
                hiddenLayer3CheckBox.Checked = false;
            }
        }

        private void hiddenLayer3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hiddenLayer3NeuronCountSelector.Enabled = hiddenLayer3CheckBox.Checked;
            hiddenLayer3ActivationDropdown.Enabled = hiddenLayer3CheckBox.Checked;
        }

        private void createNetworkButton_Click(object sender, EventArgs e)
        {
            ResetStatusText();
            CreateCustomNetwork();

            EnableNetworkTraining(true);
            EnableNetworkTesting(true);
        }

        private async void trainNetworkButton_ClickAsync(object sender, EventArgs e)
        {
            await StartTraining();

            trainingStatusText.Text = @"Training complete!";

            EnableNetworkTesting(true);
        }

        private async void testNetworkButton_Click(object sender, EventArgs e)
        {
            var testResults = await Task.Run(() => QueryNetwork(network));

            int correctAnswerCount = testResults.Count(result => result.IsCorrect);
            double performance = 100.0 * correctAnswerCount / testResults.Count;
            networkTestPerformanceText.Text = $"{performance:0.0}%";

            testDigitPictureBox.Image = null;
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            EvaluateDigitFromFile();
        }

        private void clearDigitButton_Click(object sender, EventArgs e)
        {
            ClearHandwrittenDigit();
        }

        private void readDrawnDigitButton_Click(object sender, EventArgs e)
        {
            ReadHandwrittenDigit();
        }

        private void ResetStatusText()
        {
            epochProgressText.Text = "";
            exampleProgressText.Text = "";
            costText.Text = "";
            trainingStatusText.Text = "";

            testStatusText.Text = "";
            networkTestPerformanceText.Text = "";

            networkAnswerLabel.Text = "";

            answerLabel.Visible = false;
            result0Label.Visible = false;
            result0Text.Text = "";
            result1Label.Visible = false;
            result1Text.Text = "";
            result2Label.Visible = false;
            result2Text.Text = "";
            result3Label.Visible = false;
            result3Text.Text = "";
            result4Label.Visible = false;
            result4Text.Text = "";
            result5Label.Visible = false;
            result5Text.Text = "";
            result6Label.Visible = false;
            result6Text.Text = "";
            result7Label.Visible = false;
            result7Text.Text = "";
            result8Label.Visible = false;
            result8Text.Text = "";
            result9Label.Visible = false;
            result9Text.Text = "";

            digitPictureBox.Image = null;
            testDigitPictureBox.Image = null;
        }

        private void EnableNetworkTraining(bool enable)
        {
            trainNetworkButton.Enabled = enable;
            saveButton.Enabled = enable;
        }

        private void EnableNetworkTesting(bool enable)
        {
            testNetworkButton.Enabled = enable;
            loadImageButton.Enabled = enable;

            writingPanel.Enabled = enable;
            clearDigitButton.Enabled = enable;
            readDrawnDigitButton.Enabled = enable;
        }

        private void SaveCurrentNetworkValuesToFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = saveNetworkFolder,
                Title = @"Save neural network layout",
                Filter = @"Json files (*.json)|*.json|All files (*.*)|*.*",
                AddExtension = true,
            };

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string json = new NetworkJsonConverter().Serialize(network);

                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        private bool LoadNetworkValuesFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = saveNetworkFolder,
                Title = @"Open neural network layout",
                Filter = @"Json files (*.json)|*.json|All files (*.*)|*.*",
                Multiselect = false,
                AddExtension = true,
            };

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);

                network = new NetworkJsonConverter().Deserialize(json);
            }

            return result == DialogResult.OK;
        }

        private void CreateCustomNetwork()
        {
            LayerConfiguration layer1 = GetLayerConfiguration(hiddenLayer1NeuronCountSelector, hiddenLayer1ActivationDropdown);
            List<LayerConfiguration> nextLayers = new List<LayerConfiguration>();
            if (hiddenLayer2CheckBox.Checked)
            {
                nextLayers.Add(GetLayerConfiguration(hiddenLayer2NeuronCountSelector, hiddenLayer2ActivationDropdown));
            }

            if (hiddenLayer3CheckBox.Checked)
            {
                nextLayers.Add(GetLayerConfiguration(hiddenLayer3NeuronCountSelector, hiddenLayer3ActivationDropdown));
            }

            var layout = new CustomNetworkLayout(layer1, nextLayers.ToArray());
            network = new NeuralNetwork(layout);
        }

        private LayerConfiguration GetLayerConfiguration(NumericUpDown neuronCountSelector, ComboBox activationDropdown)
        {
            int neuronCount = decimal.ToInt32(neuronCountSelector.Value);
            string selectedItem = (string)activationDropdown.SelectedItem;

            IActivation activation = new SigmoidActivation();

            return new LayerConfiguration(neuronCount, activation);
        }

        private async Task StartTraining()
        {
            int numberOfEpochs = decimal.ToInt32(numberOfEpochsNumberSelector.Value);
            double learningRate = decimal.ToDouble(learningRateNumberSelector.Value);
            double momentum = decimal.ToDouble(momentumNumberSelector.Value);

            await Task.Run(() => TrainNetwork(numberOfEpochs, learningRate, momentum));
        }

        private void TrainNetwork(int numberOfEpochs, double learningRate, double momentum)
        {
            synchronizationContext.Post(obj =>
            {
                trainingStatusText.Text = "Reading training examples...";
            }, null);

            TrainingExample[] examples = ReadExamplesFrom(Path.Combine(dataFolder, "mnist_train.csv"));

            synchronizationContext.Post(obj =>
            {
                trainingStatusText.Text = @"Training network...";
            }, null);

            network.ExampleTrained += UpdateTrainingProgress;
            network.Train(examples, numberOfEpochs, learningRate, momentum);
        }

        private void UpdateTrainingProgress(object sender, ExampleTrainedEventArgs args)
        {
            if (args.CurrentExample % 10 != 0)
            {
                return;
            }

            synchronizationContext.Post(obj =>
            {
                ExampleTrainedEventArgs e = (ExampleTrainedEventArgs)obj;

                epochProgressText.Text = $@"{e.CurrentEpoch} / {e.TotalEpochCount}";
                exampleProgressText.Text = $@"{e.CurrentExample} / {e.TotalExampleCount}";
                costText.Text = $@"{e.MeanCost:0.000000}";
            }, args);
        }

        private TrainingExample[] ReadExamplesFrom(string fileName)
        {
            var allLines = File.ReadAllLines(fileName)
                .AsParallel()
                .Select(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

            return allLines
                .Select(CreateExample)
                .ToArray();
        }

        private static TrainingExample CreateExample(string[] lineValues)
        {
            // The first element in the line represents the value of the digit
            int digitValue = int.Parse(lineValues[0]);
            double[] targets = Enumerable.Range(0, 10).Select(_ => 0.01).ToArray();
            targets[digitValue] = 0.99;

            // The rest of the values in the line represent the greyscale (0-255) of each pixel of the digit
            string[] digitPixels = lineValues.Skip(1).ToArray();
            double[] normalizedInput = NormalizeInput(digitPixels);

            return new TrainingExample(normalizedInput, targets);
        }

        private static double[] NormalizeInput(string[] input)
        {
            return input
                .Select(double.Parse)
                .Select(NormalizeGrayScaleValue)
                .ToArray();
        }

        /// <summary>
        /// Convert a value between 0 - 255 to a value between 0.01 - 1
        /// </summary>
        private static double NormalizeGrayScaleValue(double grayscaleValue)
        {
            return (grayscaleValue / 255) * 0.99 + 0.01;
        }

        private List<DigitTestResult> QueryNetwork(NeuralNetwork network)
        {
            synchronizationContext.Post(obj =>
            {
                testStatusText.Text = @"Reading test examples...";
            }, null);

            string[][] testDigits = ReadTestDigitsFrom(Path.Combine(dataFolder, "mnist_test.csv"));

            var testResults = new List<DigitTestResult>();

            foreach (string[] input in testDigits)
            {
                string[] inputDigitPixels = input.Skip(1).ToArray();
                double[] normalizedInput = NormalizeInput(inputDigitPixels);
                double[] response = network.Query(normalizedInput);

                double max = response.Max(x => x);
                int networkAnswer = response.ToList().IndexOf(max);

                int correctAnswer = int.Parse(input[0]);

                int[] invertedPixels = inputDigitPixels.Select(int.Parse).ToArray();
                InputDigit inputDigit = InputDigit.FromInvertedPixels(correctAnswer, invertedPixels);

                var testResult = new DigitTestResult(correctAnswer, networkAnswer, inputDigit.Image);
                testResults.Add(testResult);

                int totalTests = testResults.Count;
                int correctAnswerCount = testResults.Count(result => result.IsCorrect);

                synchronizationContext.Post(obj =>
                {
                    var testDigitResult = (DigitTestResult)obj;
                    testDigitPictureBox.Image = testDigitResult.Bitmap;
                    testStatusText.Text = $@"Total: {totalTests} ; Wrong: {totalTests - correctAnswerCount}";
                }, testResult);
            }

            return testResults;
        }

        private static string[][] ReadTestDigitsFrom(string filename)
        {
            return File.ReadLines(filename)
                .Select(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .ToArray();
        }

        private void EvaluateDigitFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = digitsFolder
            };

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                digitsFolder = Path.GetDirectoryName(openFileDialog.FileName);

                Bitmap digitImage = (Bitmap)Image.FromFile(openFileDialog.FileName);
                digitPictureBox.Image = digitImage;

                string digitLabel = Path.GetFileNameWithoutExtension(openFileDialog.FileName).First().ToString();
                int correctAnswer = int.Parse(digitLabel);
                InputDigit input = InputDigit.FromImage(correctAnswer, digitImage);

                double[] normalizedPixels = input.Pixels.Select(p => NormalizeGrayScaleValue(p)).ToArray();
                double[] responses = network.Query(normalizedPixels);

                DisplayAnswer(responses);
            }
        }

        private void DisplayAnswer(double[] responses)
        {
            double maximum = responses.Max(x => x);
            int networkAnswer = responses.ToList().IndexOf(maximum);

            networkAnswerLabel.Text = networkAnswer.ToString();

            answerLabel.Visible = true;
            result0Label.Visible = true;
            result0Text.Text = $"{responses[0]:0.000}";
            result1Label.Visible = true;
            result1Text.Text = $"{responses[1]:0.000}";
            result2Label.Visible = true;
            result2Text.Text = $"{responses[2]:0.000}";
            result3Label.Visible = true;
            result3Text.Text = $"{responses[3]:0.000}";
            result4Label.Visible = true;
            result4Text.Text = $"{responses[4]:0.000}";
            result5Label.Visible = true;
            result5Text.Text = $"{responses[5]:0.000}";
            result6Label.Visible = true;
            result6Text.Text = $"{responses[6]:0.000}";
            result7Label.Visible = true;
            result7Text.Text = $"{responses[7]:0.000}";
            result8Label.Visible = true;
            result8Text.Text = $"{responses[8]:0.000}";
            result9Label.Visible = true;
            result9Text.Text = $"{responses[9]:0.000}";
        }

        private void writingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (drawnDigit != null)
            {
                e.Graphics.DrawImage(drawnDigit, 0, 0);
            }
        }

        private void writingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isWriting = true;
            previousPoint = e.Location;
        }

        private void writingPanel_MouseLeave(object sender, EventArgs e)
        {
            isWriting = false;
        }

        private void writingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isWriting = false;
        }

        private void writingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isWriting)
            {
                if (drawnDigit == null)
                {
                    drawnDigit = new Bitmap(writingPanel.Width, writingPanel.Height);
                }

                using (Graphics g = Graphics.FromImage(drawnDigit))
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(pen, previousPoint, e.Location);
                    previousPoint = e.Location;
                    writingPanel.Invalidate();
                }
            }
        }

        private void ClearHandwrittenDigit()
        {
            drawnDigit = new Bitmap(writingPanel.Width, writingPanel.Height);

            using (Graphics g = Graphics.FromImage(drawnDigit))
            {
                writingPanel.Invalidate();
            }
        }

        private void ReadHandwrittenDigit()
        {
            Bitmap handwrittenDigit = new Bitmap(writingPanel.Width, writingPanel.Height);
            writingPanel.DrawToBitmap(handwrittenDigit, new Rectangle(0, 0, writingPanel.Width, writingPanel.Height));

            InputDigit input = InputDigit.FromImage(0, handwrittenDigit);

            double[] normalizedPixels = input.Pixels.Select(p => NormalizeGrayScaleValue(p)).ToArray();
            double[] responses = network.Query(normalizedPixels);

            DisplayAnswer(responses);
        }
    }
}
