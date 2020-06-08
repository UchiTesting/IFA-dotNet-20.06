using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace _200608_Entry
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

		void OnEntryTextChanged(object sender, TextChangedEventArgs e)
		{
			string oldText = e.OldTextValue;
			string newText = e.NewTextValue;
		}

		void OnEntryCompleted(object sender, EventArgs e)
		{
			string text = ((Entry)sender).Text;
		}
	}
}
