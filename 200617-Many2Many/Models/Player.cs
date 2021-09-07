using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200617_Many2Many.Models
{
	public class Player
	{
		public Player() { }

		public int Id { get; set; }
		public string Name { get; set; }
		public List<DateTime> Goals { get; set; }
	}
}
