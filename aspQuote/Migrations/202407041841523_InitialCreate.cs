namespace aspQuote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        CarYear = c.Int(nullable: false),
                        CarMake = c.String(nullable: false, maxLength: 50),
                        CarModel = c.String(nullable: false, maxLength: 50),
                        SpeedingTickets = c.Int(nullable: false),
                        HasDUI = c.Boolean(nullable: false),
                        IsFullCoverage = c.Boolean(nullable: false),
                        Quote = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Insurees");
        }
    }
}
