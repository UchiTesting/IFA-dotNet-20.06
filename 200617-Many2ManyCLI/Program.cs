using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _200617_Many2Many;
using _200617_Many2Many.Models;

namespace _200617_Many2ManyCLI
{
	class Program
	{
		static void Main(string[] args)
		{
			//ExecuteSeeds();

			ApplicationContext db = new ApplicationContext();

			//Voir la liste des joueurs de la team1 avec leur date
			var query1 = from t in db.Teams
							 where t.Id==1
							 select t; 
			// Voir la liste des team auxquelles un joueur à appartenu
			var query2 = from p in db.Players
							 where p.Id==1
							 select p;

		}

		private static void ExecuteSeeds()
		{
			SeedTeams();
			SeedPlayers();
			SeedTeamsPlayers();
		}

		private static void SeedTeamsPlayers()
		{
			// Team player date
			EngageWithTeam(1, 1, new DateTime(2020, 01, 01));
			EngageWithTeam(1, 3, new DateTime(2020, 01, 01));
			EngageWithTeam(1, 5, new DateTime(2020, 01, 01));

			EngageWithTeam(2,2,new DateTime(2020,01,01));
			EngageWithTeam(2,4,new DateTime(2020,01,01));

			EngageWithTeam(2,3,new DateTime(2020,03,01));
			EngageWithTeam(2,1,new DateTime(2020,03,01));
			EngageWithTeam(1,2,new DateTime(2020,03,01));
		}

		private static void SeedPlayers()
		{
			CreatePlayer("Player1");
			CreatePlayer("Player2");
			CreatePlayer("Player3");
			CreatePlayer("Player4");
			CreatePlayer("Player5");
		}

		private static void SeedTeams()
		{
			CreateTeam("Team1");
			CreateTeam("Team2");
			CreateTeam("Team3");
		}

		private static void CreateTeam(string teamName)
		{
			Team tmp = new Team { Name = teamName };
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Teams.Add(tmp);
				db.SaveChanges();
			}
		}

		private static void CreatePlayer(string playerName)
		{
			Player tmp = new Player { Name = playerName };
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Players.Add(tmp);
				db.SaveChanges();
			}
		}

		private static void EngageWithTeam(int teamId, int playerId, DateTime contractDate)
		{
			TeamPlayer tmp = new TeamPlayer { TeamId=teamId, PlayerId=playerId,ContractDate=contractDate};
			using (ApplicationContext db = new ApplicationContext())
			{
				db.TeamsPlayers.Add(tmp);
				db.SaveChanges();
			}
		}
	}
}
