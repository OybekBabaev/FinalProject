using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Models
{
    public partial class Tag
    {
        public Tag()
        {
            PostTags = new List<PostTag>();
        }

        public long Id { get; set; }
        public string Tagname { get; set; }

        public IEnumerable<PostTag> PostTags { get; set; }
    }
}
