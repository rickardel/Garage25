using GoaGaraget.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoaGaraget.Models
{
    public class ValidateUniquePersonNumber : ValidationAttribute
    {
        private GarageDbContext _Db = new GarageDbContext();
        public bool IsRegistered(string persNr)
        {
            return _Db.Members.Any<Member>(v => (v.PersonNumber == persNr));
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (IsRegistered((string)value))
                return new ValidationResult("Member is already in Register");
            else
                return ValidationResult.Success;
        }

    }
    public class Member
    {
        public Member()
        {

        }
        public Member(int id, string firstName, string lastName, int pin, int price, string personNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.SurName = lastName;
            this.Pin = pin;
            this.Price = price;
            this.PersonNumber = personNumber;
        }

        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Sur name")]
        public string SurName { get; set; }
        public int Pin { get; set; }
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter person number")]
        [ValidateUniquePersonNumber]
        [RegularExpression(@"[0-9]{1,6}-[0-9]{1,4}", ErrorMessage = "Please use correct format YYMMDD-SSSS")]
        public string PersonNumber { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}