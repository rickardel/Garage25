using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class ParkedVehicleListModel
    {
        public virtual Member Member { get; set; }
        //public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public string RegNumber { get; set; }
        public DateTime CheckinDate { get; set; }

        public ParkedVehicleListModel(Member member, VehicleType vehicleType, string regNumber, DateTime checkinDate)
        {
            this.Member = member;
            this.VehicleType = vehicleType;
            this.RegNumber = regNumber;
            this.CheckinDate = checkinDate;
        }
    }
}