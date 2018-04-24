namespace CrowdSourcing.EntityCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "Name");
        }
    }
}
