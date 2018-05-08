namespace CrowdSourcing.EntityCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.String(nullable: false, maxLength: 128),
                        PersonRoleId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        UploadTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        PersonRoleEntity_UserId = c.String(maxLength: 128),
                        PersonRoleEntity_RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonRole", t => new { t.PersonRoleEntity_UserId, t.PersonRoleEntity_RoleId })
                .ForeignKey("dbo.PersonRole", t => new { t.PersonId, t.PersonRoleId }, cascadeDelete: true)
                .Index(t => new { t.PersonId, t.PersonRoleId })
                .Index(t => new { t.PersonRoleEntity_UserId, t.PersonRoleEntity_RoleId });
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileTypeId = c.Int(nullable: false),
                        DataId = c.Int(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data", t => t.DataId, cascadeDelete: true)
                .ForeignKey("dbo.FileType", t => t.FileTypeId, cascadeDelete: true)
                .Index(t => t.FileTypeId)
                .Index(t => t.DataId);
            
            CreateTable(
                "dbo.FileType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        DataId = c.Int(nullable: false),
                        FinishDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data", t => t.DataId, cascadeDelete: true)
                .ForeignKey("dbo.Task", t => t.TaskId)
                .Index(t => t.TaskId)
                .Index(t => t.DataId);
            
            CreateTable(
                "dbo.Solution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminId = c.String(nullable: false, maxLength: 128),
                        AdminRoleId = c.String(nullable: false, maxLength: 128),
                        ExpertId = c.String(nullable: false, maxLength: 128),
                        ExpertRoleId = c.String(nullable: false, maxLength: 128),
                        SolutionReviewId = c.Int(),
                        TaskDataId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        SolutionDate = c.DateTime(),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        PersonRoleEntity_UserId = c.String(maxLength: 128),
                        PersonRoleEntity_RoleId = c.String(maxLength: 128),
                        PersonRoleEntity_UserId1 = c.String(maxLength: 128),
                        PersonRoleEntity_RoleId1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonRole", t => new { t.PersonRoleEntity_UserId, t.PersonRoleEntity_RoleId })
                .ForeignKey("dbo.PersonRole", t => new { t.PersonRoleEntity_UserId1, t.PersonRoleEntity_RoleId1 })
                .ForeignKey("dbo.PersonRole", t => new { t.AdminId, t.AdminRoleId })
                .ForeignKey("dbo.PersonRole", t => new { t.ExpertId, t.ExpertRoleId })
                .ForeignKey("dbo.Solution", t => t.SolutionReviewId)
                .ForeignKey("dbo.TaskData", t => t.TaskDataId, cascadeDelete: true)
                .Index(t => new { t.AdminId, t.AdminRoleId })
                .Index(t => new { t.ExpertId, t.ExpertRoleId })
                .Index(t => t.SolutionReviewId)
                .Index(t => t.TaskDataId)
                .Index(t => new { t.PersonRoleEntity_UserId, t.PersonRoleEntity_RoleId })
                .Index(t => new { t.PersonRoleEntity_UserId1, t.PersonRoleEntity_RoleId1 });
            
            CreateTable(
                "dbo.PersonRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Person_Id = c.String(maxLength: 128),
                        Role_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Person", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_Id)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.Person_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        PersonEntity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonEntity_Id)
                .Index(t => t.PersonEntity_Id);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        PersonEntity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Person", t => t.PersonEntity_Id)
                .Index(t => t.PersonEntity_Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TaskTypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskType", t => t.TaskTypeId, cascadeDelete: true)
                .Index(t => t.TaskTypeId);
            
            CreateTable(
                "dbo.TaskType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Data", new[] { "PersonId", "PersonRoleId" }, "dbo.PersonRole");
            DropForeignKey("dbo.TaskData", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Task", "TaskTypeId", "dbo.TaskType");
            DropForeignKey("dbo.Solution", "TaskDataId", "dbo.TaskData");
            DropForeignKey("dbo.Solution", "SolutionReviewId", "dbo.Solution");
            DropForeignKey("dbo.Solution", new[] { "ExpertId", "ExpertRoleId" }, "dbo.PersonRole");
            DropForeignKey("dbo.Solution", new[] { "AdminId", "AdminRoleId" }, "dbo.PersonRole");
            DropForeignKey("dbo.Solution", new[] { "PersonRoleEntity_UserId1", "PersonRoleEntity_RoleId1" }, "dbo.PersonRole");
            DropForeignKey("dbo.PersonRole", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.PersonRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Solution", new[] { "PersonRoleEntity_UserId", "PersonRoleEntity_RoleId" }, "dbo.PersonRole");
            DropForeignKey("dbo.PersonRole", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.PersonRole", "UserId", "dbo.Person");
            DropForeignKey("dbo.Login", "PersonEntity_Id", "dbo.Person");
            DropForeignKey("dbo.IdentityUserClaims", "PersonEntity_Id", "dbo.Person");
            DropForeignKey("dbo.Data", new[] { "PersonRoleEntity_UserId", "PersonRoleEntity_RoleId" }, "dbo.PersonRole");
            DropForeignKey("dbo.TaskData", "DataId", "dbo.Data");
            DropForeignKey("dbo.File", "FileTypeId", "dbo.FileType");
            DropForeignKey("dbo.File", "DataId", "dbo.Data");
            DropIndex("dbo.Task", new[] { "TaskTypeId" });
            DropIndex("dbo.Login", new[] { "PersonEntity_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "PersonEntity_Id" });
            DropIndex("dbo.PersonRole", new[] { "Role_Id" });
            DropIndex("dbo.PersonRole", new[] { "Person_Id" });
            DropIndex("dbo.PersonRole", new[] { "RoleId" });
            DropIndex("dbo.PersonRole", new[] { "UserId" });
            DropIndex("dbo.Solution", new[] { "PersonRoleEntity_UserId1", "PersonRoleEntity_RoleId1" });
            DropIndex("dbo.Solution", new[] { "PersonRoleEntity_UserId", "PersonRoleEntity_RoleId" });
            DropIndex("dbo.Solution", new[] { "TaskDataId" });
            DropIndex("dbo.Solution", new[] { "SolutionReviewId" });
            DropIndex("dbo.Solution", new[] { "ExpertId", "ExpertRoleId" });
            DropIndex("dbo.Solution", new[] { "AdminId", "AdminRoleId" });
            DropIndex("dbo.TaskData", new[] { "DataId" });
            DropIndex("dbo.TaskData", new[] { "TaskId" });
            DropIndex("dbo.File", new[] { "DataId" });
            DropIndex("dbo.File", new[] { "FileTypeId" });
            DropIndex("dbo.Data", new[] { "PersonRoleEntity_UserId", "PersonRoleEntity_RoleId" });
            DropIndex("dbo.Data", new[] { "PersonId", "PersonRoleId" });
            DropTable("dbo.TaskType");
            DropTable("dbo.Task");
            DropTable("dbo.Role");
            DropTable("dbo.Login");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Person");
            DropTable("dbo.PersonRole");
            DropTable("dbo.Solution");
            DropTable("dbo.TaskData");
            DropTable("dbo.FileType");
            DropTable("dbo.File");
            DropTable("dbo.Data");
        }
    }
}
