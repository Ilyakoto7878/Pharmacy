namespace Pharmacy.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("client")]
    public partial class ClientEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientEntity()
        {

        }

        [Key]
        public long id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string fio { get; set; }

        public string dataRozd { get; set; }
    }
}
