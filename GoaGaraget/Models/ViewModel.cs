using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class ViewModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public DateTime CheckinDate { get; set; }
        public int HourRate { get; set; }
        public float Cost { get; set; }
        public DateTime CreatedAt { get; set; }


        public ViewModel(ParkedVehicle pv)
        {
            this.RegNumber = pv.RegNumber;
            this.CheckinDate = pv.CheckinDate;
            this.CreatedAt = DateTime.Now;
            this.HourRate = 20;
            this.Cost = 0; // TODO pv.CalculateCost(this.CheckinDate, this.CreatedAt, this.HourRate);
        }
    }
}