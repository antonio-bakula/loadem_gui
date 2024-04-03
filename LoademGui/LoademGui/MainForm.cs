
using System.Reflection;

namespace LoademGui
{
	public partial class MainForm : Form
	{
		public LoademRunner? Runner { get; set; } = null;
		public List<TextBox> LogTextBoxes { get; set; } = new List<TextBox>();

		public MainForm()
		{
			InitializeComponent();

			if (Environment.MachineName == "ABAKULA")
			{
				inputUrls.Lines = new string[]
				{
					"http://dev-default-ut.wem.local/",
					"http://dev-default-ut.wem.local/sokovi",
					"http://dev-default-ut.wem.local/sok-od-narance",
					"http://dev-default-ut.wem.local/koza"
				};
			}

			this.Text = $"Loadem GUI v{GetApplicationVersion()}";
		}

		public string GetApplicationVersion()
		{
			string? version = typeof(MainForm).Assembly
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
				.InformationalVersion.Split('+')
				.First();

			return version ?? "N/A";
		}

		private bool DataReceivedHandler(string url, int clientId, string? data)
		{
			if (data == null)
			{
				return false;
			}

			// ignore certs message
			if (data.StartsWith("Could not load all certificates"))
			{
				return false;
			}

			string logline = data;
			// shorten the log line, ignore P50 and later
			if (logline.Contains(", P50"))
			{
				logline = logline.Substring(0, logline.IndexOf(", P50"));
			}

			var textBox = LogTextBoxes[clientId];
			Invoke(new System.Windows.Forms.MethodInvoker(delegate ()
			{
				textBox.AppendText(logline + Environment.NewLine);
			}));

			return true;
		}

		private async void buttonStart_Click(object sender, EventArgs e)
		{
			foreach (var textBox in LogTextBoxes)
			{
				panelRunnerLogs.Controls.Remove(textBox);
			}
			LogTextBoxes.Clear();

			var urls = inputUrls.Lines.Where(l => !string.IsNullOrEmpty(l)).ToList();

			if (urls.Count > 10)
			{
				MessageBox.Show("Maximum of 10 URLs allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			var fontSizeDict = new Dictionary<int, float>
			{
				{ 1, 10f },
				{ 2, 9f },
				{ 3, 9f },
				{ 4, 8f },
				{ 5, 8f },
				{ 6, 7f },
				{ 7, 7f },
				{ 8, 6f },
				{ 9, 6f },
				{ 10, 6f }
			};

			foreach (var url in urls)
			{
				var tb = new TextBox();
				tb.Font = new Font("Segoe UI", fontSizeDict[urls.Count]);
				tb.Multiline = true;
				tb.Dock = DockStyle.Left;
				tb.Width = panelRunnerLogs.ClientRectangle.Width / urls.Count;
				tb.ReadOnly = true;
				panelRunnerLogs.Controls.Add(tb);
				LogTextBoxes.Add(tb);
			}

			try
			{
				buttonStart.Enabled = false;
				buttonStop.Enabled = true;
				Runner = new LoademRunner();
				Runner.TimeLimitInSeconds = (int)inputTimeLimit.Value;
				Runner.Clients = (int)inputClients.Value;
				Runner.UrlList = urls;
				Runner.DataReceived = DataReceivedHandler;
				await Runner.Run();
			}
			finally
			{
				buttonStart.Enabled = true;
				buttonStop.Enabled = false;
				Runner = null;
			}
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			if (Runner != null)
			{
				Runner.Stop();
			}
			buttonStart.Enabled = true;
			buttonStop.Enabled = false;
		}

		private void panelRunnerLogs_SizeChanged(object sender, EventArgs e)
		{
			foreach (var tb in LogTextBoxes)
			{
				tb.Width = panelRunnerLogs.ClientRectangle.Width / LogTextBoxes.Count;
			}
		}
	}
}
