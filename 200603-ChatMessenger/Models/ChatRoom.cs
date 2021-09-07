using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200603_ChatMessenger.Models
{
	public class ChatRoom : PropertyChangingClass
	{
		#region Private Members and Properties

		private string currentUser;
		private ObservableCollection<User> connectedUsers;
		private StringBuilder builtMessages;
		private string messages;
		private ObservableCollection<string> msgs;
		private string currentMessage;


		public ObservableCollection<string> Msgs
		{
			get => msgs;
			set
			{
				if (value == msgs) return;

				msgs = value;
				OnPropertyChanged(nameof(Msgs));
			}
		}

		public string CurrentUser
		{
			get => currentUser;
			set
			{
				if (value == currentUser) return;

				currentUser = value;
				OnPropertyChanged(nameof(CurrentUser));
			}
		}

		public StringBuilder BuiltMessages
		{
			get => builtMessages;
			set
			{
				if (value == builtMessages) return;

				builtMessages = value;
				Console.WriteLine($"{DateTime.Now} Built Messages changed");
				OnPropertyChanged(nameof(Messages));
			}
		}

		public string Messages
		{
			get
			{
				return builtMessages.ToString();
			}
			set
			{
				if (value == Messages) return;

				messages = value;
				Console.WriteLine($"{DateTime.Now} Messages changed");
				OnPropertyChanged(nameof(Messages));
			}
		}


		public ObservableCollection<User> ConnectedUsers
		{
			get => connectedUsers;
			set
			{
				if (value == connectedUsers) return;

				connectedUsers = value;
				OnPropertyChanged(nameof(ConnectedUsers));
			}
		}

		public string CurrentMessage
		{
			get => currentMessage;
			set
			{
				if (value == currentMessage) return;

				currentMessage = value;
				Console.WriteLine($"{DateTime.Now} Current message changed");
				OnPropertyChanged(nameof(CurrentMessage));
			}
		}
		#endregion

		public ChatRoom()
		{
			ConnectedUsers = new ObservableCollection<User>();
			BuiltMessages = new StringBuilder();
			Msgs = new ObservableCollection<string>();
		}

		public void AddMessage(string msg)
		{
			Console.WriteLine($"{DateTime.Now} Add Message called with {msg}");
			//BuiltMessages.AppendLine(msg);
			Msgs.Add(msg);
			Console.WriteLine($"{DateTime.Now} BMsg: {BuiltMessages.ToString()}{Environment.NewLine}Msg: {Messages}");
		}
	}
}
