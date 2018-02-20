using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GoaGaraget.DataAccessLayer;
using System.Web.Mvc;

namespace GoaGaraget.Models
{
    public class ValidateUniqueRegistrationNumber : ValidationAttribute
    {
        private GarageDbContext _Db = new GarageDbContext();
        public bool IsParked(string regNr)
        {
            return _Db.ParkedVehicles.Any<ParkedVehicle>(v => (v.RegNumber == regNr));
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (IsParked((string)value))
                return new ValidationResult("Car is already in Garage");
            else
                return ValidationResult.Success;
        }

    }


    //public enum VehicleType { Car, Truck, Lorry, Motorcycle, Boat, Airplane }
    [OutputCacheAttribute(VaryByParam ="*",Duration =0,NoStore =true)]
    public class ParkedVehicle
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [DisplayName("Plate number")]
        [RegularExpression(@"[a-zA-ZÅÄÖ]{1,3}[0-9]{1,3}", ErrorMessage = "Please use correct format ABC123")]
        [Required(ErrorMessage = "Plate number is required")]
        [ValidateUniqueRegistrationNumber]
        public string RegNumber { get; set; }

        [DisplayName("Vehicle size")]
        [RegularExpression(@"[1-5]{1}", ErrorMessage = "Limited to 1-5 spaces")]
        [Required(ErrorMessage = "Plate number is required")]
        public int Size { get; set; } = 1;

        [DisplayName("Vehicle color")]
        [Required(ErrorMessage = "Please select a color")]
        public string Color { get; set; }

        [DisplayName("Vehicle type")]
        [Required(ErrorMessage = "Please select a type")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        [DisplayName("Vehicle brand")]
        [Required(ErrorMessage = "Please specify brand")]
        [StringLength(30, ErrorMessage = "Please limit to 30 characters")]
        public string Brand { get; set; }

        [DisplayName("How many wheels")]
        [Required(ErrorMessage = "Please specify number of wheels")]
        public int NumberOfWheels { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime CheckinDate { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<ParkingSpace> ParkingSpaces { get; set; }
        

        public ParkedVehicle()
        {
            this.ParkingSpaces = new List<ParkingSpace>();
        }
        public ParkedVehicle(Member member, string regNr, string color, VehicleType vehicleType, string brand, int numberOfWheels, DateTime checkinDate)
        {
            this.Member = member;
            this.RegNumber = regNr;
            this.Size = vehicleType.Size;
            this.Color = color;
            this.VehicleType = vehicleType;
            this.Brand = brand;
            this.NumberOfWheels = numberOfWheels;
            this.CheckinDate = checkinDate;
            this.ParkingSpaces = new List<ParkingSpace>();
        }
    }
}