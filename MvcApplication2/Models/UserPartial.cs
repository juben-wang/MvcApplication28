using MvcApplication2.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    //[MetadataType(typeof(UserMetadata))]
    //public partial class User : IValidatableObject
    //{
    //    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    {
    //        if (!this.Name.StartsWith("A"))
    //        {
    //            yield return new ValidationResult("使用者名稱必須以A字母開頭", new string[] { "Name" });
    //        }
    //    }
    //}

    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }

    public class UserMetadata
    {
        [Required]
        [Display(Name = "使用者名稱")]
        [StartsWithA(ErrorMessage = "必須以A字母開頭")]
        public string Name { get; set; }
    }
}

