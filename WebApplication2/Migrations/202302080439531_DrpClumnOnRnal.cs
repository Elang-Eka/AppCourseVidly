namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrpClumnOnRnal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "DateRented");
            DropColumn("dbo.Rentals", "DateReturned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
        }
    }
}
