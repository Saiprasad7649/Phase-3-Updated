using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Equinox.Models
{
    public class AgeRangeAttribute : ValidationAttribute, IClientModelValidator 
    {
        private readonly int _minAge;
        private readonly int _maxAge;

        public AgeRangeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of birth is required.");

            var dob = (DateTime)value;
            var today = DateTime.Today;
            var age = today.Year - dob.Year;

            // Adjust age if birthday hasn't occurred yet this year
            if (dob.Date > today.AddYears(-age))
                age--;

            if (age < _minAge || age > _maxAge)
            {
                return new ValidationResult(ErrorMessage ?? $"Age must be between {_minAge} and {_maxAge}.");
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext ctx) 
        {
            ctx.Attributes["data-val"] = "true";
            ctx.Attributes["data-val-agerange"] = ErrorMessage;
            ctx.Attributes["data-val-agerange-min"] = _minAge.ToString();
            ctx.Attributes["data-val-agerange-max"] = _maxAge.ToString();
        }
    }
}
