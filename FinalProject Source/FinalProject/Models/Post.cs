using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
            PostTags = new List<PostTag>();
        }

        public long Id { get; set; }
        public string Text { get; set; }
        public long? UserId { get; set; }

        public User User { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<PostTag> PostTags { get; set; }
    }
}
