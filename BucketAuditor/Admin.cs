namespace BucketAuditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        public Admin()
        {
            Buckets = new HashSet<Bucket>();
        }

        [Key]
        public Guid Admins_id { get; set; }

        public string Admins_FIO { get; set; }

        public string Admins_email { get; set; }

        public virtual ICollection<Bucket> Buckets { get; set; }
    }
}
