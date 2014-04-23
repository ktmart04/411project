namespace TrackYourBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceiptPages",
                c => new
                    {
                        rdiCode = c.Int(nullable: false, identity: true),
                        usercode = c.String(),
                        rciCode = c.String(),
                        dateTimePurchase = c.DateTime(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        Category = c.String(nullable: false),
                        venueName = c.String(nullable: false),
                        amountSpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentType = c.String(nullable: false),
                        descriptioninfo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.rdiCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReceiptPages");
        }
    }
}
