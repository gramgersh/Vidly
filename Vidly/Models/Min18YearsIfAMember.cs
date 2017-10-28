using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    // This is a ValidationAttribute to be appled between a Customer BirthDate and the
    // Membership type.
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cust = (Customer)validationContext.ObjectInstance;
            // To avoid too many red errors on page, don't print this if no membership type has been chosen.
            if (cust.MembershipTypeId == 0 || cust.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (cust.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - cust.BirthDate.Value.Year;
            
            if ( age >= 18 )
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Customer should be at least 18 years old to be a member.");
        }
    }
}