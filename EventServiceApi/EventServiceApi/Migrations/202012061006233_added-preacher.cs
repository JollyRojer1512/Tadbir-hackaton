namespace EventServiceApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpreacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preachers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        RequiredPhoneNumber = c.String(nullable: false, maxLength: 50),
                        AdditionalPhoneNumber = c.String(maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        District = c.String(maxLength: 50),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Preachers");
        }
    }
}
