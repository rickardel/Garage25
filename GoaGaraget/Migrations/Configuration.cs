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
            Models.VehicleType vt2 = new Models.VehicleType(2, "Motorcycle", 2);
            Models.VehicleType vt3 = new Models.VehicleType(3, "Lorry", 3);
            Models.VehicleType vt4 = new Models.VehicleType(4, "Truck", 5);


            Models.Member M1 = new Models.Member(1, "Kalle", "Svensson", 1234, "010101-1234");
            Models.Member M2 = new Models.Member(2, "Peter", "Stalefäldt", 1234, "990101-1234");
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
            Models.ParkedVehicle pv1 = new Models.ParkedVehicle(1, "ABC123", "röd", vt3, "Volvo", 4, DateTime.Now);
            Models.ParkedVehicle pv2 = new Models.ParkedVehicle(2, "ABC124", "blue", vt1, "Lancia", 4, DateTime.Now);
            Models.ParkedVehicle pv3 = new Models.ParkedVehicle(2, "ABC125", "grön", vt4, "Scanida", 4, DateTime.Now);
            context.ParkedVehicles.AddOrUpdate(pv1);
            context.ParkedVehicles.AddOrUpdate(pv2);
            context.ParkedVehicles.AddOrUpdate(pv3);

        }
    }
}
