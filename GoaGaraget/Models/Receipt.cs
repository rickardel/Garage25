using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class Receipt
    {

        public int Id { get; set; }

        public int ParkedVehicleId { get; set; }
        public virtual ParkedVehicle ParkedVehicle { get; set; }

        public DateTime CheckinAt { get; set; }
        public DateTime CheckoutAt { get; set; }
        public int Cost { get; set; }
        public Receipt(){}

    }
}