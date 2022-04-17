using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Display(Name = "Category Name")]
        public string categoryName { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Products")]
        public object[] products { get; set; }
        public override string ToString()
        {
            return this.categoryName;
        }
    }

}
