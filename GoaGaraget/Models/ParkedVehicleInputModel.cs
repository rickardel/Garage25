using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class ParkedVehicleInputModel
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        public string RegNumber { get; set; }

        [DisplayName("Vehicle color")]
        [Required(ErrorMessage = "Please select a color")]
        public string Color { get; set; }
        
        [DisplayName("Vehicle brand")]
        [Required(ErrorMessage = "Please specify brand")]
        [StringLength(30, ErrorMessage = "Please limit to 30 characters")]
        public string Brand { get; set; }

        [DisplayName("How many wheels")]
        [Required(ErrorMessage = "Please specify number of wheels")]
        public int NumberOfWheels { get; set; }
    }
}