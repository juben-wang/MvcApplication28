using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Attribute
{
    public class StartsWithAAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (!value.ToString().StartsWith("A"))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                else {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}