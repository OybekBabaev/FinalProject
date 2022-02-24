using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new List<Comment>();
            Posts = new List<Post>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
