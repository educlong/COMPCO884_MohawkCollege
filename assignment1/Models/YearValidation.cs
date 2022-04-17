using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class YearValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((int)value < DateTime.Now.Year) && ((int)value >= (DateTime.Now.Year - 3));
        }
    }
}
