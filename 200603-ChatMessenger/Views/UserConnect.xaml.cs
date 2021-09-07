using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _200603_ChatMessenger.Views
{
	/// <summary>
	/// Interaction logic for UserConnect.xaml
	/// </summary>
	public partial class UserConnect : Window
	{
		MainWindow mw;
		public string username;

		public UserConnect(MainWindow mw)
		{
			this.mw = mw;
			InitializeComponent();
		}

		private void BtnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnOK_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			username = TbxUserName.Text;
			this.Close();
		}

		private void TbxUserName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (TbxUserName.Text.Length < 1)
			{
				BtnOK.IsEnabled = false;
			}
			else
			{
				BtnOK.IsEnabled = true;
			}
		}
	}
}
