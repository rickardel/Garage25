using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoaGaraget.Models
{
    public class ParkingModel
    {
        public int Id { get; set; }
        
public int ParkedVehicleId { get; set; }
        public virtual ParkedVehicle ParkedVehicle { get; set; }
        public int ParkingSpaceId { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
        
        public List<ParkingSpace> AvailableParkingSpaces { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public ParkingModel()
        {

        }

        public ParkingModel(ParkedVehicle parkedVehicle)
        {
            ParkedVehicle = parkedVehicle;

        }
    }
}