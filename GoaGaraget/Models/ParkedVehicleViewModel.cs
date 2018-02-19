using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoaGaraget.Models
{
    public class ParkedVehicleViewModel
    {
        [DisplayName("Vehicle Owner")]
        [Required(ErrorMessage = "Please select a Member from the registry")]
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        [DisplayName("Plate number")]
        [RegularExpression(@"[a-zA-ZÅÄÖ]{1,3}[0-9]{1,3}", ErrorMessage = "Please use correct format ABC123")]
        [Required(ErrorMessage = "Plate number is required")]
        [ValidateUniqueRegistrationNumber]
        public string RegNumber { get; set; }
        
        [DisplayName("Vehicle color")]
        [Required(ErrorMessage = "Please select a color")]
        public string Color { get; set; }

        [DisplayName("Vehicle type")]
        [Required(ErrorMessage = "Please select a vehicle type")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        
        [DisplayName("Vehicle brand")]
        [Required(ErrorMessage = "Please specify brand")]
        [StringLength(30, ErrorMessage = "Please limit to 30 characters")]
        public string Brand { get; set; }

        [DisplayName("How many wheels")]
        [Required(ErrorMessage = "Please specify number of wheels")]
        public int NumberOfWheels { get; set; }
        
        public SelectList Members { get; set; }
        public SelectList VehicleTypes { get; set; }
    }
}