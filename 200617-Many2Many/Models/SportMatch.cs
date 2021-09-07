using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200617_Many2Many.Models
{
	public class SportMatch
	{
		public SportMatch() { }

		public int Id { get; set; }
		public List<Team> Teams { get; set; }
		public int ScoreTeam1 { get; set; }
		public int ScoreTeam2 { get; set; }
		public DateTime Date { get; set; }

	}
}
