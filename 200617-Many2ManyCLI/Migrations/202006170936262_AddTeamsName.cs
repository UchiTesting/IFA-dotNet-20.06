namespace _200617_Many2ManyCLI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamsName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Name");
        }
    }
}
