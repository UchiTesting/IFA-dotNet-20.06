using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _200617_Many2Many.Models;

namespace _200617_Many2Many
{
	class ApplicationContext : DbContext
	{
		public ApplicationContext()
		{

		}

		public DbSet<SportMatch> Matches { get; set; }
		public DbSet<Team> Teams { get;set;}
		public DbSet<Player> Players { get;set;}
		public DbSet<TeamPlayer> TeamsPlayers { get;set;}
	}
}
