using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SimpleCatalog.Data.Model;

namespace SimpleCatalog.Data.Dto
{
    [DataContract]
    public class ProductCategoryDto : EntityDto
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
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        [DataMember]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// The children
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<ProductCategoryDto> Children;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryDto"/> class.
        /// </summary>
        /// <param name="value">The ProductCategory type value.</param>
        public ProductCategoryDto(ProductCategory value)
        {
            Id = value.Id;
            Name = value.Name;
            ParentId = value.ParentId;
            Children = null;
        }
    }
}