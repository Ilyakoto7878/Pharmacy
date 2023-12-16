namespace Pharmacy.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class ProductEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductEntity()
        {
        }

        public long id { get; set; }

        [StringLength(2147483647)]
        public string name { get; set; }

        public long? cost { get; set; }
    }
}
