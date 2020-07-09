using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
   public class RoleRepository : IRole
    {
        private readonly inafocam_tracingContext _context;

        public RoleRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<Role> Roles => _context.Role;
        public Role GetRoleById(string id)
        {
            return _context.Role.Find(id);
        }
    }
}
