using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public long Id { get; set; }
        public string Rolename { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
