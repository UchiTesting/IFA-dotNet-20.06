namespace _200617_Many2ManyCLI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SportMatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScoreTeam1 = c.Int(nullable: false),
                        ScoreTeam2 = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.TeamPlayers",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        ContractDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamId, t.PlayerId, t.ContractDate })
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.TeamSportMatches",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        SportMatch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.SportMatch_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.SportMatches", t => t.SportMatch_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.SportMatch_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamPlayers", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.TeamPlayers", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamSportMatches", "SportMatch_Id", "dbo.SportMatches");
            DropForeignKey("dbo.TeamSportMatches", "Team_Id", "dbo.Teams");
            DropIndex("dbo.TeamSportMatches", new[] { "SportMatch_Id" });
            DropIndex("dbo.TeamSportMatches", new[] { "Team_Id" });
            DropIndex("dbo.TeamPlayers", new[] { "PlayerId" });
            DropIndex("dbo.TeamPlayers", new[] { "TeamId" });
            DropIndex("dbo.Players", new[] { "Team_Id" });
            DropTable("dbo.TeamSportMatches");
            DropTable("dbo.TeamPlayers");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.SportMatches");
        }
    }
}
