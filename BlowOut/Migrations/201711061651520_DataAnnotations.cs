namespace BlowOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        clientID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        address = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zip = c.String(),
                        email = c.String(),
                        phone = c.String(),
                    })
                .PrimaryKey(t => t.clientID);
            
            CreateTable(
                "dbo.Instrument",
                c => new
                    {
                        instrumentID = c.Int(nullable: false, identity: true),
                        desc = c.String(),
                        type = c.String(),
                        price = c.Int(nullable: false),
                        clientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.instrumentID)
                .ForeignKey("dbo.Client", t => t.clientID, cascadeDelete: true)
                .Index(t => t.clientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instrument", "clientID", "dbo.Client");
            DropIndex("dbo.Instrument", new[] { "clientID" });
            DropTable("dbo.Instrument");
            DropTable("dbo.Client");
        }
    }
}
