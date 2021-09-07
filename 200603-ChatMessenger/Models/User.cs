using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200603_ChatMessenger.Models
{
	public class User : PropertyChangingClass
	{
		private string username;

		public string Username
		{
			get => username;
			set
			{
				if (value == username) return;

				username = value;
				OnPropertyChanged(nameof(Username));
			}
		}
	}
}
