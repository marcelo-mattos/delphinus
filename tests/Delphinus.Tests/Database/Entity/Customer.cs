using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delphinus.Tests.Database.Entity
{
    /// <summary>
    /// Customer Entity
    /// </summary>
    [Table(nameof(Customer), Schema = "public")]
    public class Customer
    {
        /// <summary>
        /// Id field
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column]
        public Guid Id { get; set; }

        /// <summary>
        /// Name field
        /// </summary>
        [Column]
        public String Name { get; set; }

        /// <summary>
        /// Birthdate field
        /// </summary>
        [Column]
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Level field
        /// </summary>
        [Column]
        public Int32 Level { get; set; }

        /// <summary>
        /// Salary field
        /// </summary>
        [Column]
        public Decimal? Salary { get; set; }

        /// <summary>
        /// IsActive field
        /// </summary>
        public Boolean? IsActive { get; set; }
    }
}
