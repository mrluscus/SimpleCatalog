using System;
using SimpleCatalog.Data.Model;
using System.Runtime.Serialization;

namespace SimpleCatalog.Data.Dto
{
    [DataContract]
    public class ProductDto : EntityDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for product category identifier.
        /// </summary>
        /// <value>
        /// The product category identifier.
        /// </value>
        [DataMember]
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDto"/> class.
        /// </summary>
        /// <param name="value">The Product type value.</param>
        public ProductDto(Product value)
        {
            Name = value.Name;
            Price = value.Price;
            Quantity = value.Quantity;
            ProductCategoryId = value.ProductCategoryId;
        }
    }
}