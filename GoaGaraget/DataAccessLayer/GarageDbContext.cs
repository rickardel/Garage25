using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoaGaraget.DataAccessLayer
{
    public class GarageDbContext : DbContext
    {
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<Models.ParkingSpace> ParkingSpaces { get; set; }
        //public DbSet<Models.ParkingModel> ParkingModels { get; set; }
        public DbSet<Models.Receipt> Receipts { get; set; }
        public DbSet<Models.Garage> Garages { get; set; }

        public System.Data.Entity.DbSet<GoaGaraget.Models.Member> Members { get; set; }
        public System.Data.Entity.DbSet<GoaGaraget.Models.VehicleType> VehicleTypes { get; set; }

    }
}