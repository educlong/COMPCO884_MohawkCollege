using System;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required, DataType(DataType.Duration)] 
        [YearValidation(ErrorMessage = "The year of car must be at least 1 year old, but not more than 3 years old.")]
        public int Year { get; set; }

        [DataType(DataType.Date), Display(Name = "Purchase Date")]
        [DateValidation(ErrorMessage = "Purchase Date can't be in the future")]
        public DateTime? PurchaseDate { get; set; }
        
        [Range(10000, 25000), DisplayFormat(DataFormatString ="{0:N0}")]
        public int? Kilometres { get; set; }
    }
}
