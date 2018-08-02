using System;
using System.Runtime.Serialization;

namespace SimpleCatalog.Data.Dto
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class EntityDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public Guid Id { get; set; }
    }
}