namespace EventServiceApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtransport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StateNumber = c.String(nullable: false, maxLength: 50),
                        DriverFirstName = c.String(nullable: false, maxLength: 50),
                        DriverLastName = c.String(maxLength: 50),
                        DriverRequiredPhoneNumber = c.String(nullable: false, maxLength: 50),
                        DriverAdditionalPhoneNumber = c.String(maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        District = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transports");
        }
    }
}
