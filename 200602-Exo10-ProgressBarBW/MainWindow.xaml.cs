using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _200602_Exo10_ProgressBarBW
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static BackgroundWorker worker;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void BtnStartCalc_Click(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("Clicked Start Calc");
			PbComputation.Value = 0;
			LblResults.Content = "";

			worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.WorkerSupportsCancellation = true;

			worker.DoWork += worker_DoWork;
			worker.ProgressChanged += worker_ProgressChanged;
			worker.RunWorkerCompleted += worker_RunWorkerCompleted;
			worker.RunWorkerAsync(100000);
		}

		private void BtnStopCalc_Click(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("Clicked Stop Calc");
			worker?.CancelAsync();
		}

		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			int max = (int)e.Argument;
			Console.WriteLine($"MAX: {max}");
			int result = 0;
			int i = 0;

			while (i < max && !worker.CancellationPending)
			{
				i++;

				int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
				(sender as BackgroundWorker).ReportProgress(progressPercentage, i);
				Thread.Sleep(1);
			}
			e.Result = result;
		}

		void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			PbComputation.Value = (double)e.ProgressPercentage;
			if (e.UserState != null)
				LblResults.Content = e.UserState;
		}

		void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Result != null)
			MessageBox.Show("Computation complete: " + e.Result);
		}
	}
}
