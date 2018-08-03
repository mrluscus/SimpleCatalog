using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCatalog.Data.Model
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}