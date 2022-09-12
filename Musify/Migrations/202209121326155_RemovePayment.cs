namespace Musify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePayment : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Transactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TRANSACTION_ID = c.Guid(nullable: false, identity: true),
                        DATE = c.DateTime(),
                        PAY_REQUEST_ID = c.String(),
                        AMOUNT = c.Int(nullable: false),
                        REFERENCE = c.String(),
                        TRANSACTION_STATUS = c.String(),
                        RESULT_CODE = c.Int(nullable: false),
                        RESULT_DESC = c.String(),
                        CUSTOMER_EMAIL_ADDRESS = c.String(),
                    })
                .PrimaryKey(t => t.TRANSACTION_ID);
            
        }
    }
}
