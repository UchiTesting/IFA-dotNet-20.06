using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _200617_Many2Many.Models;

namespace _200617_Many2Many.ViewModels
{
	class Tab3VM
	{
		public List<Team>	Teams{ get; set; }
		public List<Player> Players { get; set; }

		public Tab3VM()
		{

		}
	}
}
