using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1.Validators
{
    public class HasMoreThanOneLetter : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var content = Convert.ToString(value);
            var length = content.Length;
            if (length > 1)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(validationContext.DisplayName + " should has at least two letters");
        }
    }
}
