using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTracker_aspNetCoreWebApp_MVC.Models
{
    public class DateSeenValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateSeen = Convert.ToDateTime(value);
            return dateSeen <= DateTime.Now;
        }
    }
}
