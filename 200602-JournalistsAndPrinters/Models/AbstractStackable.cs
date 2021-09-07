using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _200602_JournalistsAndPrinters.Enums;

namespace _200602_JournalistsAndPrinters.Models
{
	public abstract class AbstractStackable : INotifyPropertyChanged
	{
		private string _name;
		private StateEnum _state;
		private bool _paused;

		public string Name
		{
			get => _name;
			set
			{
				if (value == _name) return;

				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
		public StateEnum State
		{
			get => _state;
			set
			{
				if (value == _state) return;

				_state = value;
				OnPropertyChanged(nameof(State));
			}
		}
		public bool Paused
		{
			get => _paused;
			set
			{
				if (value == _paused) return;

				_paused = value;
				OnPropertyChanged(nameof(Paused));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
