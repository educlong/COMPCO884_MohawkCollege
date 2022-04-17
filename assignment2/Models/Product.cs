using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Table("products")]
    [Index(nameof(CategoryId), Name = "categories_products")]
    [Index(nameof(CategoryId), Name = "category_id")]
    [Index(nameof(ProductName), Name = "product_name")]
    [Index(nameof(SupplierId), Name = "supplier_id")]
    [Index(nameof(SupplierId), Name = "suppliers_products")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Required]
        [Column("product_name")]
        [StringLength(40), Display(Name ="Product")]
        public string ProductName { get; set; }
        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Column("quantity_per_unit")]
        [StringLength(20), Display(Name = "Quantity Per Unit")]
        public string QuantityPerUnit { get; set; }
        [Column("unit_price", TypeName = "money"), Display(Name = "Price")]
        public decimal? UnitPrice { get; set; }
        [Column("units_in_stock"), Display(Name = "In Stock")]
        public short? UnitsInStock { get; set; }
        [Column("units_on_order"), Display(Name = "On Order")]
        public short? UnitsOnOrder { get; set; }
        [Column("reorder_level"), Display(Name = "Reorder Level")]
        public short? ReorderLevel { get; set; }
        [Column("discontinued"), Display(Name = "Discontinued")]
        public bool Discontinued { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Value { get { return (UnitPrice == null || UnitsInStock == null) ? 0 : (UnitPrice * UnitsInStock); } }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("Products")]
        public virtual Supplier Supplier { get; set; }
        [InverseProperty(nameof(OrderDetail.Product))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
