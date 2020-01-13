using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Citrix.Models.Services
{
    public class ValidationRangeMonth : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            value = (DateTime)value;
            // This assumes inclusivity, i.e. exactly six years ago is okay
            if (DateTime.Now.AddMonths(-1).CompareTo(value) <= 0 && DateTime.Now.CompareTo(value) >= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Datum moet binnen een maand zijn!");
            }
        }
    }
}
    


