using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Models
{
    public partial class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long? PostId { get; set; }
        public long? UserId { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
