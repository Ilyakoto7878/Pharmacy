namespace Pharmacy.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pharmacy")]
    public partial class Pharmacy
    {
        public long id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string name { get; set; }

        public long adress { get; set; }

        public long? ocenka { get; set; }
    }
}
