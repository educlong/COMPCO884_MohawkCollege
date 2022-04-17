using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hospital_aspNetCoreWebApp_ModelViewControl.Models
{
    [Table("departments")]
    public partial class Department
    {
        public Department()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        [Key]
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Required]
        [Column("department_name")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        [Column("manager_first_name")]
        [StringLength(30)]
        public string ManagerFirstName { get; set; }
        [Column("manager_last_name")]
        [StringLength(30)]
        public string ManagerLastName { get; set; }

        [InverseProperty(nameof(PurchaseOrder.Department))]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
