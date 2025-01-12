using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace VipeSystem.Models
{
    public partial class UpdateTicketModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "AssignedTo", c => c.Int(nullable: true));
            AddColumn("dbo.Tickets", "CategoryId", c => c.Int(nullable: true));
            // Otros cambios
        }

        public override void Down()
        {
            DropColumn("dbo.Tickets", "AssignedTo");
            DropColumn("dbo.Tickets", "CategoryId");
            // Otros cambios
        }
    }

}