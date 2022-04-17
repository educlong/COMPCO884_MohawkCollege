using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Convert.ToDateTime(value) <= DateTime.Now;
        }
    }
}
