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

            Models.Garage G1 = new Models.Garage("Garage 2.1", 30, 24);
            G1.Id = 0;
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
        }
    }
}
