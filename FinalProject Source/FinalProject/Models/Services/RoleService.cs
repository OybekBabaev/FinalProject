using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Services
{
    public class RoleService
    {
        private BloggingContext context;

        public RoleService(BloggingContext ctx) => context = ctx;

        public IEnumerable<Role> GetRoles() => context.Roles;

        public Role GetRoleById(long id) => context.Roles.FirstOrDefault(r => r.Id == id);
    }
}
