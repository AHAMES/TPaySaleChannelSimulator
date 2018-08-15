namespace TPaySaleChannelSimulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Merchants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        country = c.String(),
                        isDown = c.Boolean(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        country = c.String(),
                        isDown = c.Boolean(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleChannels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OperatorID = c.Int(nullable: false),
                        MerchantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SaleChannels");
            DropTable("dbo.Operators");
            DropTable("dbo.Merchants");
        }
    }
}
