using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EditorTutorial
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		void OnEditorTextChanged(object sender, TextChangedEventArgs e)
		{
			string oldText = e.OldTextValue;
			string newText = e.NewTextValue;
			Console.WriteLine(logOutput("Text Changed."));
		}

		void OnEditorCompleted(object sender, EventArgs e)
		{
			string text = ((Editor)sender).Text;
			Console.WriteLine(logOutput("Text Completed."));
		}

		static string logOutput(string msg)
		{
			return $"{DateTime.Now}: {msg}";
		}
	}
}
