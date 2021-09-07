using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using _200603_ChatMessenger.Models;
using _200603_ChatMessenger.Views;

namespace _200603_ChatMessenger
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private ChatRoom chat;

		public ChatRoom Chat
		{
			get => chat;
			set
			{
				if (value == chat) return;

				chat = value;
				OnPropertyChanged(nameof(Chat));
			}
		}



		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			Console.WriteLine("Window code" + GetHashCode());
			//DataContext=this;
			chat = new ChatRoom();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			UserConnect uc = new UserConnect(this);
			uc.Owner = this;
			if (uc.ShowDialog() == true)
			{
				chat.CurrentUser = uc.username;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			chat.CurrentUser = "Guest";
		}

		private void BtnSend_Click(object sender, RoutedEventArgs e)
		{
			Console.WriteLine($"{DateTime.Now} Clicked send");
			Chat.AddMessage(TbxMessageInput.Text);
			//TbxChatContent.Text
		}

		private void TbxMessageInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Chat.CurrentMessage.Equals(""))
			{
				BtnSend.IsEnabled = false;
			}
			else
			{
				BtnSend.IsEnabled = true;
			}
		}
	}
}
