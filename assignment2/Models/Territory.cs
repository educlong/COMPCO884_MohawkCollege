using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Table("territories")]
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Key]
        [Column("territory_id")]
        [StringLength(20)]
        public string TerritoryId { get; set; }
        [Required]
        [Column("territory_description")]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }
        [Column("region_id")]
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        [InverseProperty("Territories")]
        public virtual Region Region { get; set; }
        [InverseProperty(nameof(EmployeeTerritory.Territory))]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
