using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200617_Many2Many.Models
{
	public class TeamPlayer
	{
		public TeamPlayer() { }

		[Key]
		[Column(Order = 0)]
		public int TeamId { get; set; }
		[ForeignKey("TeamId")]
		virtual public Team Team { get; set; }

		[Key]
		[Column(Order = 1)]
		public int PlayerId { get; set; }
		[ForeignKey("PlayerId")]
		virtual public Player Player { get; set; }

		[Key]
		[Column(Order = 2)]
		public DateTime ContractDate { get; set; }
	}
}
