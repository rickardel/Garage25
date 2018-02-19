using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class VehicleType
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter Name")]
        public string Name { get; set; }
        [Required]
        [Range(1,5,ErrorMessage ="Please select a size between 1 and 5")]
        public int Size { get; set; }
        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }

        public VehicleType()
        {

        }
        public VehicleType(int id, string name, int size)
        {
            this.Id = id;
            this.Name = name;
            this.Size = size;
        }
    }
}