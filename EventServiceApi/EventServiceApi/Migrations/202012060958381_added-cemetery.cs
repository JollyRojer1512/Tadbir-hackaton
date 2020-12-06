namespace EventServiceApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcemetery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cemeteries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        RequiredPhoneNumber = c.String(nullable: false, maxLength: 50),
                        AdditionalPhoneNumber = c.String(maxLength: 50),
                        City = c.String(nullable: false),
                        District = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cemeteries");
        }
    }
}
