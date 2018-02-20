namespace GoaGaraget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkingSpaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        IsMcParkingSpace = c.Boolean(nullable: false),
                        TotalIncome = c.Int(nullable: false),
                        VisitorCount = c.Int(nullable: false),
                        AverageTime = c.Time(nullable: false, precision: 7),
                        McCountMax = c.Int(nullable: false),
                        GarageId = c.Int(nullable: false),
                        ParkingSpace_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Garages", t => t.GarageId, cascadeDelete: true)
                .ForeignKey("dbo.ParkingSpaces", t => t.ParkingSpace_Id)
                .Index(t => t.GarageId)
                .Index(t => t.ParkingSpace_Id);
            
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNumber = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                        Brand = c.String(nullable: false, maxLength: 30),
                        NumberOfWheels = c.Int(nullable: false),
                        CheckinDate = c.DateTime(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        Pin = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        PersonNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParkedVehicleId = c.Int(nullable: false),
                        CheckinAt = c.DateTime(nullable: false),
                        CheckoutAt = c.DateTime(nullable: false),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParkedVehicles", t => t.ParkedVehicleId, cascadeDelete: true)
                .Index(t => t.ParkedVehicleId);
            
            CreateTable(
                "dbo.ParkedVehicleParkingSpaces",
                c => new
                    {
                        ParkedVehicle_Id = c.Int(nullable: false),
                        ParkingSpace_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParkedVehicle_Id, t.ParkingSpace_Id })
                .ForeignKey("dbo.ParkedVehicles", t => t.ParkedVehicle_Id, cascadeDelete: true)
                .ForeignKey("dbo.ParkingSpaces", t => t.ParkingSpace_Id, cascadeDelete: true)
                .Index(t => t.ParkedVehicle_Id)
                .Index(t => t.ParkingSpace_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "ParkedVehicleId", "dbo.ParkedVehicles");
            DropForeignKey("dbo.ParkingSpaces", "ParkingSpace_Id", "dbo.ParkingSpaces");
            DropForeignKey("dbo.ParkedVehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.ParkedVehicleParkingSpaces", "ParkingSpace_Id", "dbo.ParkingSpaces");
            DropForeignKey("dbo.ParkedVehicleParkingSpaces", "ParkedVehicle_Id", "dbo.ParkedVehicles");
            DropForeignKey("dbo.ParkedVehicles", "MemberId", "dbo.Members");
            DropForeignKey("dbo.ParkingSpaces", "GarageId", "dbo.Garages");
            DropIndex("dbo.ParkedVehicleParkingSpaces", new[] { "ParkingSpace_Id" });
            DropIndex("dbo.ParkedVehicleParkingSpaces", new[] { "ParkedVehicle_Id" });
            DropIndex("dbo.Receipts", new[] { "ParkedVehicleId" });
            DropIndex("dbo.ParkedVehicles", new[] { "MemberId" });
            DropIndex("dbo.ParkedVehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.ParkingSpaces", new[] { "ParkingSpace_Id" });
            DropIndex("dbo.ParkingSpaces", new[] { "GarageId" });
            DropTable("dbo.ParkedVehicleParkingSpaces");
            DropTable("dbo.Receipts");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Members");
            DropTable("dbo.ParkedVehicles");
            DropTable("dbo.ParkingSpaces");
            DropTable("dbo.Garages");
        }
    }
}
