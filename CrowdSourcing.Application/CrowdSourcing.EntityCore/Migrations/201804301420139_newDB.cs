namespace CrowdSourcing.EntityCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solution", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Solution", "Rating");
        }
    }
}
