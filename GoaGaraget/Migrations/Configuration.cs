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

            Models.Member M1 = new Models.Member(1, "Kalle", "Svensson", 1234, "0101011234");
            Models.Member M2 = new Models.Member(2, "Peter", "Stalefäldt", 1234, "9901011234");
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
            Models.ParkedVehicle pv1 = new Models.ParkedVehicle(1, "ABC123", 3, "röd", VehicleType.Lorry, "Volvo", 4, DateTime.Now);
            Models.ParkedVehicle pv2 = new Models.ParkedVehicle(2, "ABC124", 1, "blue", VehicleType.Car, "Lancia", 4, DateTime.Now);
            Models.ParkedVehicle pv3 = new Models.ParkedVehicle(1, "ABC125", 5, "grön", VehicleType.Truck, "Scanida", 4, DateTime.Now);
            context.ParkedVehicles.AddOrUpdate(pv1);
            context.ParkedVehicles.AddOrUpdate(pv2);
            context.ParkedVehicles.AddOrUpdate(pv3);

        }
    }
}
