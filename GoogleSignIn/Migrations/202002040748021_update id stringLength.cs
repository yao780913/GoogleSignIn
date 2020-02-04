namespace GoogleSignIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateidstringLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropPrimaryKey("dbo.Roles");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Roles", "Id", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.Users", "RoleId", c => c.String(maxLength: 36));
            AddPrimaryKey("dbo.Roles", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Users", "RoleId", c => c.String(maxLength: 32));
            AlterColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Roles", "Id", c => c.String(nullable: false, maxLength: 32));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Roles", "Id");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
    }
}
