namespace NSMB_Randomiser
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.ofdButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.seedNumericBox = new System.Windows.Forms.NumericUpDown();
            this.seedCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.seedNumericBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdButton
            // 
            this.ofdButton.Location = new System.Drawing.Point(12, 12);
            this.ofdButton.Name = "ofdButton";
            this.ofdButton.Size = new System.Drawing.Size(153, 58);
            this.ofdButton.TabIndex = 1;
            this.ofdButton.Text = "Open overlay9_8.bin";
            this.ofdButton.UseVisualStyleBackColor = true;
            this.ofdButton.Click += new System.EventHandler(this.OpenButtonClicked);
            // 
            // goButton
            // 
            this.goButton.Enabled = false;
            this.goButton.Location = new System.Drawing.Point(318, 12);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(146, 58);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButtonClicked);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(2, 74);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(469, 13);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "The randomized file will be dumped inside the \"Out\" folder in the directory the p" +
    "rogram is located in";
            // 
            // seedNumericBox
            // 
            this.seedNumericBox.Enabled = false;
            this.seedNumericBox.Location = new System.Drawing.Point(171, 48);
            this.seedNumericBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.seedNumericBox.Name = "seedNumericBox";
            this.seedNumericBox.Size = new System.Drawing.Size(141, 20);
            this.seedNumericBox.TabIndex = 7;
            // 
            // seedCheckBox
            // 
            this.seedCheckBox.AutoSize = true;
            this.seedCheckBox.Enabled = false;
            this.seedCheckBox.Location = new System.Drawing.Point(172, 21);
            this.seedCheckBox.Name = "seedCheckBox";
            this.seedCheckBox.Size = new System.Drawing.Size(117, 17);
            this.seedCheckBox.TabIndex = 8;
            this.seedCheckBox.Text = "Use Custom Seed?";
            this.seedCheckBox.UseVisualStyleBackColor = true;
            this.seedCheckBox.CheckedChanged += new System.EventHandler(this.SeedBoxCheckChanged);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 93);
            this.Controls.Add(this.seedCheckBox);
            this.Controls.Add(this.seedNumericBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.ofdButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(489, 132);
            this.MinimumSize = new System.Drawing.Size(489, 132);
            this.Name = "EditorForm";
            this.Text = "NSMB Level Randomizer";
            this.Load += new System.EventHandler(this.EditorFormLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.seedNumericBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ofdButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.NumericUpDown seedNumericBox;
        private System.Windows.Forms.CheckBox seedCheckBox;
    }
}

