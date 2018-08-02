using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCatalog.Data.Model
{
    public class Product : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for product category identifier.
        /// </summary>
        /// <value>
        /// The product category identifier.
        /// </value>
        [ForeignKey("ProductCategory")]
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>
        /// The product category.
        /// </value>
        public virtual ProductCategory ProductCategory { get; set; }
    }
}