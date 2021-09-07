using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _200617_Many2Many.Models
{
	public class Team
	{
		public Team() { }

		public int Id { get; set; }
		public List<SportMatch> Matches { get; set; }
		public List<Player> Players { get; set; }
	}
}
