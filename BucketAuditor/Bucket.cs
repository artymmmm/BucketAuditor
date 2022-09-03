namespace BucketAuditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bucket
    {
        [Key]
        public Guid Buckets_id { get; set; }

        [Required]
        public string Buckets_name { get; set; }

        public Guid Admins_id { get; set; }

        public bool Bucket_isPublic { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
