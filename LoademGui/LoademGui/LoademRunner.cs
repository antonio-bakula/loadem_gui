using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoademGui
{
	public class LoademRunner
	{
		public List<string> UrlList { get; set; } = new List<string>();
		public int Clients { get; set; } = 5;
		public int TimeLimitInSeconds { get; set; } = 0;

		public Func<string, int, string?, bool> DataReceived { get; set; } = default!;

		protected CancellationTokenSource CancellationTokenSource { get; set; } = default!;
		protected List<Process> StartedList { get; set; } = new List<Process>();


		public async Task Run()
		{
			CancellationTokenSource = new CancellationTokenSource();

			if (Clients < 1)
			{
				Clients = 1;
			}
			if (Clients > 10)
			{
				Clients = 10;
			}

			var runs = UrlList.Select(u => new LoademStart 
			{ 
				ClientId = UrlList.IndexOf(u), 
				Url = u,
				DataReceived = DataReceived
			});

			var options = new ParallelOptions();
			options.CancellationToken = CancellationTokenSource.Token;
			options.MaxDegreeOfParallelism = 10;

			try
			{
				await Parallel.ForEachAsync(runs, options, async (run, ct) =>
				{
					await RunInstance(run, ct);
					ct.ThrowIfCancellationRequested();
				});
			}
			catch (OperationCanceledException)
			{
				foreach (var process in StartedList)
				{
					process.Kill(true);
					process.WaitForExit(2000);
					process.Close();
				}	
			}
		}

		public void Stop()
		{
			foreach (var process in StartedList)
			{
				// try 3 times to send ctrl+c
				for (int i = 0; i < 3; i++)
				{
					if (SendCtrlC(process))
					{
						break;
					}
				}
			}

			// give the processes some time to exit
			Thread.Sleep(250 * StartedList.Count);

			if (CancellationTokenSource != null)
			{
				CancellationTokenSource.Cancel();
			}
		}

		private bool SendCtrlC(Process process)
		{
			if (AttachConsole((uint)process.Id))
			{
				SetConsoleCtrlHandler(null, true);
				try
				{
					if (!GenerateConsoleCtrlEvent(CTRL_C_EVENT, 0))
					{
						return false;
					}
					process.WaitForExit(500);
				}
				finally
				{
					SetConsoleCtrlHandler(null, false);
					FreeConsole();
				}
				return true;
			}
			return false;
		}

		private async Task RunInstance(LoademStart start, CancellationToken cancellationToken)
		{
			string loademExe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "loadem\\loadem.exe");
			string args = "";
			if (TimeLimitInSeconds > 0)
			{
				args += $"-l {TimeLimitInSeconds} ";
			}
			args += $"{start.Url} {Clients}";

			var psi = new ProcessStartInfo(loademExe, args);
			psi.UseShellExecute = false;
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			psi.RedirectStandardInput = true;
			psi.CreateNoWindow = true;

			var process = new Process();
			process.StartInfo = psi;
			process.OutputDataReceived += start.OutputDataReceived;
			process.ErrorDataReceived += start.ErrorDataReceived;		
			process.Start();
			this.StartedList.Add(process);
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			await process.WaitForExitAsync(cancellationToken);
		}

		internal const int CTRL_C_EVENT = 0;
		[DllImport("kernel32.dll")]
		internal static extern bool GenerateConsoleCtrlEvent(uint dwCtrlEvent, uint dwProcessGroupId);
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool AttachConsole(uint dwProcessId);
		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		internal static extern bool FreeConsole();
		[DllImport("kernel32.dll")]
		static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate? HandlerRoutine, bool Add);
		// Delegate type to be used as the Handler Routine for SCCH
		delegate Boolean ConsoleCtrlDelegate(uint CtrlType);
	}

	public class LoademStart
	{
		public int ClientId { get; set; } = 0;
		public string Url { get; set; } = default!;
		public Func<string, int, string?, bool> DataReceived { get; set; } = default!;

		public void OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			DataReceived(Url, ClientId, e.Data);
		}

		public void ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			DataReceived(Url, ClientId, e.Data);
		}
	}
}
