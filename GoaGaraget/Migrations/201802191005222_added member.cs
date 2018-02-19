namespace GoaGaraget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        Pin = c.Int(nullable: false),
                        PersonNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ParkedVehicles", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParkedVehicles", "MemberId");
            AddForeignKey("dbo.ParkedVehicles", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", new[] { "MemberId" });
            DropColumn("dbo.ParkedVehicles", "MemberId");
            DropTable("dbo.Members");
        }
    }
}
