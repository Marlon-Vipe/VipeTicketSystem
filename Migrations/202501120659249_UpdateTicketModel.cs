namespace VipeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id_Category = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 50),
                        created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Category);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ticket_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        created_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id_Priority = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id_Priority);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id_Status = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id_Status);
            
            CreateTable(
                "dbo.Ticket_Log",
                c => new
                    {
                        Id_Ticket_Log = c.Int(nullable: false, identity: true),
                        ticket_id = c.Int(nullable: false),
                        changed_by = c.Int(nullable: false),
                        Field = c.String(nullable: false, maxLength: 100),
                        old_value = c.String(),
                        new_value = c.String(),
                        changed_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id_Ticket_Log);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id_Ticket = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        created_by = c.Int(nullable: false),
                        assigned_to = c.Int(),
                        category_id = c.Int(),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                        AssignedToNavigation_Id_User = c.Int(),
                        CategoryIdNavigation_Id_Category = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Ticket)
                .ForeignKey("dbo.Users", t => t.AssignedToNavigation_Id_User)
                .ForeignKey("dbo.Categories", t => t.CategoryIdNavigation_Id_Category)
                .Index(t => t.AssignedToNavigation_Id_User)
                .Index(t => t.CategoryIdNavigation_Id_Category);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id_User = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 255),
                        created_at = c.DateTime(),
                        modify_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id_User);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CategoryIdNavigation_Id_Category", "dbo.Categories");
            DropForeignKey("dbo.Tickets", "AssignedToNavigation_Id_User", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "CategoryIdNavigation_Id_Category" });
            DropIndex("dbo.Tickets", new[] { "AssignedToNavigation_Id_User" });
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Ticket_Log");
            DropTable("dbo.Status");
            DropTable("dbo.Priorities");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
