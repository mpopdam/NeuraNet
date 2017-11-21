namespace NeuraNet.FormsApp
{
    partial class NeuralNetworkDemoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetworkDemoForm));
            this.digitPictureBox = new System.Windows.Forms.PictureBox();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.trainNetworkButton = new System.Windows.Forms.Button();
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.trainNetworkGroupBox = new System.Windows.Forms.GroupBox();
            this.numberOfEpochsLabel = new System.Windows.Forms.Label();
            this.numberOfEpochsNumberSelector = new System.Windows.Forms.NumericUpDown();
            this.momentumLabel = new System.Windows.Forms.Label();
            this.learningRateLabel = new System.Windows.Forms.Label();
            this.momentumNumberSelector = new System.Windows.Forms.NumericUpDown();
            this.learningRateNumberSelector = new System.Windows.Forms.NumericUpDown();
            this.trainingStatusText = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.exampleLabel = new System.Windows.Forms.Label();
            this.costText = new System.Windows.Forms.Label();
            this.exampleProgressText = new System.Windows.Forms.Label();
            this.epochLabel = new System.Windows.Forms.Label();
            this.epochProgressText = new System.Windows.Forms.Label();
            this.testNetworkGroupBox = new System.Windows.Forms.GroupBox();
            this.testStatusText = new System.Windows.Forms.Label();
            this.testDigitPictureBox = new System.Windows.Forms.PictureBox();
            this.networkTestPerformanceText = new System.Windows.Forms.Label();
            this.createNetworkGroupBox = new System.Windows.Forms.GroupBox();
            this.hiddenLayer3NeuronCountSelector = new System.Windows.Forms.NumericUpDown();
            this.hiddenLayer3ActivationDropdown = new System.Windows.Forms.ComboBox();
            this.hiddenLayer3CheckBox = new System.Windows.Forms.CheckBox();
            this.hiddenLayer2NeuronCountSelector = new System.Windows.Forms.NumericUpDown();
            this.hiddenLayer2ActivationDropdown = new System.Windows.Forms.ComboBox();
            this.hiddenLayer2CheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createNetworkButton = new System.Windows.Forms.Button();
            this.hiddenLayer1NeuronCountSelector = new System.Windows.Forms.NumericUpDown();
            this.hiddenLayer1ActivationDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hiddenNeuronCountLabel = new System.Windows.Forms.Label();
            this.result0Label = new System.Windows.Forms.Label();
            this.result0Text = new System.Windows.Forms.Label();
            this.result1Label = new System.Windows.Forms.Label();
            this.result1Text = new System.Windows.Forms.Label();
            this.result2Label = new System.Windows.Forms.Label();
            this.result2Text = new System.Windows.Forms.Label();
            this.result3Label = new System.Windows.Forms.Label();
            this.result3Text = new System.Windows.Forms.Label();
            this.result4Label = new System.Windows.Forms.Label();
            this.result4Text = new System.Windows.Forms.Label();
            this.result5Label = new System.Windows.Forms.Label();
            this.result5Text = new System.Windows.Forms.Label();
            this.result6Label = new System.Windows.Forms.Label();
            this.result6Text = new System.Windows.Forms.Label();
            this.result7Label = new System.Windows.Forms.Label();
            this.result7Text = new System.Windows.Forms.Label();
            this.result8Label = new System.Windows.Forms.Label();
            this.result8Text = new System.Windows.Forms.Label();
            this.result9Label = new System.Windows.Forms.Label();
            this.result9Text = new System.Windows.Forms.Label();
            this.networkAnswerLabel = new System.Windows.Forms.Label();
            this.testIndividualDigitGroupBox = new System.Windows.Forms.GroupBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.writeDigitLabel = new System.Windows.Forms.Label();
            this.readDrawnDigitButton = new System.Windows.Forms.Button();
            this.clearDigitButton = new System.Windows.Forms.Button();
            this.writingPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.digitPictureBox)).BeginInit();
            this.trainNetworkGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfEpochsNumberSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumNumberSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateNumberSelector)).BeginInit();
            this.testNetworkGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDigitPictureBox)).BeginInit();
            this.createNetworkGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayer3NeuronCountSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayer2NeuronCountSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayer1NeuronCountSelector)).BeginInit();
            this.testIndividualDigitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // digitPictureBox
            // 
            this.digitPictureBox.Location = new System.Drawing.Point(125, 17);
            this.digitPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.digitPictureBox.Name = "digitPictureBox";
            this.digitPictureBox.Size = new System.Drawing.Size(32, 32);
            this.digitPictureBox.TabIndex = 0;
            this.digitPictureBox.TabStop = false;
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(5, 20);
            this.loadImageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(109, 30);
            this.loadImageButton.TabIndex = 11;
            this.loadImageButton.Text = "Select Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // trainNetworkButton
            // 
            this.trainNetworkButton.Location = new System.Drawing.Point(284, 69);
            this.trainNetworkButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainNetworkButton.Name = "trainNetworkButton";
            this.trainNetworkButton.Size = new System.Drawing.Size(109, 30);
            this.trainNetworkButton.TabIndex = 8;
            this.trainNetworkButton.Text = "Train Network";
            this.trainNetworkButton.UseVisualStyleBackColor = true;
            this.trainNetworkButton.Click += new System.EventHandler(this.trainNetworkButton_ClickAsync);
            // 
            // testNetworkButton
            // 
            this.testNetworkButton.Location = new System.Drawing.Point(5, 25);
            this.testNetworkButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testNetworkButton.Name = "testNetworkButton";
            this.testNetworkButton.Size = new System.Drawing.Size(107, 30);
            this.testNetworkButton.TabIndex = 10;
            this.testNetworkButton.Text = "Test Network";
            this.testNetworkButton.UseVisualStyleBackColor = true;
            this.testNetworkButton.Click += new System.EventHandler(this.testNetworkButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(417, 69);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 30);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(5, 21);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(109, 30);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load Existing";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // trainNetworkGroupBox
            // 
            this.trainNetworkGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trainNetworkGroupBox.Controls.Add(this.numberOfEpochsLabel);
            this.trainNetworkGroupBox.Controls.Add(this.numberOfEpochsNumberSelector);
            this.trainNetworkGroupBox.Controls.Add(this.momentumLabel);
            this.trainNetworkGroupBox.Controls.Add(this.learningRateLabel);
            this.trainNetworkGroupBox.Controls.Add(this.momentumNumberSelector);
            this.trainNetworkGroupBox.Controls.Add(this.learningRateNumberSelector);
            this.trainNetworkGroupBox.Controls.Add(this.trainingStatusText);
            this.trainNetworkGroupBox.Controls.Add(this.costLabel);
            this.trainNetworkGroupBox.Controls.Add(this.exampleLabel);
            this.trainNetworkGroupBox.Controls.Add(this.costText);
            this.trainNetworkGroupBox.Controls.Add(this.exampleProgressText);
            this.trainNetworkGroupBox.Controls.Add(this.epochLabel);
            this.trainNetworkGroupBox.Controls.Add(this.epochProgressText);
            this.trainNetworkGroupBox.Controls.Add(this.saveButton);
            this.trainNetworkGroupBox.Controls.Add(this.trainNetworkButton);
            this.trainNetworkGroupBox.Location = new System.Drawing.Point(12, 187);
            this.trainNetworkGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainNetworkGroupBox.Name = "trainNetworkGroupBox";
            this.trainNetworkGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainNetworkGroupBox.Size = new System.Drawing.Size(933, 234);
            this.trainNetworkGroupBox.TabIndex = 10;
            this.trainNetworkGroupBox.TabStop = false;
            this.trainNetworkGroupBox.Text = "Train Network";
            // 
            // numberOfEpochsLabel
            // 
            this.numberOfEpochsLabel.AutoSize = true;
            this.numberOfEpochsLabel.Location = new System.Drawing.Point(5, 75);
            this.numberOfEpochsLabel.Name = "numberOfEpochsLabel";
            this.numberOfEpochsLabel.Size = new System.Drawing.Size(129, 17);
            this.numberOfEpochsLabel.TabIndex = 17;
            this.numberOfEpochsLabel.Text = "Number of Epochs:";
            // 
            // numberOfEpochsNumberSelector
            // 
            this.numberOfEpochsNumberSelector.Location = new System.Drawing.Point(173, 73);
            this.numberOfEpochsNumberSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numberOfEpochsNumberSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfEpochsNumberSelector.Name = "numberOfEpochsNumberSelector";
            this.numberOfEpochsNumberSelector.Size = new System.Drawing.Size(95, 22);
            this.numberOfEpochsNumberSelector.TabIndex = 7;
            this.numberOfEpochsNumberSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // momentumLabel
            // 
            this.momentumLabel.AutoSize = true;
            this.momentumLabel.Location = new System.Drawing.Point(5, 47);
            this.momentumLabel.Name = "momentumLabel";
            this.momentumLabel.Size = new System.Drawing.Size(81, 17);
            this.momentumLabel.TabIndex = 17;
            this.momentumLabel.Text = "Momentum:";
            // 
            // learningRateLabel
            // 
            this.learningRateLabel.AutoSize = true;
            this.learningRateLabel.Location = new System.Drawing.Point(5, 18);
            this.learningRateLabel.Name = "learningRateLabel";
            this.learningRateLabel.Size = new System.Drawing.Size(102, 17);
            this.learningRateLabel.TabIndex = 16;
            this.learningRateLabel.Text = "Learning Rate:";
            // 
            // momentumNumberSelector
            // 
            this.momentumNumberSelector.DecimalPlaces = 1;
            this.momentumNumberSelector.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.momentumNumberSelector.Location = new System.Drawing.Point(173, 46);
            this.momentumNumberSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.momentumNumberSelector.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.momentumNumberSelector.Name = "momentumNumberSelector";
            this.momentumNumberSelector.Size = new System.Drawing.Size(95, 22);
            this.momentumNumberSelector.TabIndex = 6;
            this.momentumNumberSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // learningRateNumberSelector
            // 
            this.learningRateNumberSelector.DecimalPlaces = 1;
            this.learningRateNumberSelector.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.learningRateNumberSelector.Location = new System.Drawing.Point(173, 17);
            this.learningRateNumberSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.learningRateNumberSelector.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.learningRateNumberSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.learningRateNumberSelector.Name = "learningRateNumberSelector";
            this.learningRateNumberSelector.Size = new System.Drawing.Size(95, 22);
            this.learningRateNumberSelector.TabIndex = 5;
            this.learningRateNumberSelector.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // trainingStatusText
            // 
            this.trainingStatusText.AutoSize = true;
            this.trainingStatusText.Location = new System.Drawing.Point(281, 101);
            this.trainingStatusText.Name = "trainingStatusText";
            this.trainingStatusText.Size = new System.Drawing.Size(95, 17);
            this.trainingStatusText.TabIndex = 14;
            this.trainingStatusText.Text = "trainingStatus";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(11, 194);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(40, 17);
            this.costLabel.TabIndex = 13;
            this.costLabel.Text = "Cost:";
            // 
            // exampleLabel
            // 
            this.exampleLabel.AutoSize = true;
            this.exampleLabel.Location = new System.Drawing.Point(11, 167);
            this.exampleLabel.Name = "exampleLabel";
            this.exampleLabel.Size = new System.Drawing.Size(65, 17);
            this.exampleLabel.TabIndex = 13;
            this.exampleLabel.Text = "Example:";
            // 
            // costText
            // 
            this.costText.AutoSize = true;
            this.costText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costText.Location = new System.Drawing.Point(83, 188);
            this.costText.Name = "costText";
            this.costText.Size = new System.Drawing.Size(45, 29);
            this.costText.TabIndex = 12;
            this.costText.Text = "0.1";
            // 
            // exampleProgressText
            // 
            this.exampleProgressText.AutoSize = true;
            this.exampleProgressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exampleProgressText.Location = new System.Drawing.Point(83, 160);
            this.exampleProgressText.Name = "exampleProgressText";
            this.exampleProgressText.Size = new System.Drawing.Size(58, 29);
            this.exampleProgressText.TabIndex = 12;
            this.exampleProgressText.Text = "0 / 1";
            // 
            // epochLabel
            // 
            this.epochLabel.AutoSize = true;
            this.epochLabel.Location = new System.Drawing.Point(11, 140);
            this.epochLabel.Name = "epochLabel";
            this.epochLabel.Size = new System.Drawing.Size(48, 17);
            this.epochLabel.TabIndex = 11;
            this.epochLabel.Text = "Epoch";
            // 
            // epochProgressText
            // 
            this.epochProgressText.AutoSize = true;
            this.epochProgressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epochProgressText.Location = new System.Drawing.Point(83, 133);
            this.epochProgressText.Name = "epochProgressText";
            this.epochProgressText.Size = new System.Drawing.Size(58, 29);
            this.epochProgressText.TabIndex = 10;
            this.epochProgressText.Text = "0 / 1";
            // 
            // testNetworkGroupBox
            // 
            this.testNetworkGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.testNetworkGroupBox.Controls.Add(this.testStatusText);
            this.testNetworkGroupBox.Controls.Add(this.testNetworkButton);
            this.testNetworkGroupBox.Controls.Add(this.testDigitPictureBox);
            this.testNetworkGroupBox.Controls.Add(this.networkTestPerformanceText);
            this.testNetworkGroupBox.Location = new System.Drawing.Point(12, 425);
            this.testNetworkGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testNetworkGroupBox.Name = "testNetworkGroupBox";
            this.testNetworkGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testNetworkGroupBox.Size = new System.Drawing.Size(469, 199);
            this.testNetworkGroupBox.TabIndex = 11;
            this.testNetworkGroupBox.TabStop = false;
            this.testNetworkGroupBox.Text = "Test Network";
            // 
            // testStatusText
            // 
            this.testStatusText.AutoSize = true;
            this.testStatusText.Location = new System.Drawing.Point(43, 68);
            this.testStatusText.Name = "testStatusText";
            this.testStatusText.Size = new System.Drawing.Size(71, 17);
            this.testStatusText.TabIndex = 7;
            this.testStatusText.Text = "testStatus";
            // 
            // testDigitPictureBox
            // 
            this.testDigitPictureBox.Location = new System.Drawing.Point(8, 62);
            this.testDigitPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.testDigitPictureBox.Name = "testDigitPictureBox";
            this.testDigitPictureBox.Size = new System.Drawing.Size(32, 32);
            this.testDigitPictureBox.TabIndex = 0;
            this.testDigitPictureBox.TabStop = false;
            // 
            // networkTestPerformanceText
            // 
            this.networkTestPerformanceText.AutoSize = true;
            this.networkTestPerformanceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkTestPerformanceText.Location = new System.Drawing.Point(117, 23);
            this.networkTestPerformanceText.Name = "networkTestPerformanceText";
            this.networkTestPerformanceText.Size = new System.Drawing.Size(80, 29);
            this.networkTestPerformanceText.TabIndex = 12;
            this.networkTestPerformanceText.Text = "90.1%";
            // 
            // createNetworkGroupBox
            // 
            this.createNetworkGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer3NeuronCountSelector);
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer3ActivationDropdown);
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer3CheckBox);
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer2NeuronCountSelector);
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer2ActivationDropdown);
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer2CheckBox);
            this.createNetworkGroupBox.Controls.Add(this.label2);
            this.createNetworkGroupBox.Controls.Add(this.createNetworkButton);
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer1NeuronCountSelector);
            this.createNetworkGroupBox.Controls.Add(this.hiddenLayer1ActivationDropdown);
            this.createNetworkGroupBox.Controls.Add(this.label1);
            this.createNetworkGroupBox.Controls.Add(this.hiddenNeuronCountLabel);
            this.createNetworkGroupBox.Controls.Add(this.loadButton);
            this.createNetworkGroupBox.Location = new System.Drawing.Point(12, 12);
            this.createNetworkGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createNetworkGroupBox.Name = "createNetworkGroupBox";
            this.createNetworkGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createNetworkGroupBox.Size = new System.Drawing.Size(933, 171);
            this.createNetworkGroupBox.TabIndex = 12;
            this.createNetworkGroupBox.TabStop = false;
            this.createNetworkGroupBox.Text = "Create Network";
            // 
            // hiddenLayer3NeuronCountSelector
            // 
            this.hiddenLayer3NeuronCountSelector.Enabled = false;
            this.hiddenLayer3NeuronCountSelector.Location = new System.Drawing.Point(397, 98);
            this.hiddenLayer3NeuronCountSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer3NeuronCountSelector.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.hiddenLayer3NeuronCountSelector.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.hiddenLayer3NeuronCountSelector.Name = "hiddenLayer3NeuronCountSelector";
            this.hiddenLayer3NeuronCountSelector.Size = new System.Drawing.Size(95, 22);
            this.hiddenLayer3NeuronCountSelector.TabIndex = 10;
            this.hiddenLayer3NeuronCountSelector.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // hiddenLayer3ActivationDropdown
            // 
            this.hiddenLayer3ActivationDropdown.Enabled = false;
            this.hiddenLayer3ActivationDropdown.FormattingEnabled = true;
            this.hiddenLayer3ActivationDropdown.Location = new System.Drawing.Point(397, 128);
            this.hiddenLayer3ActivationDropdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer3ActivationDropdown.Name = "hiddenLayer3ActivationDropdown";
            this.hiddenLayer3ActivationDropdown.Size = new System.Drawing.Size(95, 24);
            this.hiddenLayer3ActivationDropdown.TabIndex = 11;
            // 
            // hiddenLayer3CheckBox
            // 
            this.hiddenLayer3CheckBox.AutoSize = true;
            this.hiddenLayer3CheckBox.Enabled = false;
            this.hiddenLayer3CheckBox.Location = new System.Drawing.Point(437, 70);
            this.hiddenLayer3CheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer3CheckBox.Name = "hiddenLayer3CheckBox";
            this.hiddenLayer3CheckBox.Size = new System.Drawing.Size(18, 17);
            this.hiddenLayer3CheckBox.TabIndex = 9;
            this.hiddenLayer3CheckBox.UseVisualStyleBackColor = true;
            this.hiddenLayer3CheckBox.CheckedChanged += new System.EventHandler(this.hiddenLayer3CheckBox_CheckedChanged);
            // 
            // hiddenLayer2NeuronCountSelector
            // 
            this.hiddenLayer2NeuronCountSelector.Enabled = false;
            this.hiddenLayer2NeuronCountSelector.Location = new System.Drawing.Point(284, 98);
            this.hiddenLayer2NeuronCountSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer2NeuronCountSelector.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.hiddenLayer2NeuronCountSelector.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.hiddenLayer2NeuronCountSelector.Name = "hiddenLayer2NeuronCountSelector";
            this.hiddenLayer2NeuronCountSelector.Size = new System.Drawing.Size(95, 22);
            this.hiddenLayer2NeuronCountSelector.TabIndex = 7;
            this.hiddenLayer2NeuronCountSelector.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // hiddenLayer2ActivationDropdown
            // 
            this.hiddenLayer2ActivationDropdown.Enabled = false;
            this.hiddenLayer2ActivationDropdown.FormattingEnabled = true;
            this.hiddenLayer2ActivationDropdown.Location = new System.Drawing.Point(284, 128);
            this.hiddenLayer2ActivationDropdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer2ActivationDropdown.Name = "hiddenLayer2ActivationDropdown";
            this.hiddenLayer2ActivationDropdown.Size = new System.Drawing.Size(95, 24);
            this.hiddenLayer2ActivationDropdown.TabIndex = 8;
            // 
            // hiddenLayer2CheckBox
            // 
            this.hiddenLayer2CheckBox.AutoSize = true;
            this.hiddenLayer2CheckBox.Location = new System.Drawing.Point(325, 70);
            this.hiddenLayer2CheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer2CheckBox.Name = "hiddenLayer2CheckBox";
            this.hiddenLayer2CheckBox.Size = new System.Drawing.Size(18, 17);
            this.hiddenLayer2CheckBox.TabIndex = 6;
            this.hiddenLayer2CheckBox.UseVisualStyleBackColor = true;
            this.hiddenLayer2CheckBox.CheckedChanged += new System.EventHandler(this.hiddenLayer2CheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hidden Layers:";
            // 
            // createNetworkButton
            // 
            this.createNetworkButton.Location = new System.Drawing.Point(508, 124);
            this.createNetworkButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createNetworkButton.Name = "createNetworkButton";
            this.createNetworkButton.Size = new System.Drawing.Size(95, 30);
            this.createNetworkButton.TabIndex = 4;
            this.createNetworkButton.Text = "Create New";
            this.createNetworkButton.UseVisualStyleBackColor = true;
            this.createNetworkButton.Click += new System.EventHandler(this.createNetworkButton_Click);
            // 
            // hiddenLayer1NeuronCountSelector
            // 
            this.hiddenLayer1NeuronCountSelector.Location = new System.Drawing.Point(173, 98);
            this.hiddenLayer1NeuronCountSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer1NeuronCountSelector.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.hiddenLayer1NeuronCountSelector.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.hiddenLayer1NeuronCountSelector.Name = "hiddenLayer1NeuronCountSelector";
            this.hiddenLayer1NeuronCountSelector.Size = new System.Drawing.Size(95, 22);
            this.hiddenLayer1NeuronCountSelector.TabIndex = 2;
            this.hiddenLayer1NeuronCountSelector.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // hiddenLayer1ActivationDropdown
            // 
            this.hiddenLayer1ActivationDropdown.FormattingEnabled = true;
            this.hiddenLayer1ActivationDropdown.Location = new System.Drawing.Point(173, 128);
            this.hiddenLayer1ActivationDropdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hiddenLayer1ActivationDropdown.Name = "hiddenLayer1ActivationDropdown";
            this.hiddenLayer1ActivationDropdown.Size = new System.Drawing.Size(95, 24);
            this.hiddenLayer1ActivationDropdown.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hidden Layer Activation:";
            // 
            // hiddenNeuronCountLabel
            // 
            this.hiddenNeuronCountLabel.AutoSize = true;
            this.hiddenNeuronCountLabel.Location = new System.Drawing.Point(5, 100);
            this.hiddenNeuronCountLabel.Name = "hiddenNeuronCountLabel";
            this.hiddenNeuronCountLabel.Size = new System.Drawing.Size(149, 17);
            this.hiddenNeuronCountLabel.TabIndex = 0;
            this.hiddenNeuronCountLabel.Text = "Hidden Neuron Count:";
            // 
            // result0Label
            // 
            this.result0Label.AutoSize = true;
            this.result0Label.Location = new System.Drawing.Point(305, 18);
            this.result0Label.Name = "result0Label";
            this.result0Label.Size = new System.Drawing.Size(20, 17);
            this.result0Label.TabIndex = 13;
            this.result0Label.Text = "0:";
            // 
            // result0Text
            // 
            this.result0Text.AutoSize = true;
            this.result0Text.Location = new System.Drawing.Point(333, 18);
            this.result0Text.Name = "result0Text";
            this.result0Text.Size = new System.Drawing.Size(36, 17);
            this.result0Text.TabIndex = 13;
            this.result0Text.Text = "0.00";
            // 
            // result1Label
            // 
            this.result1Label.AutoSize = true;
            this.result1Label.Location = new System.Drawing.Point(305, 34);
            this.result1Label.Name = "result1Label";
            this.result1Label.Size = new System.Drawing.Size(20, 17);
            this.result1Label.TabIndex = 13;
            this.result1Label.Text = "1:";
            // 
            // result1Text
            // 
            this.result1Text.AutoSize = true;
            this.result1Text.Location = new System.Drawing.Point(333, 34);
            this.result1Text.Name = "result1Text";
            this.result1Text.Size = new System.Drawing.Size(36, 17);
            this.result1Text.TabIndex = 13;
            this.result1Text.Text = "0.00";
            // 
            // result2Label
            // 
            this.result2Label.AutoSize = true;
            this.result2Label.Location = new System.Drawing.Point(305, 52);
            this.result2Label.Name = "result2Label";
            this.result2Label.Size = new System.Drawing.Size(20, 17);
            this.result2Label.TabIndex = 13;
            this.result2Label.Text = "2:";
            // 
            // result2Text
            // 
            this.result2Text.AutoSize = true;
            this.result2Text.Location = new System.Drawing.Point(333, 52);
            this.result2Text.Name = "result2Text";
            this.result2Text.Size = new System.Drawing.Size(36, 17);
            this.result2Text.TabIndex = 13;
            this.result2Text.Text = "0.00";
            // 
            // result3Label
            // 
            this.result3Label.AutoSize = true;
            this.result3Label.Location = new System.Drawing.Point(305, 69);
            this.result3Label.Name = "result3Label";
            this.result3Label.Size = new System.Drawing.Size(20, 17);
            this.result3Label.TabIndex = 13;
            this.result3Label.Text = "3:";
            // 
            // result3Text
            // 
            this.result3Text.AutoSize = true;
            this.result3Text.Location = new System.Drawing.Point(333, 69);
            this.result3Text.Name = "result3Text";
            this.result3Text.Size = new System.Drawing.Size(36, 17);
            this.result3Text.TabIndex = 13;
            this.result3Text.Text = "0.00";
            // 
            // result4Label
            // 
            this.result4Label.AutoSize = true;
            this.result4Label.Location = new System.Drawing.Point(305, 86);
            this.result4Label.Name = "result4Label";
            this.result4Label.Size = new System.Drawing.Size(20, 17);
            this.result4Label.TabIndex = 13;
            this.result4Label.Text = "4:";
            // 
            // result4Text
            // 
            this.result4Text.AutoSize = true;
            this.result4Text.Location = new System.Drawing.Point(333, 86);
            this.result4Text.Name = "result4Text";
            this.result4Text.Size = new System.Drawing.Size(36, 17);
            this.result4Text.TabIndex = 13;
            this.result4Text.Text = "0.00";
            // 
            // result5Label
            // 
            this.result5Label.AutoSize = true;
            this.result5Label.Location = new System.Drawing.Point(305, 103);
            this.result5Label.Name = "result5Label";
            this.result5Label.Size = new System.Drawing.Size(20, 17);
            this.result5Label.TabIndex = 13;
            this.result5Label.Text = "5:";
            // 
            // result5Text
            // 
            this.result5Text.AutoSize = true;
            this.result5Text.Location = new System.Drawing.Point(333, 103);
            this.result5Text.Name = "result5Text";
            this.result5Text.Size = new System.Drawing.Size(36, 17);
            this.result5Text.TabIndex = 13;
            this.result5Text.Text = "0.00";
            // 
            // result6Label
            // 
            this.result6Label.AutoSize = true;
            this.result6Label.Location = new System.Drawing.Point(305, 121);
            this.result6Label.Name = "result6Label";
            this.result6Label.Size = new System.Drawing.Size(20, 17);
            this.result6Label.TabIndex = 13;
            this.result6Label.Text = "6:";
            // 
            // result6Text
            // 
            this.result6Text.AutoSize = true;
            this.result6Text.Location = new System.Drawing.Point(333, 121);
            this.result6Text.Name = "result6Text";
            this.result6Text.Size = new System.Drawing.Size(36, 17);
            this.result6Text.TabIndex = 13;
            this.result6Text.Text = "0.00";
            // 
            // result7Label
            // 
            this.result7Label.AutoSize = true;
            this.result7Label.Location = new System.Drawing.Point(305, 137);
            this.result7Label.Name = "result7Label";
            this.result7Label.Size = new System.Drawing.Size(20, 17);
            this.result7Label.TabIndex = 13;
            this.result7Label.Text = "7:";
            // 
            // result7Text
            // 
            this.result7Text.AutoSize = true;
            this.result7Text.Location = new System.Drawing.Point(333, 137);
            this.result7Text.Name = "result7Text";
            this.result7Text.Size = new System.Drawing.Size(36, 17);
            this.result7Text.TabIndex = 13;
            this.result7Text.Text = "0.00";
            // 
            // result8Label
            // 
            this.result8Label.AutoSize = true;
            this.result8Label.Location = new System.Drawing.Point(305, 154);
            this.result8Label.Name = "result8Label";
            this.result8Label.Size = new System.Drawing.Size(20, 17);
            this.result8Label.TabIndex = 13;
            this.result8Label.Text = "8:";
            // 
            // result8Text
            // 
            this.result8Text.AutoSize = true;
            this.result8Text.Location = new System.Drawing.Point(333, 154);
            this.result8Text.Name = "result8Text";
            this.result8Text.Size = new System.Drawing.Size(36, 17);
            this.result8Text.TabIndex = 13;
            this.result8Text.Text = "0.00";
            // 
            // result9Label
            // 
            this.result9Label.AutoSize = true;
            this.result9Label.Location = new System.Drawing.Point(305, 171);
            this.result9Label.Name = "result9Label";
            this.result9Label.Size = new System.Drawing.Size(20, 17);
            this.result9Label.TabIndex = 13;
            this.result9Label.Text = "9:";
            // 
            // result9Text
            // 
            this.result9Text.AutoSize = true;
            this.result9Text.Location = new System.Drawing.Point(333, 171);
            this.result9Text.Name = "result9Text";
            this.result9Text.Size = new System.Drawing.Size(36, 17);
            this.result9Text.TabIndex = 13;
            this.result9Text.Text = "0.00";
            // 
            // networkAnswerLabel
            // 
            this.networkAnswerLabel.AutoSize = true;
            this.networkAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkAnswerLabel.Location = new System.Drawing.Point(237, 79);
            this.networkAnswerLabel.Name = "networkAnswerLabel";
            this.networkAnswerLabel.Size = new System.Drawing.Size(42, 46);
            this.networkAnswerLabel.TabIndex = 1;
            this.networkAnswerLabel.Text = "0";
            // 
            // testIndividualDigitGroupBox
            // 
            this.testIndividualDigitGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testIndividualDigitGroupBox.Controls.Add(this.answerLabel);
            this.testIndividualDigitGroupBox.Controls.Add(this.writeDigitLabel);
            this.testIndividualDigitGroupBox.Controls.Add(this.readDrawnDigitButton);
            this.testIndividualDigitGroupBox.Controls.Add(this.clearDigitButton);
            this.testIndividualDigitGroupBox.Controls.Add(this.writingPanel);
            this.testIndividualDigitGroupBox.Controls.Add(this.result9Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.loadImageButton);
            this.testIndividualDigitGroupBox.Controls.Add(this.result9Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.networkAnswerLabel);
            this.testIndividualDigitGroupBox.Controls.Add(this.result4Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result8Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.digitPictureBox);
            this.testIndividualDigitGroupBox.Controls.Add(this.result4Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result0Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result8Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result0Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result3Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result5Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result7Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result1Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result3Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result5Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result7Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result1Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result2Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result6Label);
            this.testIndividualDigitGroupBox.Controls.Add(this.result6Text);
            this.testIndividualDigitGroupBox.Controls.Add(this.result2Label);
            this.testIndividualDigitGroupBox.Location = new System.Drawing.Point(501, 425);
            this.testIndividualDigitGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testIndividualDigitGroupBox.Name = "testIndividualDigitGroupBox";
            this.testIndividualDigitGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testIndividualDigitGroupBox.Size = new System.Drawing.Size(443, 199);
            this.testIndividualDigitGroupBox.TabIndex = 13;
            this.testIndividualDigitGroupBox.TabStop = false;
            this.testIndividualDigitGroupBox.Text = "Test Single Digit";
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(221, 62);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(58, 17);
            this.answerLabel.TabIndex = 18;
            this.answerLabel.Text = "Answer:";
            // 
            // writeDigitLabel
            // 
            this.writeDigitLabel.AutoSize = true;
            this.writeDigitLabel.Location = new System.Drawing.Point(5, 102);
            this.writeDigitLabel.Name = "writeDigitLabel";
            this.writeDigitLabel.Size = new System.Drawing.Size(136, 17);
            this.writeDigitLabel.TabIndex = 17;
            this.writeDigitLabel.Text = "Write your own digit:";
            // 
            // readDrawnDigitButton
            // 
            this.readDrawnDigitButton.Location = new System.Drawing.Point(53, 160);
            this.readDrawnDigitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.readDrawnDigitButton.Name = "readDrawnDigitButton";
            this.readDrawnDigitButton.Size = new System.Drawing.Size(60, 30);
            this.readDrawnDigitButton.TabIndex = 16;
            this.readDrawnDigitButton.Text = "Go";
            this.readDrawnDigitButton.UseVisualStyleBackColor = true;
            this.readDrawnDigitButton.Click += new System.EventHandler(this.readDrawnDigitButton_Click);
            // 
            // clearDigitButton
            // 
            this.clearDigitButton.Location = new System.Drawing.Point(93, 123);
            this.clearDigitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearDigitButton.Name = "clearDigitButton";
            this.clearDigitButton.Size = new System.Drawing.Size(20, 34);
            this.clearDigitButton.TabIndex = 15;
            this.clearDigitButton.Text = "X";
            this.clearDigitButton.UseVisualStyleBackColor = true;
            this.clearDigitButton.Click += new System.EventHandler(this.clearDigitButton_Click);
            // 
            // writingPanel
            // 
            this.writingPanel.BackColor = System.Drawing.Color.White;
            this.writingPanel.Location = new System.Drawing.Point(53, 123);
            this.writingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.writingPanel.Name = "writingPanel";
            this.writingPanel.Size = new System.Drawing.Size(37, 34);
            this.writingPanel.TabIndex = 14;
            this.writingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.writingPanel_Paint);
            this.writingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.writingPanel_MouseDown);
            this.writingPanel.MouseLeave += new System.EventHandler(this.writingPanel_MouseLeave);
            this.writingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.writingPanel_MouseMove);
            this.writingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.writingPanel_MouseUp);
            // 
            // NeuralNetworkDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 642);
            this.Controls.Add(this.testIndividualDigitGroupBox);
            this.Controls.Add(this.createNetworkGroupBox);
            this.Controls.Add(this.testNetworkGroupBox);
            this.Controls.Add(this.trainNetworkGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(978, 678);
            this.Name = "NeuralNetworkDemoForm";
            this.Text = "Handwritten Digits Neural Network Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NeuralNetworkDemoForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.digitPictureBox)).EndInit();
            this.trainNetworkGroupBox.ResumeLayout(false);
            this.trainNetworkGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfEpochsNumberSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.momentumNumberSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRateNumberSelector)).EndInit();
            this.testNetworkGroupBox.ResumeLayout(false);
            this.testNetworkGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDigitPictureBox)).EndInit();
            this.createNetworkGroupBox.ResumeLayout(false);
            this.createNetworkGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayer3NeuronCountSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayer2NeuronCountSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayer1NeuronCountSelector)).EndInit();
            this.testIndividualDigitGroupBox.ResumeLayout(false);
            this.testIndividualDigitGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox digitPictureBox;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Button trainNetworkButton;
        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox trainNetworkGroupBox;
        private System.Windows.Forms.GroupBox testNetworkGroupBox;
        private System.Windows.Forms.Label exampleLabel;
        private System.Windows.Forms.Label exampleProgressText;
        private System.Windows.Forms.Label epochLabel;
        private System.Windows.Forms.Label epochProgressText;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Label costText;
        private System.Windows.Forms.GroupBox createNetworkGroupBox;
        private System.Windows.Forms.Label hiddenNeuronCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox hiddenLayer1ActivationDropdown;
        private System.Windows.Forms.NumericUpDown hiddenLayer1NeuronCountSelector;
        private System.Windows.Forms.Button createNetworkButton;
        private System.Windows.Forms.Label trainingStatusText;
        private System.Windows.Forms.Label testStatusText;
        private System.Windows.Forms.PictureBox testDigitPictureBox;
        private System.Windows.Forms.NumericUpDown learningRateNumberSelector;
        private System.Windows.Forms.Label momentumLabel;
        private System.Windows.Forms.Label learningRateLabel;
        private System.Windows.Forms.NumericUpDown momentumNumberSelector;
        private System.Windows.Forms.Label numberOfEpochsLabel;
        private System.Windows.Forms.NumericUpDown numberOfEpochsNumberSelector;
        private System.Windows.Forms.CheckBox hiddenLayer2CheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown hiddenLayer3NeuronCountSelector;
        private System.Windows.Forms.ComboBox hiddenLayer3ActivationDropdown;
        private System.Windows.Forms.CheckBox hiddenLayer3CheckBox;
        private System.Windows.Forms.NumericUpDown hiddenLayer2NeuronCountSelector;
        private System.Windows.Forms.ComboBox hiddenLayer2ActivationDropdown;
        private System.Windows.Forms.Label networkTestPerformanceText;
        private System.Windows.Forms.Label result0Text;
        private System.Windows.Forms.Label result0Label;
        private System.Windows.Forms.Label result9Text;
        private System.Windows.Forms.Label result9Label;
        private System.Windows.Forms.Label result4Text;
        private System.Windows.Forms.Label result8Text;
        private System.Windows.Forms.Label result4Label;
        private System.Windows.Forms.Label result8Label;
        private System.Windows.Forms.Label result3Text;
        private System.Windows.Forms.Label result7Text;
        private System.Windows.Forms.Label result3Label;
        private System.Windows.Forms.Label result7Label;
        private System.Windows.Forms.Label result2Text;
        private System.Windows.Forms.Label result6Text;
        private System.Windows.Forms.Label result2Label;
        private System.Windows.Forms.Label result6Label;
        private System.Windows.Forms.Label result1Text;
        private System.Windows.Forms.Label result5Text;
        private System.Windows.Forms.Label result1Label;
        private System.Windows.Forms.Label result5Label;
        private System.Windows.Forms.Label networkAnswerLabel;
        private System.Windows.Forms.GroupBox testIndividualDigitGroupBox;
        private System.Windows.Forms.Panel writingPanel;
        private System.Windows.Forms.Button clearDigitButton;
        private System.Windows.Forms.Button readDrawnDigitButton;
        private System.Windows.Forms.Label writeDigitLabel;
        private System.Windows.Forms.Label answerLabel;
    }
}

