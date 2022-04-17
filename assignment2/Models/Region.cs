using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Table("region")]
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        [Column("region_id")]
        public int RegionId { get; set; }
        [Required]
        [Column("region_description")]
        [StringLength(50)]
        public string RegionDescription { get; set; }

        [InverseProperty(nameof(Territory.Region))]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
