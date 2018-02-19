using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; }


        public int Price { get; set; } = 30;
        [DisplayName("Empty?")]
        public bool IsEmpty { get; set; } = true;
        [DisplayName("Motorcycle?")]
        public bool IsMcParkingSpace { get; set; } = false;


        public int TotalIncome { get; set; } = 0;
        public int VisitorCount { get; set; } = 0;
        public TimeSpan AverageTime { get; set; }

        //[ForeignKey("ParkingSpaceId")]
        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
        public virtual ICollection<ParkingSpace> ParkingSpaces { get; set; }
        public int McCountMax { get; set; } = 3;

        public int GarageId { get; set; }
        public virtual Garage Garage { get; set; }


        public ParkingSpace()
        {
            this.ParkedVehicles = new List<ParkedVehicle>();
        }
        public ParkingSpace(int mcSize)
        {
            this.McCountMax = mcSize;
            this.ParkedVehicles = new List<ParkedVehicle>();
        }
        public ParkingSpace(int mcSize, int price)
        {
            this.McCountMax = mcSize;
            this.ParkedVehicles = new List<ParkedVehicle>();
            this.Price = price;
        }
    }
}