namespace GoaGaraget.Migrations
{
    using GoaGaraget.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoaGaraget.DataAccessLayer.GarageDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GoaGaraget.DataAccessLayer.GarageDbContext context)
        {
            List<ParkingSpace> pss = new List<ParkingSpace>();

            Models.VehicleType vt1 = new Models.VehicleType(1, "Car", 1);
            Models.VehicleType vt2 = new Models.VehicleType(2, "Motorcycle", 1);
            Models.VehicleType vt3 = new Models.VehicleType(3, "Lorry", 3);
            Models.VehicleType vt4 = new Models.VehicleType(4, "Truck", 5);
            context.VehicleTypes.AddOrUpdate(vt1);
            context.VehicleTypes.AddOrUpdate(vt2);
            context.VehicleTypes.AddOrUpdate(vt3);
            context.VehicleTypes.AddOrUpdate(vt4);

            Models.Member M1 = new Models.Member(1, "Kalle", "Svensson", 1234, 20, "010101-1234");
            Models.Member M2 = new Models.Member(2, "Peter", "Stalef�ldt", 1234, 20, "990101-1234");
            context.Members.AddOrUpdate(M1);
            context.Members.AddOrUpdate(M2);

            Models.Garage G1 = new Models.Garage("Garage 2.1", 30, 24);
            G1.Id = 0;
            context.Garages.AddOrUpdate(G1);

            for (int i = 0; i < 30; i++)
            {
                ParkingSpace ps = new ParkingSpace
                {
                    Id = i,
                    Price = 35,
                    IsEmpty = true,
                    IsMcParkingSpace = false,
                    ParkedVehicles = new List<ParkedVehicle>(),
                    McCountMax = 3,
                    TotalIncome = 0,
                    VisitorCount = 0,
                    AverageTime = new TimeSpan(0, 0, 0),
                    Garage = G1
                };
                context.ParkingSpaces.AddOrUpdate(ps);
                pss.Add(ps);
            }
            Models.ParkedVehicle pv1 = new Models.ParkedVehicle(M1, "ABC123", "r�d", vt3, "Volvo", 4, DateTime.Now);
            Models.ParkedVehicle pv2 = new Models.ParkedVehicle(M2, "ABC124", "blue", vt1, "Lancia", 4, DateTime.Now);
            Models.ParkedVehicle pv3 = new Models.ParkedVehicle(M2, "ABC125", "gr�n", vt4, "Tesla", 8, DateTime.Now);
            Models.ParkedVehicle pv4 = new Models.ParkedVehicle(M1, "ABC623", "r�d", vt3, "Renault", 4, DateTime.Now);
            Models.ParkedVehicle pv5 = new Models.ParkedVehicle(M1, "ABf124", "blue", vt1, "Lancia", 4, DateTime.Now);
            Models.ParkedVehicle pv6 = new Models.ParkedVehicle(M2, "ABs125", "gr�n", vt4, "Mitsubishi", 8, DateTime.Now);
            Models.ParkedVehicle pv7 = new Models.ParkedVehicle(M2, "ABj143", "r�d", vt3, "Fiat", 6, DateTime.Now);
            Models.ParkedVehicle pv8 = new Models.ParkedVehicle(M1, "gfC194", "blue", vt1, "Lancia", 4, DateTime.Now);
            Models.ParkedVehicle pv9 = new Models.ParkedVehicle(M1, "tyC625", "Gr�", vt2, "Yamaha CBR", 2, DateTime.Now);
            Models.ParkedVehicle pv10 = new Models.ParkedVehicle(M1, "tyC624", "Gr�", vt2, "Suzuki", 2, DateTime.Now);
            Models.ParkedVehicle pv11 = new Models.ParkedVehicle(M1, "tyC627", "Gr�", vt2, "Honda Lead", 2, DateTime.Now);
            Models.ParkedVehicle pv12 = new Models.ParkedVehicle(M1, "tyC620", "Gr�", vt2, "Bmw 15000", 2, DateTime.Now);
            Models.ParkedVehicle pv13 = new Models.ParkedVehicle(M1, "tyC621", "Gr�", vt2, "Hyundai", 2, DateTime.Now);
            pv1.Id = 1;pv2.Id = 2;pv3.Id = 3;pv4.Id = 4;pv5.Id = 5;
            pv6.Id = 6;pv7.Id = 7;pv8.Id = 8; pv9.Id = 9; ; pv9.Id = 10; ; pv9.Id = 11; ; pv9.Id = 12; ; pv9.Id = 13;
            context.ParkedVehicles.AddOrUpdate(pv1);
            context.ParkedVehicles.AddOrUpdate(pv2);
            context.ParkedVehicles.AddOrUpdate(pv3);
            context.ParkedVehicles.AddOrUpdate(pv4);
            context.ParkedVehicles.AddOrUpdate(pv5);
            context.ParkedVehicles.AddOrUpdate(pv6);
            context.ParkedVehicles.AddOrUpdate(pv7);
            context.ParkedVehicles.AddOrUpdate(pv8);
            context.ParkedVehicles.AddOrUpdate(pv9);
            context.ParkedVehicles.AddOrUpdate(pv10);
            context.ParkedVehicles.AddOrUpdate(pv11);
            context.ParkedVehicles.AddOrUpdate(pv12);
            context.ParkedVehicles.AddOrUpdate(pv13);
        }
    }
}
