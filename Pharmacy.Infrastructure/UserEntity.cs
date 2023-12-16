namespace Pharmacy.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class UserEntity
    {
        public long id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string login { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string password { get; set; }

        public long idrole { get; set; }

        public virtual PositionEntity role { get; set; }
    }
}
