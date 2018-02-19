using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class Member
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Sur name")]
        public string SurName { get; set; }
        public int Pin { get; set; }
        [Required(ErrorMessage = "Please enter person number")]
        public string PersonNumber { get; set; }

        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}