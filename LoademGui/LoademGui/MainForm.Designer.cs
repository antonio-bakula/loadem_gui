namespace LoademGui
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelInputParams = new Panel();
			this.buttonStop = new Button();
			this.buttonStart = new Button();
			this.label3 = new Label();
			this.inputTimeLimit = new NumericUpDown();
			this.label2 = new Label();
			this.inputClients = new NumericUpDown();
			this.label1 = new Label();
			this.inputUrls = new TextBox();
			this.panel2 = new Panel();
			this.panelRunnerLogs = new Panel();
			this.panelInputParams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.inputTimeLimit).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.inputClients).BeginInit();
			SuspendLayout();
			// 
			// panelInputParams
			// 
			this.panelInputParams.Controls.Add(this.buttonStop);
			this.panelInputParams.Controls.Add(this.buttonStart);
			this.panelInputParams.Controls.Add(this.label3);
			this.panelInputParams.Controls.Add(this.inputTimeLimit);
			this.panelInputParams.Controls.Add(this.label2);
			this.panelInputParams.Controls.Add(this.inputClients);
			this.panelInputParams.Controls.Add(this.label1);
			this.panelInputParams.Controls.Add(this.inputUrls);
			this.panelInputParams.Dock = DockStyle.Top;
			this.panelInputParams.Location = new Point(0, 0);
			this.panelInputParams.Name = "panelInputParams";
			this.panelInputParams.Size = new Size(730, 189);
			this.panelInputParams.TabIndex = 0;
			// 
			// buttonStop
			// 
			this.buttonStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new Point(562, 160);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new Size(75, 23);
			this.buttonStop.TabIndex = 7;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += buttonStop_Click;
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.buttonStart.Location = new Point(643, 160);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new Size(75, 23);
			this.buttonStart.TabIndex = 6;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += buttonStart_Click;
			// 
			// label3
			// 
			this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(562, 56);
			this.label3.Name = "label3";
			this.label3.Size = new Size(156, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "Time limit (seconds,0: none)";
			// 
			// inputTimeLimit
			// 
			this.inputTimeLimit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.inputTimeLimit.Location = new Point(562, 80);
			this.inputTimeLimit.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
			this.inputTimeLimit.Name = "inputTimeLimit";
			this.inputTimeLimit.Size = new Size(89, 23);
			this.inputTimeLimit.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(562, 5);
			this.label2.Name = "label2";
			this.label2.Size = new Size(43, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Clients";
			// 
			// inputClients
			// 
			this.inputClients.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.inputClients.Location = new Point(562, 26);
			this.inputClients.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			this.inputClients.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.inputClients.Name = "inputClients";
			this.inputClients.Size = new Size(89, 23);
			this.inputClients.TabIndex = 2;
			this.inputClients.Value = new decimal(new int[] { 5, 0, 0, 0 });
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new Size(87, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Load test URL's";
			// 
			// inputUrls
			// 
			this.inputUrls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.inputUrls.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
			this.inputUrls.Location = new Point(3, 26);
			this.inputUrls.Multiline = true;
			this.inputUrls.Name = "inputUrls";
			this.inputUrls.Size = new Size(547, 157);
			this.inputUrls.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Dock = DockStyle.Bottom;
			this.panel2.Location = new Point(0, 454);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(730, 19);
			this.panel2.TabIndex = 1;
			// 
			// panelRunnerLogs
			// 
			this.panelRunnerLogs.Dock = DockStyle.Fill;
			this.panelRunnerLogs.Location = new Point(0, 189);
			this.panelRunnerLogs.Name = "panelRunnerLogs";
			this.panelRunnerLogs.Size = new Size(730, 265);
			this.panelRunnerLogs.TabIndex = 2;
			this.panelRunnerLogs.SizeChanged += panelRunnerLogs_SizeChanged;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(730, 473);
			this.Controls.Add(this.panelRunnerLogs);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panelInputParams);
			this.Margin = new Padding(2);
			this.Name = "MainForm";
			this.Text = "Load Test - Loadem GUI";
			this.panelInputParams.ResumeLayout(false);
			this.panelInputParams.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.inputTimeLimit).EndInit();
			((System.ComponentModel.ISupportInitialize)this.inputClients).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panelInputParams;
		private Label label1;
		private TextBox inputUrls;
		private Panel panel2;
		private Panel panelRunnerLogs;
		private Label label3;
		private NumericUpDown inputTimeLimit;
		private Label label2;
		private NumericUpDown inputClients;
		private Button buttonStop;
		private Button buttonStart;
	}
}
