using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Models
{
    public partial class PostTag
    {
        public long Id { get; set; }
        public long? TagId { get; set; }
        public long? PostId { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
