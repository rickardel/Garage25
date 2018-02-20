using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class StatisticModel
    {
        private ParkedVehicle parkedVehicle;
        private List<ParkedVehicle> parkedVehicles;

        public int Id { get; set; }
        public List<ParkingSpace> FavoriteParkingSpaces { get; set; }
        public int GarageSize { get; set; }
        public float ExpectedIncome { get; set; }
        public int TotalWheelCount { get; set; }

        public StatisticModel(ParkedVehicle parkedVehicle)
        {
            this.parkedVehicle = parkedVehicle;
            this.GarageSize = 269;
            this.ExpectedIncome = 10000000;
            this.TotalWheelCount = 269;
            this.FavoriteParkingSpaces = new List<ParkingSpace>();
        }

        public StatisticModel(List<ParkedVehicle> parkedVehicles)
        {
            this.GarageSize = parkedVehicles.Capacity;
            this.parkedVehicles = parkedVehicles.Where(pv => pv.ParkingSpaces.Count > 0).ToList();

            this.ExpectedIncome = 0;
            this.TotalWheelCount = 0;
            DateTime now = DateTime.Now;
            var actuallyParkedVehicles = parkedVehicles.Where(pv => pv.ParkingSpaces.Count > 0);
            foreach (var pv in actuallyParkedVehicles)
            {
                this.TotalWheelCount += pv.NumberOfWheels;
                this.ExpectedIncome += (float)(now-pv.CheckinDate).TotalHours*pv.Member.Price;
            }
        }
    }
}